using Checktify.Core.Entities;
using Checktify.Core.Enumerators;
using Checktify.Entity.WebApplication.Entities;
using Microsoft.AspNetCore.Identity;

namespace Checktify.Entity.Identity.Entities
{
    public class AppUser : IdentityUser
    {
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public GenderType? Gender { get; set; }
        public string? ProfileImagePath { get; set; }
        public bool IsActive { get; set; } = true;
        public string? EmployeeCode { get; set; }
        public string? Department { get; set; }
        public string? Position { get; set; }
        public DateTime? JoinDate { get; set; }
        public Guid? CompanyId { get; set; }
        public Company Company { get; set; } = null!;
        public Guid? WorkScheduleId { get; set; }
        public WorkSchedule WorkSchedule { get; set; } = null!;
        public bool FaceRegistrationCompleted { get; set; } = false;
        public ICollection<UserFaceImage>? FaceImages { get; set; }
        public required string CreatedDate { get; set; }
        public string? FileName { get; set; }
        public string? FileType { get; set; }
    }
}
