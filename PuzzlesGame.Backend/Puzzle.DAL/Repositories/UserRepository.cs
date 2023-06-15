using Microsoft.EntityFrameworkCore;
using Puzzle.DAL.Interfaces;
using Puzzle.Models;

namespace Puzzle.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private PuzzleDbContext db;
        public UserRepository()
        {
            db = new PuzzleDbContext();
        }
        public IEnumerable<User> GetUserList()
        {
            return db.User;
        }
        public User GetUser(int id)
        {
            return db.User.Find(id);
        }
        public void Create(User user)
        {
            db.User.Add(user);
            db.SaveChanges();
        }
        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }
        public IEnumerable<User> Select()
        {
            return db.User;
        }
        public void Delete(int id)
        {
            User user = db.User.Find(id);
            if (user != null)
                db.User.Remove(user);
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public User GetByLogin(string login)
        {
            return db.User.FirstOrDefault(u => u.Login == login);
        }
        public User GetByData(string login, string password)
        {
            return db.User.FirstOrDefault(u => u.Login == login && u.Password == password);
        }
        public List<User> GetUserId(int userId)
        {
            return db.User.Where(x => x.Id == userId).ToList();
        }

        public User Authenticate(string username, string password)
        {
            return db.User.SingleOrDefault(x => x.Login == username && x.Password == password);
        }
    }
}
    
  

