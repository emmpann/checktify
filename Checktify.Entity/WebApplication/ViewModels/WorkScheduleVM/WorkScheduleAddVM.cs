using Checktify.Entity.WebApplication.Entities;
using Checktify.Entity.WebApplication.ViewModels.CompanyVM;
using Checktify.Entity.WebApplication.ViewModels.RoleVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Entity.WebApplication.ViewModels.WorkScheduleVM
{
    public class WorkScheduleAddVM
    {
        public Guid OfficeLocationId { get; set; }
        public OfficeLocation OfficeLocation { get; set; } = null!;
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan CheckOutTime { get; set; }
    }
}
