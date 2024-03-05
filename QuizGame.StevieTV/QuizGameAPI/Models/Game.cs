namespace QuizGameAPI.Models;

public class Game
{
    public int GameId { get; set; }

    public string PlayerName { get; set; } = "";

    public int Score { get; set; }
    public int PotentialTotal { get; set; }

    public int QuizId { get; set; }    
    public Quiz CurrentQuiz { get; set; } = null!;

}