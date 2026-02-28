using Checktify.Entity.Identity.Entities;
using Checktify.Entity.WebApplication.Entities;
using Checktify.Entity.WebApplication.ViewModels.OfficeLocationVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Entity.WebApplication.ViewModels.AttendanceVM
{
    public class AttendanceUpdateVM
    {
        public virtual Guid Id { get; set; }
        public virtual string? UpdatedDate { get; set; }
        public virtual byte[] RowVersion { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public Guid CheckInOfficeLocationId { get; set; }
        public OfficeLocationUpdateVM CheckInOfficeLocation { get; set; }
        public Guid CheckOutOfficeLocationId { get; set; }
        public OfficeLocationUpdateVM CheckOutOfficeLocation { get; set; }
    }
}
