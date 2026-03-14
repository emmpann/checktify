using Checktify.Entity.Identity.Entities;
using System.ComponentModel.DataAnnotations;

namespace Checktify.Entity.DTOs.Attendance
{
    public record AddAttendance
    {
        [Required]
        public string UserId { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        [Required]
        public decimal Location { get; set; }
    }
}
