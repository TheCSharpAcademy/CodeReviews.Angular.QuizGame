using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class TQuestion
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Category { get; set; }
    public string Difficulty { get; set; }
    public string Question { get; set; }
    public string Correct_answer { get; set; }
    public List<string> Incorrect_answers { get; set; }
    [ForeignKey(nameof(Quiz))]
    public string QuizId { get; set; }
}

public record TQuestionDTO
{
    public string Category { get; set; }
    public string Difficulty { get; set; }
    public string Question { get; set; }
    public string Correct_Answer { get; set; }
    public List<string> Incorrect_Answers { get; set; }
}


