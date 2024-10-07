namespace WebApplication1.Models;

public class Quiz
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public ICollection<TQuestion> Questions { get; set; }

    public Game Game { get; set; }
}
