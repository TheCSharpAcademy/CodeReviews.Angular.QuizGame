namespace QuizGameAPI.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuizQuestion { get; set; } = "";
        public string Answer1 { get; set; } = "";
        public string Answer2 { get; set; } = "";
        public string Answer3 { get; set; } = "";
        public string CorrectAnswer { get; set; } = "";
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; } = null!;
    }
}
