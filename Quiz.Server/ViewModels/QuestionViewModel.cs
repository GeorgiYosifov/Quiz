using System.Collections.Generic;

namespace Quiz.Server.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public ICollection<AnswerViewModel> Answers { get; set; }
    }
}
