using Quiz.Server.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz.Server.Services
{
    public interface IQuizService
    {
        Task<QuizViewModel> GetAsync(int quizId);

        Task<int> CreateAsync(string userId);

        QuizCheckResponse Check(int quizId, ICollection<UserSelection> selections);
    }
}
