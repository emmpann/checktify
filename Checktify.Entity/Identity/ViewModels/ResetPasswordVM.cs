using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Entity.Identity.ViewModels
{
    public class ResetPasswordVM
    {
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
    }
}
