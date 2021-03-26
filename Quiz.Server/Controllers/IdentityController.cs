using Microsoft.AspNetCore.Mvc;
using Quiz.Server.Services;
using Quiz.Server.ViewModels;
using System.Threading.Tasks;

namespace Quiz.Server.Controllers
{
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService identityService;

        public IdentityController(IIdentityService identityService)
        {
            this.identityService = identityService;
        }

        [HttpPost("identity/login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var response = await this.identityService.LoginAsync(request.Username);
            if (response.Id != string.Empty)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPatch("identity/logout")]
        public async Task Logout(UserRequest request)
        {
            await this.identityService.LogoutAsync(request.UserId);
        }
    }
}
