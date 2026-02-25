using Checktify.Entity.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Repository.Configuration.WebApplication
{
    public class AttendanceConfig : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.Property(x => x.CreatedDate).HasMaxLength(10).IsRequired();
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.HasOne(x => x.CheckInOfficeLocation)
               .WithMany()
               .HasForeignKey(x => x.CheckInOfficeLocationId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.CheckOutOfficeLocation)
                   .WithMany()
                   .HasForeignKey(x => x.CheckOutOfficeLocationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Company)
               .WithMany()
               .HasForeignKey(x => x.CompanyId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.User)
                   .WithMany()
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
