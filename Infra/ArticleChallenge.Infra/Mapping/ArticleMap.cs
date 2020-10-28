using Microsoft.EntityFrameworkCore;
using ArticleChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArticleChallenge.Infra.Mapping
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("article", "dbo");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            // 1 : N => Like : Artigo
            builder.HasMany(a => a.ArticleLikes)
                .WithOne(u => u.Article)
                .HasForeignKey(u => u.ArticleId);

            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("VARCHAR(100)")
                .HasColumnName("title");

            builder.Property(a => a.Text)
                .IsRequired()
                .HasMaxLength(8000)
                .HasColumnName("VARCHAR(MAX)")
                .HasColumnName("text");

            builder.Property(a => a.MountLikes)
                .IsRequired()
                .HasColumnName("BIGINT")
                .HasColumnName("mount_likes");
        }
    }
}
