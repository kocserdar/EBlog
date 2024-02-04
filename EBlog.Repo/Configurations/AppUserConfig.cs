using EBlog.Core.Entities;
using EBlog.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EBlog.Repo.Configurations
{
    public class AppUserConfig:BaseConfig<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.UserName).IsRequired(true);
            builder.Property(e => e.FirstName).IsRequired(false);
            builder.Property(e => e.LastName).IsRequired(false);
            builder.Property(e => e.ImagePath).IsRequired(false);
            //builder.Property(e => e.AccessFailedCount).HasDefaultValue(0);
            //builder.Property(e => e.EmailConfirmed).HasDefaultValue(false);
            //builder.Property(e => e.LockoutEnabled).HasDefaultValue(false);
            //builder.Property(e => e.PhoneNumberConfirmed).HasDefaultValue(false);
            //builder.Property(e => e.TwoFactorEnabled).HasDefaultValue(false);
            //builder.Property(e => e.Status).HasDefaultValue(Status.Active);

            //builder.HasData(new IdentityRole
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Name = "Admin",
            //    NormalizedName = "ADMIN",
            //    ConcurrencyStamp = Guid.NewGuid().ToString(),
            //},
            //new IdentityRole
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Name = "Normal",
            //    NormalizedName = "NORMAL",
            //    ConcurrencyStamp = Guid.NewGuid().ToString()
            //}
            //);

            //Created Time
            builder.Property(e => e.CreatedAt).HasDefaultValue(DateTime.Now);

            base.Configure(builder);
        }

    }
}
