using JWTWebApiCore.Helper;
using JWTWebApiCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace JWTWebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            LoginHelper loginHelper = new LoginHelper(_config);
            var user = loginHelper.Authenticate(userLogin);

            if (user != null)
            {
                var token = loginHelper.Generate(user);
                return Ok(token);
            }

            return NotFound("User not found");
        }


    }
}