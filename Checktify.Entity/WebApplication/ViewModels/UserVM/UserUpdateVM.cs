using Checktify.Entity.WebApplication.Entities;
using Checktify.Entity.WebApplication.ViewModels.CompanyVM;
using Checktify.Entity.WebApplication.ViewModels.RoleVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Entity.WebApplication.ViewModels.UserVM
{
    public class UserUpdateVM
    {
        public virtual Guid Id { get; set; }
        public virtual string? UpdatedDate { get; set; }
        public virtual byte[] RowVersion { get; set; }

        public Guid CompanyId { get; set; }
        public CompanyUpdateVM Company { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string WorkSchedule { get; set; }
        public Guid RoleId { get; set; }
        public RoleUpdateVM Role { get; set; }
    }
}
