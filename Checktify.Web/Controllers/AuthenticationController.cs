using AutoMapper;
using Checktify.Entity.Identity.Entities;
using Checktify.Entity.Identity.ViewModels;
using Checktify.Service.Helpers.Identity;
using Checktify.Service.Helpers.Identity.EmailHelper;
using Checktify.Service.Services.Identity.Abstract;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Checktify.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IValidator<SignUpVM> _signUpValidator;
        private readonly IValidator<LogInVM> _logInValidator;
        private readonly IValidator<ForgotPasswordVM> _forgotPasswordValidator;
        private readonly IValidator<ResetPasswordVM> _resetPasswordValidator;
        private readonly IMapper _iMapper;
        private readonly IAuthenticationMainService _authenticationCustomService;
        private readonly IToastNotification _toasty;

        public AuthenticationController(UserManager<AppUser> userManager, IValidator<SignUpVM> signUpValidator, IMapper iMapper, SignInManager<AppUser> signInManager, IValidator<LogInVM> logInValidator, IValidator<ForgotPasswordVM> forgotPasswordValidator, IEmailSendMethod emailSendMethod, IValidator<ResetPasswordVM> resetPasswordValidator, IAuthenticationMainService authenticationCustomService, IToastNotification toasty)
        {
            _userManager = userManager;
            _signUpValidator = signUpValidator;
            _iMapper = iMapper;
            _signInManager = signInManager;
            _logInValidator = logInValidator;
            _forgotPasswordValidator = forgotPasswordValidator;
            _resetPasswordValidator = resetPasswordValidator;
            _authenticationCustomService = authenticationCustomService;
            _toasty = toasty;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpVM request)
        {
            var validation = await _signUpValidator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                validation.AddToModelState(ModelState);
                return View();
            }

            var user = _iMapper.Map<AppUser>(request);
            var userCreateResult = await _userManager.CreateAsync(user, request.Password);
            if (!userCreateResult.Succeeded)
            {
                ViewBag.Result = "NotSucceed";
                ModelState.AddModelErrorsList(userCreateResult.Errors);
                return View();
            }

            _toasty.AddSuccessToastMessage("Your account has been created successfully! You can log in now.", new ToastrOptions { Title = "Congratulations" });
            return RedirectToAction("LogIn", "Authentication");
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInVM request, string? returnUrl = null)
        {
            returnUrl ??= Url.Action("Index", "Dashboard", new { Area = "User" });
            var validation = await _logInValidator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                validation.AddToModelState(this.ModelState);
                return View();
            }

            var hasUser = await _userManager.FindByEmailAsync(request.Email);
            if (hasUser == null)
            {
                ViewBag.Result = "NotSucceed";
                ModelState.AddModelErrorsList(new List<String> { "Email or Password is wrong" });
                return View();
            }

            var logInResult = await _signInManager.PasswordSignInAsync(hasUser, request.Password, request.RememberMe, true);
            if (logInResult.Succeeded)
            {
                _toasty.AddSuccessToastMessage("You have logged in successfully!", new ToastrOptions { Title = "Welcome Back" });
                return Redirect(returnUrl!);
            }

            if (logInResult.IsLockedOut)
            {
                ViewBag.Result = "LockedOut";
                ModelState.AddModelErrorsList(new List<String> { "Your account is locked out for 60 seconds!" });
                return View();
            }

            ViewBag.Result = "FailedAttempt";
            ModelState.AddModelErrorsList(new List<String> { $"Email or Password is wrong! Failed attempt{await _userManager.GetAccessFailedCountAsync(hasUser)}" });
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM request)
        {
            var validation = await _forgotPasswordValidator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                validation.AddToModelState(this.ModelState);
                return View();
            }

            var hasUser = await _userManager.FindByEmailAsync(request.Email);
            if (hasUser == null)
            {
                ViewBag.Result = "UserDoesNotExist";
                ModelState.AddModelErrorsList(new List<String> { "Email is not registered!" });
                return View();
            }

            _toasty.AddSuccessToastMessage("If an account with the provided email exists, a password reset link has been sent.", new ToastrOptions { Title = "Check Your Email" });

            await _authenticationCustomService.CreateResetCredentialsAndSend(hasUser, HttpContext, Url, request);
            return RedirectToAction("LogIn", "Authentication");
        }

        [HttpGet]
        public IActionResult ResetPassword(string userId, string token, List<string>? errors)
        {
            TempData["UserId"] = userId;
            TempData["Token"] = token;

            if (errors.Any())
            {
                ViewBag.Result = "Error";
                ModelState.AddModelErrorsList(errors);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM request)
        {
            var userId = TempData["UserId"];
            var token = TempData["Token"];

            if (userId == null || token == null)
            {
                _toasty.AddErrorToastMessage("An error occurred while processing your request. Please try again.", new ToastrOptions { Title = "Error" });
                return RedirectToAction("LogIn", "Authentication");
            }

            var validation = await _resetPasswordValidator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                List<string> errors = validation.Errors.Select(e => e.ErrorMessage).ToList();
                return RedirectToAction("ResetPassword", "Authentication", new { userId, token, errors });
            }

            var hasUser = await _userManager.FindByIdAsync(userId.ToString()!);
            if (hasUser == null)
            {
                _toasty.AddErrorToastMessage("An error occurred while processing your request. Please try again.", new ToastrOptions { Title = "Error" });
                return RedirectToAction("LogIn", "Authentication");
            }

            var resetPasswordResult = await _userManager.ResetPasswordAsync(hasUser!, token.ToString()!, request.Password);

            if (resetPasswordResult.Succeeded)
            {
                _toasty.AddSuccessToastMessage("Your password has been reset successfully! You can log in now.", new ToastrOptions { Title = "Success" });
                return RedirectToAction("LogIn", "Authentication");
            }
            else
            {
                List<string> errors = resetPasswordResult.Errors.Select(e => e.Description).ToList();
                return RedirectToAction("ResetPassword", "Authentication", new { userId, token, errors });
            }
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
