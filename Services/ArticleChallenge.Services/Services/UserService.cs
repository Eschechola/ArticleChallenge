using AutoMapper;
using System.Threading.Tasks;
using ArticleChallenge.Services.DTO;
using ArticleChallenge.Infra.Interfaces;
using ArticleChallenge.Services.Interfaces;
using ArticleChallenge.Domain.Entities;

namespace ArticleChallenge.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userInserted = await _userRepository.Create(user);

            return _mapper.Map<UserDTO>(userInserted);
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userInserted = await _userRepository.Update(user);

            return _mapper.Map<UserDTO>(userInserted);
        }

        public async Task<UserDTO> Get(long id)
        {
            var user = await _userRepository.Get(id);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var user = await _userRepository.GetByEmail(email);

            if (user is null)
                return false;

            return user.Password == password;
        }
    }
}
