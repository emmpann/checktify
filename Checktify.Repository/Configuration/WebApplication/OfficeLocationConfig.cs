using Checktify.Entity.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Repository.Configuration.WebApplication
{
    public class OfficeLocationConfig : IEntityTypeConfiguration<OfficeLocation>
    {
        public void Configure(EntityTypeBuilder<OfficeLocation> builder)
        {
            builder.Property(x => x.CreatedDate).HasMaxLength(10).IsRequired();
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();
            builder.Property(x => x.Longitude).HasColumnType("decimal(18,8)");
            builder.Property(x => x.Latitude).HasColumnType("decimal(18,8)");
            builder.HasIndex(x => x.Code).IsUnique();
        }
    }
}
