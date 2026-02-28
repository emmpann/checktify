using Checktify.Entity.Identity.Entities;
using Checktify.Entity.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Repository.Configuration.WebApplication
{
    public class UserConfig : IEntityTypeConfiguration<AppUser>
    {
        void IEntityTypeConfiguration<AppUser>.Configure(EntityTypeBuilder<AppUser> builder)
        {
            //builder.Property(x => x.CreatedDate).HasMaxLength(10).IsRequired();
            //builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            //builder.Property(x => x.RowVersion).IsRowVersion();
        }
    }
}
