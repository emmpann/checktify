using Checktify.Entity.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Repository.Configuration
{
    public class WorkScheduleConfig : IEntityTypeConfiguration<WorkSchedule>
    {
        void IEntityTypeConfiguration<WorkSchedule>.Configure(EntityTypeBuilder<WorkSchedule> builder)
        {
            builder.Property(x => x.CreatedDate).HasMaxLength(10).IsRequired();
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();
        }
    }
}
