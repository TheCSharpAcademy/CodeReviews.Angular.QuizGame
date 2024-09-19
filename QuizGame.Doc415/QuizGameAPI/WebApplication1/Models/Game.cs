namespace WebApplication1.Models;

public class Game
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Date { get; set; }
    public List<TQuestion> WrongAnsweredQuestions { get; set; }
    public string QuizId { get; set; }
    public Quiz Quiz { get; set; }

}
