namespace QuizGameAPI.Models
{
    public class CreateGameDTO
    {
        public string PlayerName { get; set; }
        public int TotalAmountOfQuestions { get; set; }
        public int CorrectAmountOfAnswers { get; set; }
        public int QuizId { get; set; }
    }
}
