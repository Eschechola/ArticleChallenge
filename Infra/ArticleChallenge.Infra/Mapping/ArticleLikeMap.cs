using Microsoft.EntityFrameworkCore;
using ArticleChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArticleChallenge.Infra.Mapping
{
    public class ArticleLikeMap : IEntityTypeConfiguration<ArticleLike>
    {
        public void Configure(EntityTypeBuilder<ArticleLike> builder)
        {
            builder.ToTable("article_x_like", "dbo");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(a => a.ArticleId)
                .IsRequired()
                .HasColumnType("BIGINT")
                .HasColumnName("fk_article_id");

            builder.Property(a => a.UserId)
                .IsRequired()
                .HasColumnType("BIGINT")
                .HasColumnName("fk_user_id");   
        }
    }
}
