using Checktify.Entity.WebApplication.ViewModels.CompanyVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Entity.WebApplication.ViewModels.OfficeLocationVM
{
    public class OfficeLocationUpdateVM
    {
        public virtual Guid Id { get; set; }
        public virtual string? UpdatedDate { get; set; }
        public virtual byte[] RowVersion { get; set; }

        public Guid CompanyId { get; set; }
        public CompanyUpdateVM Company { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public bool Active { get; set; }
    }
}
