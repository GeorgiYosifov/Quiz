using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Server.Data
{
    public class Answer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Content { get; set; }

        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
