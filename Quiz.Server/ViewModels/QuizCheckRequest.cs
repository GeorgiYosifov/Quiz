using System.Collections.Generic;

namespace Quiz.Server.ViewModels
{
    public class QuizCheckRequest
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public ICollection<UserSelection> Selections { get; set; }
    }
}
