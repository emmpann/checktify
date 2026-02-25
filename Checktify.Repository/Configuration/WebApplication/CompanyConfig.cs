using Checktify.Entity.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Repository.Configuration.WebApplication
{
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Company> builder)
        {
            builder.Property(x => x.CreatedDate).HasMaxLength(10).IsRequired();
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.HasIndex(x => x.Code).IsUnique();
        }
    }
}
