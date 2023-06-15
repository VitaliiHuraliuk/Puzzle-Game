using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Puzzle.Domain.Services;
using Puzzle.Models;

namespace PuzzlesGame.API.Controllers
{
    [Route("api/results")]
    
    public class ResultController : ControllerBase
    {
        private readonly IResultService _resultService;

        public ResultController(IResultService resultService)
        {
            _resultService = resultService;
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetUserResults(int userId)
        {
            var results = _resultService.GetUserResults(userId);
            return Ok(results);
        }

        [HttpGet("best")]
        public IActionResult GetBestResults()
        {
            var results = _resultService.GetBestResults();
            return Ok(results);
        }

        [HttpPost]
        public IActionResult SaveResult([FromBody] Result result)
        {
            _resultService.SaveResult(result);
            return Ok();
        }
    }
}
