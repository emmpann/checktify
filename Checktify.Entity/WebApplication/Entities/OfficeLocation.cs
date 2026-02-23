using Checktify.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Entity.WebApplication.Entities
{
    public class OfficeLocation : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public bool Active { get; set; }
    }
}
