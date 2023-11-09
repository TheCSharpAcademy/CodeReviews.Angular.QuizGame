using kmakai.QuizGameAPI.AngularClient.Data;
using kmakai.QuizGameAPI.AngularClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kmakai.QuizGameAPI.AngularClient.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly QuizContext _context;
    
    public GameController(QuizContext context)
    {
        _context = context;
    }

    [HttpGet("quizzes")]
    public async Task<ActionResult<Quiz>> GetQuizzes()
    {
        var quizzes = await _context.Quizzes.ToListAsync();
        
       if (quizzes == null)
        {
            return NotFound();
        }

       
        return Ok(quizzes);
    }

    [HttpGet("questions/{id}")]
    public ActionResult<IEnumerable<Question>> GetQuizQuestions(int id)
    {
        var questions = _context.Questions.Where(q => q.QuizId == id).ToList();
        return Ok(questions);
    }

    [HttpGet("quiz/{id}")]
    public async Task<ActionResult<Quiz>> GetQuiz(int id)
    {
        var quiz = await _context.Quizzes.FindAsync(id);

        if (quiz == null)
        {
            return NotFound();
        }

        return Ok(quiz);
    }

    [HttpDelete("quiz/{id}")]
    public async Task<ActionResult<Quiz>> DeleteQuiz(int id)
    {
        var quiz = await _context.Quizzes.FindAsync(id);
        if (quiz == null)
        {
            return NotFound();
        }

        _context.Quizzes.Remove(quiz);
        await _context.SaveChangesAsync();

        return Ok(quiz);
    }

    [HttpPost("submit")]
    public ActionResult SubmitQuiz(QuizSubmission submission)
    {
        int score = 0;
        Console.WriteLine("Submitting quiz");
        Console.WriteLine(submission.PlayerName);
        foreach (var answer in submission.Answers)
        {
            if (answer.Answer == answer.UserAnswer)
            {
                score += 10;
            }
        }

        var game = new Game
        {
            PlayerName = submission.PlayerName,
            Score = score,
            QuizId = submission.QuizId
        };

        _context.Games.Add(game);
        _context.SaveChanges();

        return Ok(game);

    }

    [HttpGet("games")]
    public async Task<ActionResult<Game>> GetScores()
    {
        var scores = await _context.Games.ToListAsync();
        return Ok(scores);
    }

    [HttpGet("games/{id}")]
    public async Task<ActionResult<Game>> GetScores(int id)
    {
        var scores = await _context.Games.Where(g => g.QuizId == id).ToListAsync();
        return Ok(scores);
    }
}
