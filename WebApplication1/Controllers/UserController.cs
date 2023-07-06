using Microsoft.AspNetCore.Mvc;

using WebApplication1.Entity;
using WebApplication1.Logging;
using WebApplication1.Managers;
using WebApplication1.Models;
using WebApplication1.Repositary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAccountManager _accountManager;

        public UserController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserModel userRegisterModel)
        {
            User registeredUser = await _accountManager.RegisterUserAsync(userRegisterModel).ConfigureAwait(false);

            return Ok(registeredUser);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUserModel userLoginModel)
        {
            User loggedInUser = await _accountManager.LoginUserAsync(userLoginModel).ConfigureAwait(false);

            if (loggedInUser == null)
            {
                return BadRequest("Invalid username or password");
            }

            return Ok(loggedInUser);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            User user = await _accountManager.GetUserByIdAsync(id).ConfigureAwait(false);

            if (user == null)
            {
                return NotFound();
            }


            return Ok(user);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            IEnumerable<User> users = await _accountManager.GetAllUsersAsync().ConfigureAwait(false);

            return Ok(users);
        }
    }
}
