using Puzzle.DAL;
using Puzzle.Models;

namespace Puzzle.Domain.Services
{
    public class ResultService : IResultService
    {
        private readonly PuzzleDbContext _dbContext;

        public ResultService(PuzzleDbContext dbContext)
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
    }
}
