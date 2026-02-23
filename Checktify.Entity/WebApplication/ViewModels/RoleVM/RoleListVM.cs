using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Entity.WebApplication.ViewModels.RoleVM
{
    public class RoleListVM
    {
        public virtual Guid Id { get; set; }
        public virtual string CreatedDate { get; set; } = DateTime.Now.ToString("d");
        public virtual string? UpdatedDate { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
    }
}
