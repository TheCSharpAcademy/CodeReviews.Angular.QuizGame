namespace QuizGameAPI.Models;

public class Question
{
    public int QuestionId { get; set; }

    public string QuestionPrompt { get; set; } = "";

    public string Answer1 { get; set; } = "";
    public string Answer2 { get; set; } = "";
    public string Answer3 { get; set; } = "";
    
    public int CorrectAnswer { get; set; }
    
    public int QuizId { get; set; }
    public Quiz CurrentQuiz { get; set; } = null!;

}