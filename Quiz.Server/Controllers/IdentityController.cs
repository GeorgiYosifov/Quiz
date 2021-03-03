using Microsoft.AspNetCore.Mvc;
using Quiz.Server.Data;
using Quiz.Server.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Server.Controllers
{
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly DataContext db;

        public IdentityController(DataContext db)
        {
            this.db = db;
        }

        [HttpPost("identity/login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var user = this.db.Users.FirstOrDefault(u => u.Username == request.Username);

            if (user != null && user.IsLoggedIn)
            {
                return BadRequest(new UserLoginResponse
                {
                    Text = "Try later, a user with this username is already logged in!"
                });
            }
            else
            {
                await this.db.Users.AddAsync(new User()
                {
                    Username = request.Username,
                    IsLoggedIn = true
                });
                await this.db.SaveChangesAsync();
            }

            user = this.db.Users.FirstOrDefault(u => u.Username == request.Username);

            return Ok(new UserLoginResponse
            {
                Id = user.Id,
                Username = user.Username, 
                Text = "You are in!"
            });
        }
    }
}
