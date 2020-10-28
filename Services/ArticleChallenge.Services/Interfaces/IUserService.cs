using System.Threading.Tasks;
using ArticleChallenge.Services.DTO;

namespace ArticleChallenge.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Create(UserDTO user);
        Task<UserDTO> Update(UserDTO user);
        Task<UserDTO> Get(long id);
        Task<UserDTO> GetByEmail(string email);
        Task<bool> Authenticate(string email, string password);
    }
}
