using Checktify.Entity.WebApplication.Entities;
using Checktify.Entity.WebApplication.ViewModels.OfficeLocationVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Entity.WebApplication.ViewModels.AttendanceVM
{
    public class AttendanceAddVM
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public Guid CheckInOfficeLocationId { get; set; }
        public OfficeLocationAddVM CheckInOfficeLocation { get; set; }
        public Guid CheckOutOfficeLocationId { get; set; }
        public OfficeLocationAddVM CheckOutOfficeLocation { get; set; }
    }
}
