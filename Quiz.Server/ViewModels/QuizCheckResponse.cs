namespace Quiz.Server.ViewModels
{
    public class QuizCheckResponse
    {
        public int Correct { get; set; }

        public int Wrong { get; set; }

        public int Unselected { get; set; }
    }
}
