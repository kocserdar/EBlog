﻿using EBlog.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Repo.Configurations
{
    public class ArticleConfig:BaseConfig<Article>
    {
        public override void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Content).IsRequired();

            builder.HasOne(x => x.AppUser).WithMany(x => x.Articles).HasForeignKey(x => x.AppUserId);
            builder.HasOne(x => x.Genre).WithMany(x => x.Articles).HasForeignKey(x => x.GenreId);
            base.Configure(builder);
        }
    }
}
