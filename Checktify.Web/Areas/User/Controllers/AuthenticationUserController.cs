using AutoMapper;
using Checktify.Core.Enumerators;
using Checktify.Entity.Identity.Entities;
using Checktify.Entity.Identity.ViewModels;
using Checktify.Service.Helpers.Generic.Image;
using Checktify.Service.Helpers.Identity;
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
        private readonly IMapper _mapper;
        private readonly IValidator<UserEditVM> _userEditValidator;
        private readonly IImageHelper _imageHelper;

        public AuthenticationUserController(UserManager<AppUser> userManager, IMapper mapper, IValidator<UserEditVM> userEditValidator, SignInManager<AppUser> signInManager, IImageHelper imageHelper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _userEditValidator = userEditValidator;
            _signInManager = signInManager;
            _imageHelper = imageHelper;
        }

        [HttpGet]
        public async Task<ActionResult> UserEdit()
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
            var userEditVm = _mapper.Map<UserEditVM>(user);
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

            var passwordCheck = await _userManager.CheckPasswordAsync(user!, request.Password);
            if(!passwordCheck)
            {
                ViewBag.Result = "IncorrectPassword";
                ModelState.AddModelErrorsList(new List<string> { "Current password is incorrect." } );

                return Redirect(nameof(UserEdit));
            }

            if (request.NewPassword != null)
            {
                var passwordChangeResult = await _userManager.ChangePasswordAsync(user!, request.Password, request.NewPassword);
                if (!passwordChangeResult.Succeeded)
                {
                    ViewBag.Result = "PasswordChangeFailed";
                    ModelState.AddModelErrorsList(passwordChangeResult.Errors.Select(e => e.Description).ToList());
                    return Redirect(nameof(UserEdit));
                }
            }

            var oldFileName = user!.FileName;
            var oldFileType = user!.FileType;

            if (request.Photo != null)
            {
                var image = await _imageHelper.ImageUplaod(request.Photo, ImageType.identity, null);

                if (image.Error != null)
                {
                    if (request.NewPassword != null)
                    {
                        await _userManager.ChangePasswordAsync(user!, request.NewPassword, request.Password);
                        await _userManager.UpdateSecurityStampAsync(user);
                        await _signInManager.SignOutAsync();
                        await _signInManager.SignInAsync(user, false);
                    }

                    return Redirect(nameof(UserEdit));
                }

                request.FileName = image.Filename;
                request.FileType = request.Photo.ContentType;
            } else
            {
                request.FileName = oldFileName;
                request.FileType = oldFileType;
            }

            var mappedUser = _mapper.Map(request, user);
            var userUpdate = await _userManager.UpdateAsync(mappedUser);
            if (userUpdate.Succeeded)
            {
                if(request.Photo != null)
                {
                    if (oldFileName != null && oldFileType != null)
                    {
                        _imageHelper.DeleteImage(oldFileName);
                    }
                }

                await _userManager.UpdateSecurityStampAsync(user);
                await _signInManager.SignOutAsync();
                await _signInManager.SignInAsync(user, false);

                return RedirectToAction("Index", "Dashboard", new { area = "User" });
            }

            if (request.FileName != null)
            {
                _imageHelper.DeleteImage(request.FileName);
            }

            if (request.NewPassword != null)
            {
                await _userManager.ChangePasswordAsync(user!, request.NewPassword, request.Password);
                await _userManager.UpdateSecurityStampAsync(user);
                await _signInManager.SignOutAsync();
                await _signInManager.SignInAsync(user, false);
            }

            ViewBag.Username = user.UserName;
            return Redirect(nameof(UserEdit));
        }
    }
}
