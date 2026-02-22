using Checktify.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Domain.Entities
{
    public class Attendance
    {
        public Guid Id { get; set; }
        public Company Company { get; set; }
        public User User { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public OfficeLocation CheckInOfficeLocation { get; set; }
        public OfficeLocation CheckOutOfficeLocation { get; set; }
    }
}
