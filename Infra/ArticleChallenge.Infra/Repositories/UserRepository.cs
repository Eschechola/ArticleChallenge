using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ArticleChallenge.Infra.Context;
using ArticleChallenge.Domain.Entities;
using ArticleChallenge.Infra.Interfaces;

namespace ArticleChallenge.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ArticleChallengeContext _context;

        public UserRepository(ArticleChallengeContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> Update(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> Get(long id)
        {
            var article = await _context.Users
                          .AsNoTracking()
                          .Where(x => x.Id == id)
                          .FirstOrDefaultAsync();

            return article;
        }

        public async Task<User> GetByEmail(string email)
        {
            var article = await _context.Users
                          .AsNoTracking()
                          .Where(x => x.Email.ToLower() == email.ToLower())
                          .FirstOrDefaultAsync();

            return article;
        }
    }
}
