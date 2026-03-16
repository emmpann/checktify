namespace Checktify.Entity.DTOs.Authentication
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public List<string>? Errors { get; set; }
        public string? Token { get; set; }
        public string? TokenType { get; set; } = "Bearer";
        public int ExpiresIn { get; set; }
        public string? RefreshToken { get; set; }
        public UserDto? User { get; set; }  
    }
}
