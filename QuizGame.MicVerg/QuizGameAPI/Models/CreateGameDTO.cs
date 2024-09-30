namespace QuizGameAPI.Models
{
    public class CreateGameDTO
    {
        public string PlayerName { get; set; } = string.Empty;
        public int TotalAmountOfQuestions { get; set; }
        public int CorrectAmountOfQuestions { get; set; }
        public int QuizId { get; set; }
    }
}
