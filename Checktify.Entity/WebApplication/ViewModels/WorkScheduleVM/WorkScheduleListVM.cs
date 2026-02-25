using Checktify.Entity.WebApplication.Entities;
using Checktify.Entity.WebApplication.ViewModels.CompanyVM;
using Checktify.Entity.WebApplication.ViewModels.RoleVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Entity.WebApplication.ViewModels.WorkScheduleVM
{
    public class WorkScheduleListVM
    {
        public virtual Guid Id { get; set; }
        public virtual string CreatedDate { get; set; } = DateTime.Now.ToString("d");
        public virtual string? UpdatedDate { get; set; }

        public Guid OfficeLocationId { get; set; }
        public OfficeLocation OfficeLocation { get; set; } = null!;
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan CheckOutTime { get; set; }
    }
}
