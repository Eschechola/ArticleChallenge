using ArticleChallenge.Domain.Entities.Base;
using ArticleChallenge.Infra.CrossCutting.Exceptions;
using System.Collections.Generic;

namespace ArticleChallenge.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        //NAVIGATION PROPERTIES
        public IList<ArticleLike> ArticleLikes { get; set; }


        protected User() { }

        public User(long id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;

            Validate();
        }

        public bool Validate()
        {
            if (Id < 0)
                throw new DomainException("O ID está inválido.");

            if (string.IsNullOrEmpty(Name))
                throw new DomainException("O nome não pode ser vazio.");

            if (string.IsNullOrEmpty(Email))
                throw new DomainException("O email não pode ser vazio.");

            if (string.IsNullOrEmpty(Password))
                throw new DomainException("A senha não pode ser vazia.");

            return true;
        }
    }
}
