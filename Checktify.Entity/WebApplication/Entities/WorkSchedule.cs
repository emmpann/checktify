using Checktify.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Entity.WebApplication.Entities
{
    public class WorkSchedule : BaseEntity
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
