using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Server.Data
{
    public class Question
    {
        public Question()
        {
            this.Answers = new HashSet<Answer>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
