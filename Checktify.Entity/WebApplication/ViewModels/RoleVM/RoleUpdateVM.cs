using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Entity.WebApplication.ViewModels.RoleVM
{
    public class RoleUpdateVM
    {
        public Guid Id { get; set; }
        //public string Code { get; set; }
        public string Name { get; set; } = null!;
    }
}
