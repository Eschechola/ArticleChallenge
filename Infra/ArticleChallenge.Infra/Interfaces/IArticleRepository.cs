using System.Threading.Tasks;
using System.Collections.Generic;
using ArticleChallenge.Domain.Entities;

namespace ArticleChallenge.Infra.Interfaces
{
    public interface IArticleRepository
    {
        Task<Article> Create(Article article);
        Task<Article> Update(Article article);
        Task<Article> Get(long id);
        Task<IList<Article>> Get();

        Task AddLike(ArticleLike articleLike);
        Task RemoveLike(ArticleLike articleLike);
        Task<ArticleLike> GetLike(long articleId, long userId);
    }
}
