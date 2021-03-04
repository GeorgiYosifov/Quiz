using Microsoft.EntityFrameworkCore;

namespace Quiz.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<History> Histories { get; set; }

        public DbSet<Selection> Selections { get; set; }

        public DbSet<Quiz> Quizzes { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<QuestionQuiz> QuestionQuizzes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<QuestionQuiz>(builder =>
                {
                    builder.HasKey(qq => new { qq.QuestionId, qq.QuizId });
                    builder.ToTable("QuestionQuizzes");
                });

            base.OnModelCreating(builder);
        }
    }
}
