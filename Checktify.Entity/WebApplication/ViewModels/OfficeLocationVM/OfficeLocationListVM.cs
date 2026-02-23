using Checktify.Entity.WebApplication.ViewModels.CompanyVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Entity.WebApplication.ViewModels.OfficeLocationVM
{
    public class OfficeLocationListVM
    {
        public virtual Guid Id { get; set; }
        public virtual string CreatedDate { get; set; } = DateTime.Now.ToString("d");
        public virtual string? UpdatedDate { get; set; }

        public Guid CompanyId { get; set; }
        public CompanyListVM Company { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public bool Active { get; set; }
    }
}
