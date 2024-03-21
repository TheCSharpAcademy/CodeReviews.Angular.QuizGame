namespace kmakai.QuizGameAPI.AngularClient.Models;

public class Quiz
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public List<Question>? Questions { get; set; } 
    public List<Game>? Games { get; set; } 
  
}
