using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.Messages.Identity
{
    public static class IdentityMessages
    {
        public static string CheckEmailAddress()
        {
            return $"should be in email format";
        }

        public static string ComparePassword()
        {
            return $"Password and Confirm Password must be same with the password";
        }
    }
}
