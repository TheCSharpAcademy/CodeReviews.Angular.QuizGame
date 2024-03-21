using System.ComponentModel.DataAnnotations.Schema;
namespace kmakai.QuizGameAPI.AngularClient.Models;

public class Game
{
    public int Id { get; set; }
    public string PlayerName { get; set; } = string.Empty;
    public int Score { get; set; }

    public int QuizId { get; set; }

    [ForeignKey(nameof(QuizId))]
    public Quiz? Quiz { get; set; } = null!;
}
