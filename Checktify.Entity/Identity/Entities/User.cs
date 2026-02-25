using Checktify.Entity.WebApplication.Entities;
using Microsoft.AspNetCore.Identity;

namespace Checktify.Entity.Identity.Entities
{
    public class User : IdentityUser
    {
        public Guid? CompanyId { get; set; }
        public Company? Company { get; set; }
        public Guid? WorkScheduleId { get; set; }
        public WorkSchedule? WorkSchedule { get; set; }
    }
}
