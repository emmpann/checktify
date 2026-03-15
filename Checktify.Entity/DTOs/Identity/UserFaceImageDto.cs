using System;

namespace Checktify.Entity.DTOs.Identity
{
    public class UserFaceImageDto
    {
        public Guid Id { get; set; }
        public required string UserId { get; set; }
        public required string StoragePath { get; set; }
        public bool IsPrimary { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class UserFaceImageCreateDto
    {
        public required string UserId { get; set; }
        public required string StoragePath { get; set; }
        public bool IsPrimary { get; set; }
    }

    public class UserFaceImageListDto
    {
        public Guid Id { get; set; }
        public required string StoragePath { get; set; }
        public bool IsPrimary { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
