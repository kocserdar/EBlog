﻿using EBlog.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            base.Configure(builder);
        }
    }
}
