using Puzzle.Models;

namespace Puzzle.DAL.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetByLogin(string login);
        User GetByData(string login, string password);
        public List<User> GetUserId(int userId);
        User Authenticate(string username, string password);
    }
}
