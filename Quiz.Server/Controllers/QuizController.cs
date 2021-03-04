using Microsoft.AspNetCore.Mvc;
using Quiz.Server.Services;
using Quiz.Server.ViewModels;
using System.Threading.Tasks;

namespace Quiz.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService quizService;

        public QuizController(IQuizService quizService)
        {
            this.quizService = quizService;
        }

        [HttpGet("{quizId}")]
        public async Task<QuizViewModel> GetById(int quizId)
        {
            return await this.quizService.GetAsync(quizId); 
        }

        [HttpPost]
        public async Task<IActionResult> Create(string userId)
        {
            var quizId = await this.quizService.CreateAsync(userId);

            return Created(nameof(this.Create), quizId);
        }

        [HttpPatch]
        public QuizCheckResponse Check([FromBody] QuizCheckRequest quizCheck)
        {
            return this.quizService.Check(quizCheck.Id, quizCheck.Selections);
        }
    }
}
