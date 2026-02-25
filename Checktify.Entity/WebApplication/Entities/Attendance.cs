using Checktify.Core.Entities;
using Checktify.Entity.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Entity.WebApplication.Entities
{
    public class Attendance : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public Guid CheckInOfficeLocationId { get; set; }
        public OfficeLocation CheckInOfficeLocation { get; set; }
        public Guid CheckOutOfficeLocationId { get; set; }
        public OfficeLocation CheckOutOfficeLocation { get; set; }
    }
}
