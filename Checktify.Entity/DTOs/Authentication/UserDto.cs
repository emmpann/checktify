using Checktify.Entity.DTOs.Identity;

namespace Checktify.Entity.DTOs.Authentication
{
    public class UserDto
    {
        public required string Id { get; set; }
        public required string Email { get; set; }
        public required string Username { get; set; }
        public required string Name { get; set; }
        public int Role { get; set; }
        public string? CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? OfficeLocationId { get; set; }
        public string? OfficeLocation { get; set; }
        public string? FaceImageUrl { get; set; }
        public List<UserFaceImageDto> FaceImageUrls { get; set; } = [];
        public bool FaceRegistrationCompleted { get; set; }
        public bool IsActive { get; set; }
    }
}
