using System;
using ArticleChallenge.Domain.Entities.Base;
using ArticleChallenge.Infra.CrossCutting.Exceptions;

namespace ArticleChallenge.Domain.Entities
{
    public class ArticleLike : BaseEntity
    {
        public long ArticleId { get; private set; }
        public long UserId { get; private set; }

        //NAVIGATION PROPERTIES
        public User User { get; set; }
        public Article Article { get; set; }

        public ArticleLike(long id, long articleId, long userId)
        {
            Id = id;
            ArticleId = articleId;
            UserId = userId;
        }

        public bool Validate()
        {
            if (Id < 0)
                throw new DomainException("O ID está inválido.");

            if (ArticleId < 0)
                throw new DomainException("O ID do artigo está inválido.");

            if (UserId < 0)
                throw new DomainException("O ID do usuário está inválido.");

            return true;
        }
    }
}
