using Checktify.Entity.Identity.Entities;
using Checktify.Entity.WebApplication.Entities;
using Checktify.Entity.WebApplication.ViewModels.OfficeLocationVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Entity.WebApplication.ViewModels.AttendanceVM
{
    public class AttendanceListVM
    {
        public virtual Guid Id { get; set; }
        public virtual string CreatedDate { get; set; } = DateTime.Now.ToString("d");
        public virtual string? UpdatedDate { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public Guid CheckInOfficeLocationId { get; set; }
        public OfficeLocationListVM CheckInOfficeLocation { get; set; }
        public Guid CheckOutOfficeLocationId { get; set; }
        public OfficeLocationListVM CheckOutOfficeLocation { get; set; }
    }
}
