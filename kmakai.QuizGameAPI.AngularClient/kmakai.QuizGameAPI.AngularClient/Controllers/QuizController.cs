using kmakai.QuizGameAPI.AngularClient.Data;
using kmakai.QuizGameAPI.AngularClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kmakai.QuizGameAPI.AngularClient.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuizController : ControllerBase
{
    private readonly QuizContext _context;
    
    public QuizController(QuizContext context)
    {
        _context = context;
    }

    [HttpGet("quizzes")]
    public async Task<ActionResult<Quiz>> GetQuizzes()
    {
        var quizzes =  _context.Quizzes.ToList();
        
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

    [HttpGet("{id}")]
    public async Task<ActionResult<Quiz>> GetQuiz(int id)
    {
        var quiz = await _context.Quizzes.FindAsync(id);

        if (quiz == null)
        {
            return NotFound();
        }

        return Ok(quiz);
    }

    [HttpDelete("{id}")]
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

    [HttpPost]
    public async Task<ActionResult<Quiz>> PostQuiz(Quiz quiz)
    {
        _context.Quizzes.Add(quiz);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetQuiz", new { id = quiz.Id }, quiz);
    }

    [HttpPost("question")]
    public async Task<ActionResult<Question>> PostQuestion(Question question)
    {
        _context.Questions.Add(question);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetQuestion", new { id = question.Id }, question);
    }

    [HttpDelete("question/{id}")]
    public async Task<ActionResult<Question>> DeleteQuestion(int id)
    {
        var question = await _context.Questions.FindAsync(id);
        if (question == null)
        {
            return NotFound();
        }

        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();

        return Ok(question);
    }

    //[HttpPost("submit")]
    //public async Task<ActionResult<Game>> SubmitQuiz(QuizSubmission quizSubmission)
    //{
    //    var game = new Game
    //    {
    //        PlayerName = quizSubmission.PlayerName
    //    };
    //}
}
