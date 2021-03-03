using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz.Server.Data
{
    public class Category
    {
        public Category()
        {
            this.Questions = new HashSet<Question>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
