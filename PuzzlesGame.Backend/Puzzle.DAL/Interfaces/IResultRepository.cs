using Puzzle.Models;

namespace Puzzle.DAL.Interfaces
{
    public interface IResultRepository : IBaseRepository<Result>
    {
        List<Result> GetUserResults(int userId);
        List<Result> GetBestResults();
        void SaveResult(Result result);
    }
}
