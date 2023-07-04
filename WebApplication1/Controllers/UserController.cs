using Microsoft.AspNetCore.Mvc;

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
        private readonly IUserRepositary _userRepository;
        private readonly IAccountManager _accountManager;

        public UserController(IUserRepositary userRepository, IAccountManager accountManager)
        {
            _userRepository = userRepository;
            _accountManager = accountManager;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUserModel userRegisterModel)
        {
            // Register the user using the account manager
            User registeredUser = await _accountManager.RegisterUserAsync(userRegisterModel);

            // Return the registered user
            return Ok(registeredUser);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUserModel userLoginModel)
        {
            // Login the user using the account manager
            User loggedInUser = await _accountManager.LoginUserAsync(userLoginModel);

            if (loggedInUser == null)
            {
                // User login failed
                return BadRequest("Invalid username or password");
            }

            // User login successful
            return Ok(loggedInUser);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            // Get the user by ID from the repository
            User user = await _userRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                // User not found
                return NotFound();
            }

            // Return the user
            return Ok(user);
        }
    }
}
