using Puzzle.DAL;
using Puzzle.DAL.Interfaces;
using Puzzle.Models;

namespace Puzzle.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly PuzzleDbContext _dbContext;

        private IUserRepository _userRepository;
        public UserService(IUserRepository usersRepository)
        {
            _userRepository = usersRepository;
        }

        public List<User> GetUserId(int userId)
        {
            return _userRepository.GetUserId(userId);
        }

        public void RegisterNewUser(User user)
        {
            var userFromDb = _userRepository.GetByLogin(user.Login);

            if (userFromDb != null)
            {
                throw new Exception("User with name " + user.Login + " already exists");
            }

            if (user.Password.Length < 4)
            {
                throw new Exception("Password is too short");
            }

            _userRepository.Create(user);
        }
        public User Authenticate(string username, string password)
        {
            var user = _userRepository.GetByLogin(username);

            if (user != null && user.Password == password)
            {
                return user;
            }

            return null;
        }

        public User GetUserByLogin(string login)
        {
            return _userRepository.GetByLogin(login);
        }
    }
}

