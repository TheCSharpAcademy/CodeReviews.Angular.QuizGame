using WebApplication1.Models;

namespace WebApplication1.Mapper;

public static class TQuestionMapper
{
    public static ICollection<TQuestion> ToTQuestion(this ICollection<TQuestionDTO> dto, string quizId)
    {
        var questions = new List<TQuestion>();
        foreach (var question in dto)
        {
            var tempData = new TQuestion
            {
                Id = Guid.NewGuid().ToString(),
                Category = question.Category,
                Difficulty = question.Difficulty,
                Question = question.Question,
                Correct_answer = question.Correct_Answer,
                Incorrect_answers = question.Incorrect_Answers,
                QuizId = quizId
            };
            questions.Add(tempData);
        }
        return questions;
    }
}
