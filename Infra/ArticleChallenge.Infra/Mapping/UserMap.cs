using Microsoft.EntityFrameworkCore;
using ArticleChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArticleChallenge.Infra.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user", "dbo");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            // 1 : N => Like : Usuários
            builder.HasMany(a => a.ArticleLikes)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnType("VARCHAR(80)")
                .HasColumnName("name");

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("password");

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(180)
                .HasColumnType("VARCHAR(180)")
                .HasColumnName("email");
        }
    }
}
