using System;
using System.Collections.Generic;

namespace Quiz.Server.Data
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Quizzes = new HashSet<Quiz>();
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public bool IsLoggedIn { get; set; }

        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}
