using Checktify.Entity.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.Customization.Identity.Validators
{
    public class CustomPasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string? password)
        {
            var errors = new List<IdentityError>();

            if (password!.ToLower().Contains(user.UserName!.ToLower()))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContainsUserName",
                    Description = "Password cannot contain the username."
                });
            }

            if (password.StartsWith("123"))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordStartDigitError",
                    Description = "Password cannot start or end with '123'."
                });
            }

            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
