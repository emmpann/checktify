using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Domain.Enums
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
