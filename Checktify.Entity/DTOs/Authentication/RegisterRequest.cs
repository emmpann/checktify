namespace Checktify.Entity.DTOs.Authentication
{
    public class RegisterRequest
    {
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string CompanyId { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
