using Checktify.Entity.DTOs.Authentication;

namespace Checktify.Entity.DTOs.General
{
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public int ExpiresIn { get; set; }
        public UserDto? User { get; set; }
    }
}
