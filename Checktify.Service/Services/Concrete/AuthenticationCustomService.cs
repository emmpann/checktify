using Azure.Core;
using Checktify.Entity.Identity.Entities;
using Checktify.Entity.Identity.ViewModels;
using Checktify.Service.Helpers.Identity.EmailHelper;
using Checktify.Service.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.Services.Concrete
{
    public class AuthenticationCustomService : IAuthenticationCustomService
    {
        private readonly IEmailSendMethod _emailSendMethod;
        private readonly UserManager<AppUser> _userManager;

        public AuthenticationCustomService(IEmailSendMethod email, UserManager<AppUser> userManager)
        {
            _emailSendMethod = email;
            _userManager = userManager;
        }

        public async Task CreateResetCredentialsAndSend(AppUser user, HttpContext context, IUrlHelper url, ForgotPasswordVM request)
        {
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetLink = url.Action("ResetPassword", "Authentication", new { UserId = user.Id, Token = resetToken }, context.Request.Scheme);

            await _emailSendMethod.SendPasswordResetLinkWithToken(passwordResetLink!, request.Email);
        }
    }
}
