namespace Checktify.Entity.DTOs.Authentication
{
    public class RegisterResult
    {
        public bool Success { get; set; }
        public List<string>? Errors { get; set; }
    }
}
