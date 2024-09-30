namespace QuizGameAPI.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string QuizName { get; set; } = "";
        public ICollection<Game> Games { get; set; } = new List<Game>();
        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
