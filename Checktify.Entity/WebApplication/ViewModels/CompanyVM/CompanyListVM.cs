using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Entity.WebApplication.ViewModels.CompanyVM
{
    public class CompanyListVM
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }

        public virtual Guid Id { get; set; }
        public virtual string CreatedDate { get; set; } = DateTime.Now.ToString("d");
        public virtual string? UpdatedDate { get; set; }
    }
}
