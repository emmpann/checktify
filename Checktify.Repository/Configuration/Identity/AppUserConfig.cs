using Checktify.Entity.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Repository.Configuration.Identity
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            //builder.Property(x => x.RowVersion).IsRowVersion();
        }
    }
}
