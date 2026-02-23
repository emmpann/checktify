using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Entity.WebApplication.ViewModels.RoleVM
{
    public class RoleUpdateVM
    {
        public virtual Guid Id { get; set; }
        public virtual string? UpdatedDate { get; set; }
        public virtual byte[] RowVersion { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
    }
}
