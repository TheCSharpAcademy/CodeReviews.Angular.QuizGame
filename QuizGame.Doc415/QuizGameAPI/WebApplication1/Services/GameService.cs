using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Mapper;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class GameService
{
    private QuizContext _quizContext;

    public GameService(QuizContext quizContext)
    {
        _quizContext = quizContext;
    }

    public async Task CreateGame(GameDTO gameDTO)
    {
        var newGame = new Game();
        var newQuiz = new Quiz();
        newGame.QuizId = newQuiz.Id;
        newGame.Quiz = new Quiz();
        newGame.Date = gameDTO.Date;
        newQuiz.Game = newGame;

        var askedQuestions = TQuestionMapper.ToTQuestion(gameDTO.Questions, newQuiz.Id);
        newQuiz.Questions = askedQuestions;

        var wrongAnsweredQuestions = newQuiz.Questions
        .Where(q => gameDTO.WrongAnsweredQuestions.Select(wq => wq.Question)
        .Contains(q.Question))
        .ToList();

        newGame.WrongAnsweredQuestions = wrongAnsweredQuestions;
        try
        {
            await _quizContext.Questions.AddRangeAsync(askedQuestions);
            await _quizContext.Quizes.AddAsync(newQuiz);
            await _quizContext.Games.AddAsync(newGame);
            _quizContext.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public async Task<GamesViewModel> GetGames(int pageIndex, int pageSize)
    {
        var query = _quizContext.Games
         .Include(g => g.WrongAnsweredQuestions)
         .Include(g => g.Quiz)
         .ThenInclude(q => q.Questions)
         .AsQueryable();

        var skip = (pageIndex - 1) * pageSize;
        query = query.Skip(skip).Take(pageSize);
        var games = await query.ToListAsync();

        var records = query.Count();
        var gamesToSend = GameInformationMapper.ToGameInformation(games);
        var result = new GamesViewModel()
        {
            Games = gamesToSend,
            TotalRecords = records
        };

        return result;

    }

    public async Task DeleteGame(string id)
    {
        var quiz = _quizContext.Quizes.Find(id);
        _quizContext.Quizes.Remove(quiz);
        _quizContext.SaveChanges();
    }
}
