namespace kmakai.QuizGameAPI.AngularClient.Models;

public class QuizSubmission
{
    public string PlayerName { get; set; } = string.Empty;
    public int QuizId { get; set; }
    public List<QuestionSubmission> Answers { get; set; } = new List<QuestionSubmission>();
}

public class QuestionSubmission
{
    public string Answer { get; set; } = string.Empty;
    public string UserAnswer { get; set; } = string.Empty;
}