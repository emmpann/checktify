namespace Checktify.Entity.DTOs.Authentication
{
    public class LogInRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
