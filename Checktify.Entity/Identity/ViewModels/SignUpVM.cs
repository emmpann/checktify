using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Entity.Identity.ViewModels
{
    public class SignUpVM
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;   
        public string ConfirmPassword { get; set; } = null!;
    }
}
