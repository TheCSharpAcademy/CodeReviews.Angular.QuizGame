using System.ComponentModel.DataAnnotations.Schema;

namespace kmakai.QuizGameAPI.AngularClient.Models;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public string Option1 { get; set; } = string.Empty;
    public string Option2 { get; set; } = string.Empty;
    public string Option3 { get; set; } = string.Empty;
    public string Option4 { get; set; } = string.Empty;

    public int QuizId { get; set; }
    public Quiz? Quiz { get; set; }

}


