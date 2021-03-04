using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Server.Data
{
    public class History
    {
        public History()
        {
            this.Selections = new HashSet<Selection>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("null")]
        public int QuizId { get; set; }

        public virtual ICollection<Selection> Selections { get; set; }
    }
}
