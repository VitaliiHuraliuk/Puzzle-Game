using Puzzle.Models;

namespace Puzzle.Domain.Services
{
    public interface IUserService
    {
        void RegisterNewUser(User user);
        User Authenticate(string username, string password);
        List<User> GetUserId(int userId);
        User GetUserByLogin(string login);
    }
}
