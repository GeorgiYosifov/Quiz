using Quiz.Server.ViewModels;
using System.Threading.Tasks;

namespace Quiz.Server.Services
{
    public interface IIdentityService
    {
        Task<UserLoginResponse> LoginAsync(string username);
    }
}
