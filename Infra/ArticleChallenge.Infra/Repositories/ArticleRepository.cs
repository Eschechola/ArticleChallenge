using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using ArticleChallenge.Domain.Entities;
using ArticleChallenge.Infra.Interfaces;
using ArticleChallenge.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ArticleChallenge.Infra.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ArticleChallengeContext _context;

        public ArticleRepository(ArticleChallengeContext context)
        {
            _context = context;
        }

        public async Task<Article> Create(Article article)
        {
            await _context.AddAsync(article);
            await _context.SaveChangesAsync();

            return article;
        }

        public async Task<Article> Update(Article article)
        {
            _context.Articles.Update(article);
            await _context.SaveChangesAsync();

            return article;
        }

        public async Task<Article> Get(long id)
        {
            var article = await _context.Articles
                          .AsNoTracking()
                          .Where(x => x.Id == id)
                          .FirstOrDefaultAsync();

            return article;
        }

        public async Task<IList<Article>> Get()
        {
            return await _context.Articles
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddLike(ArticleLike articleLike)
        {
            await _context.ArticleLikes.AddAsync(articleLike);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveLike(ArticleLike articleLike)
        {
            var like = await _context.ArticleLikes
                                     .Where(
                                            x =>
                                                x.UserId == articleLike.UserId &&
                                                x.ArticleId == articleLike.ArticleId
                                     )
                                     .FirstOrDefaultAsync();

            _context.Remove(like);
            await _context.SaveChangesAsync();
        }

        public async Task<ArticleLike> GetLike(long articleId, long userId)
        {
            var like = await _context.ArticleLikes
                                      .Where(
                                             x =>
                                                 x.UserId == userId &&
                                                 x.ArticleId == articleId
                                      )
                                      .FirstOrDefaultAsync();
            return like;
        }
    }
}
