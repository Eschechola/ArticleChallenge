using System.Threading.Tasks;
using System.Collections.Generic;
using ArticleChallenge.Services.DTO;

namespace ArticleChallenge.Services.Interfaces
{
    public interface IArticleService
    {
        Task<ArticleDTO> Create(ArticleDTO articleDTO);
        Task<ArticleDTO> Get(long id);
        Task<IList<ArticleDTO>> Get();
        Task<ArticleLikeDTO> GetLike(long userId, long articleId);
        Task<long> AddLike(ArticleLikeDTO articleLikeDTO);
        Task<long> RemoveLike(ArticleLikeDTO articleLikeDTO);
    }
}
