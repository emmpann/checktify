using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Domain.Entities
{
    public class WorkSchedule
    {
        public Guid Id { get; set; }
        public Company Company { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }
    }
}
