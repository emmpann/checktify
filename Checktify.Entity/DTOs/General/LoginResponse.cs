using Checktify.Entity.DTOs.Authentication;

namespace Checktify.Entity.DTOs.General
{
    public class LoginResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public string TokenType { get; set; } = string.Empty;
        public int ExpiresIn { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public UserDto? User { get; set; }
    }
}
