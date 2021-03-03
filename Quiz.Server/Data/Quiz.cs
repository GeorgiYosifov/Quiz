using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Server.Data
{
    public class Quiz
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
