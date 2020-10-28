using System.Threading.Tasks;
using ArticleChallenge.Domain.Entities;

namespace ArticleChallenge.Infra.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User> Update(User user);
        Task<User> Get(long id);
        Task<User> GetByEmail(string email);
    }
}
