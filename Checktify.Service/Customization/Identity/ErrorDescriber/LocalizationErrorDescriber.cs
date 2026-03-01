using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.Customization.Identity.ErrorDescriber
{
    public class LocalizationErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresDigit()
        {
            return new() { Code = "NewDigitError", Description = "Please Use Digit" };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new() { Code = "NewLowerLettersError", Description = "Please Use Lower Letters" };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new() { Code = "NewTooShortError", Description = "Your Password too short!" };
        }
    }
}
