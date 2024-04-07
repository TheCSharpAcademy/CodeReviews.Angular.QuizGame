namespace QuizGameAPI.Models;

public class Question
{
    public int Id { get; set; }

    public string QuestionPrompt { get; set; } = "";
    public string Answer1 { get; set; } = "";
    public string Answer2 { get; set; } = "";
    public string Answer3 { get; set; } = "";
    public int CorrectAnswer { get; set; }
    
    public int QuizId { get; set; }
    public Quiz Quiz { get; set; } = null!;

    public QuestionDTO ToQuestionDTO()
    {
        return new QuestionDTO
        {
            Id = Id,
            QuestionPrompt = QuestionPrompt,
            Answer1 = Answer1,
            Answer2 = Answer2,
            Answer3 = Answer3,
            CorrectAnswer = CorrectAnswer,
            QuizId = QuizId
        };
    }

}

public class QuestionDTO
{
    public int Id { get; set; }
    public string QuestionPrompt { get; set; } = "";
    public string Answer1 { get; set; } = "";
    public string Answer2 { get; set; } = "";
    public string Answer3 { get; set; } = "";
    public int CorrectAnswer { get; set; }
    
    public int QuizId { get; set; }
    
}

