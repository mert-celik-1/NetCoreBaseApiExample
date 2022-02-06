using BaseProject.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Data.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Content).IsRequired();
            builder.Property(a => a.Content).HasMaxLength(50);
            builder.Property(a => a.Title).IsRequired();
            builder.Property(a => a.Title).HasMaxLength(250);
            builder.Property(a => a.IsActive).IsRequired();

            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a => a.CategoryId);
            builder.HasOne<User>(a => a.User).WithMany(u => u.Articles).HasForeignKey(a => a.UserId);

            builder.ToTable("Articles");

            builder.HasData(

                new Article { Id = Guid.NewGuid().ToString(), Title = "Article", Content = "Test", IsActive = true },
                new Article { Id = Guid.NewGuid().ToString(), Title = "Article2", Content = "Test2", IsActive = true }
                        
            );
        }
    }
}
