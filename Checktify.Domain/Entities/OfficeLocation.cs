using Checktify.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Domain.Entities
{
    public class OfficeLocation
    {
        public Guid Id { get; set; }
        public Company Company { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Coordinate Coordinate { get; set; }
        public bool Active { get; set; }
    }
}
