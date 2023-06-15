using Puzzle.Models;

namespace Puzzle.Domain.Services
{
    public interface IResultService
    {
        List<Result> GetUserResults(int userId);
        List<Result> GetBestResults();
        void SaveResult(Result result);
    }
}
