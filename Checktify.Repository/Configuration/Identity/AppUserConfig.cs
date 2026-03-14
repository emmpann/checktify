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
            //    var admin = new AppUser
            //    {
            //        Id = Guid.Parse("BA796781-DD1E-4D24-B4B7-BFA191EA658A").ToString(),
            //        UserName = "admin",
            //        NormalizedUserName = "ADMIN",
            //        Email = "efant@gmail.com",
            //        NormalizedEmail = "EFANT@GMAIL.COM",
            //        ConcurrencyStamp = Guid.NewGuid().ToString(),
            //        SecurityStamp = Guid.NewGuid().ToString(),
            //    };
            //    var adminPasswordHash = PasswordHasher(admin, "Admin123@");
            //    admin.PasswordHash = adminPasswordHash;
            //    builder.HasData(admin);

            //    var user = new AppUser
            //    {
            //        Id = Guid.Parse("CD06B166-2379-4BC0-9FD1-3E9F50C6C4B2").ToString(),
            //        UserName = "user",
            //        NormalizedUserName = "USER",
            //        Email = "efant2@gmail.com",
            //        NormalizedEmail = "EFANT2@GMAIL.COM",
            //        ConcurrencyStamp = Guid.NewGuid().ToString(),
            //        SecurityStamp = Guid.NewGuid().ToString(),
            //    };
            //    var userPasswordHash = PasswordHasher(user, "User123@");
            //    user.PasswordHash = userPasswordHash;
            //    builder.HasData(user);
        }

        //private string PasswordHasher(AppUser user, string password)
        //{
        //    var hasher = new PasswordHasher<AppUser>();
        //    return hasher.HashPassword(user, password);
        //}
    }
}
