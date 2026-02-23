using Checktify.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Entity.WebApplication.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }
    }
}
