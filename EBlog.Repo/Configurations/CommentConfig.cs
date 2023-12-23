using EBlog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Repo.Configurations
{
    public class CommentConfig:BaseConfig<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Text).IsRequired(true);

            builder.HasOne(x => x.AppUser).WithMany(x => x.Comments).HasForeignKey(x => x.AppUserId);

            builder.HasOne(x => x.Article).WithMany(x => x.Comments).HasForeignKey(x => x.ArticleId).OnDelete(DeleteBehavior.NoAction);
            
            base.Configure(builder);
        }
    }
}
