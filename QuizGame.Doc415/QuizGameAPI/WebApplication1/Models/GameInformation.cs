namespace WebApplication1.Models;

public class GameInformation
{
    public string GameId { get; set; }
    public string QuizId { get; set; }
    public string Date { get; set; }
    public ICollection<TQuestion> Questions { get; set; }
    public ICollection<TQuestion> WrongAnsweredQuestions { get; set; }
    public int Score { get { return 10 - (WrongAnsweredQuestions?.Count ?? 0); } }


}
