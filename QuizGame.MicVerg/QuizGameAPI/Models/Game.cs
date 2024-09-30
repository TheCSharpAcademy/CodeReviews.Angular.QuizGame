namespace QuizGameAPI.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string PlayerName { get; set; } = "";
        public int TotalAmountOfQuestions { get; set; }
        public int CorrectAmountOfQuestions { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; } = null!;
    }
}
