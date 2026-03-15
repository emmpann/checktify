namespace Checktify.Entity.Identity.Entities
{
    public class UserFaceImage
    {
        public Guid Id { get; set; }
        public required string UserId { get; set; }
        public AppUser User { get; set; } = null!;
        public required string StoragePath { get; set; }
        public bool IsPrimary { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
