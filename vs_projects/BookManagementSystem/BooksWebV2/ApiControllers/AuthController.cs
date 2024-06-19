using BooksWebV2.Models;
using BooksWebV2.Services;
using ConceptArchitect.BookManagement;
using ConceptArchitect.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BooksWebV2.ApiControllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        public AuthController(ITokenService tokenService,IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            try
            {
                var user = await _userService.GetUserById(loginModel.Email);
                if (user.Password != loginModel.Password)
                    throw new InvalidCredentialsException("Invalid Credentials");

                
                var token=_tokenService.GenerateToken(user);

                

                return Ok(new { token = token, user = user.CopyTo<UserInfo>("Password") });
            }
            catch(Exception ex)
            {
                return Unauthorized();
            }

        }
    }

}
