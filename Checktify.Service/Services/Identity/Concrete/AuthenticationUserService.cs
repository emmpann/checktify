using AutoMapper;
using Checktify.Core.Enumerators;
using Checktify.Entity.Identity.Entities;
using Checktify.Entity.Identity.ViewModels;
using Checktify.Service.Helpers.Generic.Image;
using Checktify.Service.Services.Identity.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Checktify.Service.Services.Identity.Concrete
{
    public class AuthenticationUserService : IAuthenticationUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IImageHelper _imageHelper;

        public AuthenticationUserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IImageHelper imageHelper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _imageHelper = imageHelper;
        }

        public async Task<UserEditVM> GetUserEditVMAsync(HttpContext httpContext)
        {
            var user = await _userManager.FindByNameAsync(httpContext.User.Identity!.Name!);
            var userEditVm = _mapper.Map<UserEditVM>(user);
            return userEditVm;
        }

        public async Task<IdentityResult> UserEditAsync(UserEditVM request, AppUser user)
        {
            var passwordCheck = await _userManager.CheckPasswordAsync(user!, request.Password);
            if (!passwordCheck)
            {
                var errors = new IdentityError() { Code = "IncorrectPassword", Description = "Current password is incorrect" };
                var passwordFailed = IdentityResult.Failed(errors);

                return passwordFailed;
            }

            if (request.NewPassword != null)
            {
                var passwordChangeResult = await _userManager.ChangePasswordAsync(user!, request.Password, request.NewPassword);
                if (!passwordChangeResult.Succeeded)
                {
                    return passwordChangeResult;
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

                    var errors = new IdentityError() { Code = "ImageUploadError", Description = image.Error };
                    var imageResult = IdentityResult.Failed(errors);

                    return imageResult;
                }

                request.FileName = image.Filename;
                request.FileType = request.Photo.ContentType;
            }
            else
            {
                request.FileName = oldFileName;
                request.FileType = oldFileType;
            }

            var mappedUser = _mapper.Map(request, user);
            var userUpdate = await _userManager.UpdateAsync(mappedUser);
            if (userUpdate.Succeeded)
            {
                if (request.Photo != null)
                {
                    if (oldFileName != null && oldFileType != null)
                    {
                        _imageHelper.DeleteImage(oldFileName);
                    }
                }

                await _userManager.UpdateSecurityStampAsync(user);
                await _signInManager.SignOutAsync();
                await _signInManager.SignInAsync(user, false);

                return userUpdate;
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

            return userUpdate;
        }
    }
}
