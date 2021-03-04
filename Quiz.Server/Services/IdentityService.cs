using Quiz.Server.Data;
using Quiz.Server.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Server.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly DataContext db;

        public IdentityService(DataContext db)
        {
            this.db = db;
        }

        public async Task<UserLoginResponse> LoginAsync(string username)
        {
            var user = this.db.Users.FirstOrDefault(u => u.Username == username);

            if (user != null && user.IsLoggedIn)
            {
                return new UserLoginResponse
                {
                    Text = "Try later, a user with this username is already logged in!"
                };
            }
            else
            {
                await this.db.Users.AddAsync(new User()
                {
                    Username = username,
                    IsLoggedIn = true
                });
                await this.db.SaveChangesAsync();
            }

            user = this.db.Users.FirstOrDefault(u => u.Username == username);

            return new UserLoginResponse
            {
                Id = user.Id,
                Username = user.Username,
                Text = "You are in!"
            };
        }
    }
}
