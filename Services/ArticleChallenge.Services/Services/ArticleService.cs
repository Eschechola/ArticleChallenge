using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using ArticleChallenge.Domain.Entities;
using ArticleChallenge.Services.Interfaces;
using ArticleChallenge.Infra.Interfaces;
using ArticleChallenge.Infra.CrossCutting.Exceptions;
using ArticleChallenge.Services.DTO;

namespace ArticleChallenge.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IMapper _mapper; 
        private readonly IUserRepository _userRepository;
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IMapper mapper, IUserRepository userRepository, IArticleRepository articleRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _articleRepository = articleRepository;
        }

        public async Task<ArticleDTO> Create(ArticleDTO articleDTO)
        {
            var article = _mapper.Map<Article>(articleDTO);
            article.Validate();

            var articleInserted = await _articleRepository.Create(article);

            return _mapper.Map<ArticleDTO>(articleInserted);
        }

        public async Task<ArticleDTO> Get(long id)
        {
            var article = await _articleRepository.Get(id);

            return _mapper.Map<ArticleDTO>(article);
        }

        public async Task<IList<ArticleDTO>> Get()
        {
            var allArticles = await _articleRepository.Get();

            return _mapper.Map<IList<ArticleDTO>>(allArticles);
        }

        public async Task<long> AddLike(ArticleLikeDTO articleLikeDTO)
        {
            var article = await _articleRepository.Get(articleLikeDTO.ArticleId);

            if (article is null)
                throw new DomainException("Artigo não encontrado.");

            var user = await _userRepository.Get(articleLikeDTO.UserId);

            if(user is null)
                throw new DomainException("Usuário não encontrado.");

            var like = await _articleRepository.GetLike(articleLikeDTO.ArticleId, articleLikeDTO.UserId);

            if(like != null)
                throw new DomainException("Usuário já deixou o like neste artigo.");


            article.AddLike();
            await _articleRepository.Update(article);

            var articleLike = _mapper.Map<ArticleLike>(articleLikeDTO);
            await _articleRepository.AddLike(articleLike);

            return article.MountLikes;
        }

        public async Task<long> RemoveLike(ArticleLikeDTO articleLikeDTO)
        {
            var article = await _articleRepository.Get(articleLikeDTO.ArticleId);

            if (article is null)
                throw new DomainException("Artigo não encontrado.");

            var user = await _userRepository.Get(articleLikeDTO.UserId);

            if (user is null)
                throw new DomainException("Usuário não encontrado.");


            article.RemoveLike();
            await _articleRepository.Update(article);

            var articleLike = _mapper.Map<ArticleLike>(articleLikeDTO);
            await _articleRepository.RemoveLike(articleLike);

            return article.MountLikes;
        }
    }
}
