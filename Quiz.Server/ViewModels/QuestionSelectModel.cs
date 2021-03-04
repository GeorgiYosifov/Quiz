using System.Collections.Generic;

namespace Quiz.Server.ViewModels
{
    public class QuestionSelectModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<AnswerSelectModel> Answers { get; set; }
    }
}
