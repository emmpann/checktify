using AutoMapper;
using Checktify.Entity.Identity.Entities;
using Checktify.Entity.Identity.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Checktify.Service.Helpers.Identity;

namespace Checktify.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IValidator<SignUpVM> _signUpValidator;
        private readonly IValidator<LogInVM> _logInValidator;
        private readonly IMapper _iMapper;

        public AuthenticationController(UserManager<User> userManager, IValidator<SignUpVM> signUpValidator, IMapper iMapper, SignInManager<User> signInManager, IValidator<LogInVM> logInValidator)
        {
            _userManager = userManager;
            _signUpValidator = signUpValidator;
            _iMapper = iMapper;
            _signInManager = signInManager;
            _logInValidator = logInValidator;
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

            var user = _iMapper.Map<User>(request);
            var userCreateResult = await _userManager.CreateAsync(user, request.Password);
            if (!userCreateResult.Succeeded)
            {
                ViewBag.Result = "NotSucceed";
                ModelState.AddModelErrorsList(userCreateResult.Errors);
                return View();
            }

            return RedirectToAction("LogIn", "Authentication");
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInVM request, string? returnUrl=null)
        {
            returnUrl ??= Url.Action("Index", "Dashboard", new {Area = "Admin"});
            var validation = await _logInValidator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                ViewBag.Result = "NotSucceed";
                validation.AddToModelState(this.ModelState);
                return View();
            }

            var hasUser = await _userManager.FindByEmailAsync(request.Email);
            if (hasUser == null)
            {
                ViewBag.Result = "NotSucceed";
                ModelState.AddModelErrorsList(new List<String> { "Email or Password is wrong"});
                return View();
            }

            var logInResult = await _signInManager.PasswordSignInAsync(hasUser, request.Password, request.RememberMe, true);
            if(logInResult.Succeeded)
            {
                return Redirect(returnUrl!);
            }
            
            if(logInResult.IsLockedOut)
            {
                ViewBag.Result = "LockedOut";
                ModelState.AddModelErrorsList(new List<String> { "Your account is locked out for 60 seconds!" });
                return View();
            }

            ViewBag.Result = "FailedAttempt";
            ModelState.AddModelErrorsList(new List<String> { $"Email or Password is wrong! Failed attempt{ await _userManager.GetAccessFailedCountAsync(hasUser)}" });
            return View();
        }
    }
}
