using System;
using System.Collections.Generic;
using ArticleChallenge.Domain.Entities.Base;
using ArticleChallenge.Infra.CrossCutting.Exceptions;

namespace ArticleChallenge.Domain.Entities
{
    public class Article : BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Text { get; private set; }
        public long MountLikes { get; private set; }

        //NAVIGATION PROPERTIES
        public IList<ArticleLike> ArticleLikes { get; set; }

        public Article(long id, string title, string text, string description, long mountLikes)
        {
            Id = id;
            Title = title;
            Description = description;
            Text = text;
            MountLikes = mountLikes;

            Validate();
        }

        public bool Validate()
        {
            if (Id < 0)
                throw new DomainException("O ID está inválido.");

            if (string.IsNullOrEmpty(Title))
                throw new DomainException("O título não pode ser vazio.");

            if (string.IsNullOrEmpty(Text))
                throw new DomainException("O texto não pode ser vazio.");

            if (string.IsNullOrEmpty(Description))
                throw new DomainException("A descrição não pode ser vazia.");

            if (MountLikes < 0)
                throw new DomainException("A quantidade de likes não pode ser menor que zero");

            return true;
        }

        public void AddLike()
        {
            MountLikes += 1;
        }

        public void RemoveLike()
        {
            if(MountLikes <= 0)
                throw new DomainException("O número de likes não pode ser inferior a 0.");

            MountLikes -= 1;
        } 
    }
}
