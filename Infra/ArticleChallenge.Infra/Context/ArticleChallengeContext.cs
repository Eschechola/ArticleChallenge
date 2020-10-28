using Microsoft.EntityFrameworkCore;
using ArticleChallenge.Domain.Entities;
using ArticleChallenge.Infra.Mapping;

namespace ArticleChallenge.Infra.Context
{
    public class ArticleChallengeContext : DbContext
    {
        public ArticleChallengeContext() { }

        public ArticleChallengeContext(DbContextOptions<ArticleChallengeContext> options) : base(options)
        { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleLike> ArticleLikes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new ArticleMap());
            builder.ApplyConfiguration(new ArticleLikeMap());
        }
    }
}
