using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Entity.WebApplication.ViewModels.CompanyVM
{
    public class CompanyUpdateVM
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }

        public virtual Guid Id { get; set; }
        public virtual string? UpdatedDate { get; set; }
        public virtual byte[] RowVersion { get; set; }
    }
}
