using Puzzle.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Puzzle.Models;
using Microsoft.AspNetCore.Cors;

namespace PuzzlesGame.API.Controllers
{
    [Route("[controller]")]

    public class UsersController : ControllerBase
    {
        private IUserService _usersService { get; set; }

        public UsersController(IUserService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("get-user/{userId}")]
        public IActionResult GetByUserId(int userId)
        {
            var users = _usersService.GetUserId(userId);
            return users == null || users.Count == 0 ? NotFound() : Ok(users);
        }

        [HttpPost("register-user")]
        public IActionResult AddNewUser([FromBody] User user)
        {
            try
            {
                var existingUser = _usersService.GetUserByLogin(user.Login);
                if (existingUser != null)
                {
                    return BadRequest("User already exists.");
                }

                _usersService.RegisterNewUser(user);

                return Ok("User " + user.Login + " created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost("login-user")]
        public IActionResult Login([FromBody] User user)
        {
            var authenticatedUser = _usersService.Authenticate(user.Login, user.Password);

            if (authenticatedUser != null)
            {
                return Ok("Login successful");
            }

            return BadRequest("Invalid username or password");
        }
    }   
}