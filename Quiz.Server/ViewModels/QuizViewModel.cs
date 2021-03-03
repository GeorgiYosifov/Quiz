using System.Collections.Generic;

namespace Quiz.Server.ViewModels
{
    public class QuizViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public ICollection<QuestionViewModel> Questions { get; set; }
    }
}
