namespace Quiz.Server.Data
{
    public class QuestionQuiz
    {
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public int QuizId { get; set; }

        public virtual Quiz Quiz { get; set; }
    }
}
