using Checktify.Entity.Identity.Entities;
using Checktify.Entity.Identity.ViewModels;
using Checktify.Service.Helpers.Identity;
using Checktify.Service.Services.Identity.Abstract;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Checktify.Web.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class AuthenticationUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IValidator<UserEditVM> _userEditValidator;
        private readonly IAuthenticationUserService _authenticationUserService;

        public AuthenticationUserController(UserManager<AppUser> userManager, IValidator<UserEditVM> userEditValidator, IAuthenticationUserService authenticationUserService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _userEditValidator = userEditValidator;
            _authenticationUserService = authenticationUserService;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<ActionResult> UserEdit()
        {
            var userEditVm = await _authenticationUserService.GetUserEditVMAsync(HttpContext);
            return View(userEditVm);
        }

        [HttpPost]
        public async Task<ActionResult> UserEdit(UserEditVM request)
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);

            var validation = await _userEditValidator.ValidateAsync(request);
            if(!validation.IsValid)
            {
                validation.AddToModelState(this.ModelState);
                return View();
            }            

            var userEditResult = await _authenticationUserService.UserEditAsync(request, user!);
            if (!userEditResult.Succeeded)
            {
                ViewBag.Result = "FailedUserEdit";
                ModelState.AddModelErrorsList(userEditResult.Errors);

                return View();
            }

            ViewBag.Username = user!.UserName;
            return RedirectToAction("Index", "Dashboard", new { area = "User" });
        }

    }
}
