namespace WebApplication1.Models;

public record GameDTO
{
    public string Date { get; set; }
    public ICollection<TQuestionDTO> Questions { get; set; }
    public ICollection<TQuestionDTO> WrongAnsweredQuestions { get; set; }

}
