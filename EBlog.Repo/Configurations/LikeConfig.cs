using EBlog.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Repo.Configurations
{
    public class LikeConfig:BaseConfig<Like>
    {
        public override void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.AppUser).WithMany(x => x.Likes).HasForeignKey(x => x.AppUserId);

            builder.HasOne(x => x.Article).WithMany(x => x.Likes).HasForeignKey(x => x.ArticleId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
            base.Configure(builder);
        }
    }
}
