using Microsoft.EntityFrameworkCore;
using Puzzle.DAL.Interfaces;
using Puzzle.Models;

namespace Puzzle.DAL.Repositories
{

    public class ResultRepository : IResultRepository
       
    {
        private readonly PuzzleDbContext _dbContext;

        public ResultRepository(PuzzleDbContext dbContext)
        {
         _dbContext = dbContext;
        }

        public List<Result> GetUserResults(int userId)
        {
            return _dbContext.Result.Where(r => r.UserId == userId).ToList();
        }
        public List<Result> GetBestResults()
        {
            return _dbContext.Result.OrderBy(r => r.TimeTaken).ThenBy(r => r.MovesCount).ToList();
        }

        public void SaveResult(Result result)
        {
            _dbContext.Result.Add(result);
            _dbContext.SaveChanges();
         }

        public void Create(Result item)
        {
            _dbContext.Result.Add(item);
        }

        public void Update(Result item)
        {
            _dbContext.Entry(item).State = EntityState.Modified; ;
        }

        public void Delete(int id)
        {
            Result result = _dbContext.Result.Find(id);
            if (result != null)
                _dbContext.Result.Remove(result);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
    }

