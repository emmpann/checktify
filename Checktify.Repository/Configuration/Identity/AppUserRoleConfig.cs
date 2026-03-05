using Checktify.Entity.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Checktify.Repository.Configuration.Identity
{
    public class AppUserRoleConfig : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("BA796781-DD1E-4D24-B4B7-BFA191EA658A").ToString(),
                RoleId = Guid.Parse("16ED196E-D750-418B-886C-35F214BC7C59").ToString()
            }, new AppUserRole
            {
                UserId = Guid.Parse("CD06B166-2379-4BC0-9FD1-3E9F50C6C4B2").ToString(),
                RoleId = Guid.Parse("1CF42ED7-6CE9-43CE-A36C-97B03FAE641D").ToString()
            });
        }
    }
}
