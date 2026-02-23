using Checktify.Entity.WebApplication.Entities;
using Checktify.Entity.WebApplication.ViewModels.CompanyVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Entity.WebApplication.ViewModels.OfficeLocationVM
{
    public class OfficeLocationAddVM
    {
        public Guid CompanyId { get; set; }
        public CompanyAddVM Company { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public bool Active { get; set; }
    }
}
