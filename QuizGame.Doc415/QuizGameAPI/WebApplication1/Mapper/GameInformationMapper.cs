using WebApplication1.Models;

namespace WebApplication1.Mapper;

public static class GameInformationMapper
{
    public static ICollection<GameInformation> ToGameInformation(List<Game> games)
    {
        var result = new List<GameInformation>();
        foreach (var game in games)
        {
            var tempData = new GameInformation()
            {
                GameId = game.Id,
                QuizId = game.Quiz.Id,
                Questions = game.Quiz.Questions,
                WrongAnsweredQuestions = game.WrongAnsweredQuestions,
                Date = game.Date
            };
            result.Add(tempData);
        }
        return result;
    }
}
