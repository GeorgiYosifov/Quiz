using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Server.Data
{
    public class Selection
    {
        public int Id { get; set; }

        public int HistoryId { get; set; }

        public virtual History History { get; set; }

        [ForeignKey("null")]
        public int QuestionId { get; set; }

        [ForeignKey("null")]
        public int AnswerId { get; set; }
    }
}
