using Checktify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public Company Company { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string WorkSchedule { get; set; }
        public Role Role { get; set; }
    }
}
