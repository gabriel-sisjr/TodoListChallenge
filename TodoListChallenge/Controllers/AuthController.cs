using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoListChallenge.Domain.Models;
using TodoListChallenge.Managers;

namespace TodoListChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly SignInManager<UserApp> _signInManager;
        private readonly ITokenManager _tokenManager;

        public AuthController(UserManager<UserApp> userManager,
           SignInManager<UserApp> signInManager,
           ITokenManager tokenManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenManager = tokenManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CredentialDTO userInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(userInfo.Username, userInfo.Password,
                 isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userInfo.Username);

                var token = _tokenManager.BuildToken(user!);
                return Ok(token);
            }

            return BadRequest();
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] UserDTO userDTO)
        {
            var userAlreadyExist = await _userManager.FindByEmailAsync(userDTO.Username);

            if (userAlreadyExist != null)
                return BadRequest("Email Invalido!");

            var appUser = userDTO.ToEntityUser();
            var result = await _userManager.CreateAsync(appUser, userDTO.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            var user = await _userManager.FindByNameAsync(userDTO.Username);
            var token = _tokenManager.BuildToken(user!);
            return Ok(token);
        }
    }
}
