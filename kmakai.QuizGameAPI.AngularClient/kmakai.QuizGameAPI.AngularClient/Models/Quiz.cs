namespace kmakai.QuizGameAPI.AngularClient.Models;

public class Quiz
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<Question> Questions { get; set; } = null!;
    public ICollection<Game> Games { get; set; } = null!;
  
}
