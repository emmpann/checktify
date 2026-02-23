using Checktify.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Entity.WebApplication.Entities
{
    public class Role : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
