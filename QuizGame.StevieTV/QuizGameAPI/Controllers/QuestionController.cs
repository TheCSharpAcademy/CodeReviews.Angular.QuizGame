using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizGameAPI.Database;
using QuizGameAPI.Models;

namespace QuizGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly QuizContext _context;

        public QuestionController(QuizContext context)
        {
            _context = context;
        }

        // GET: api/Question
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            return await _context.Questions.ToListAsync();
        }
        
        // GET: api/Quiz/{id}/Questions
        [HttpGet]
        [Route("/api/Quiz/{id}/Questions")]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestionsByQuiz(int id)
        {
            var questions = await _context.Questions.Include(q => q.Quiz).Where(question => question.QuizId == id).ToListAsync();

            foreach (var q in questions)
            {
                Console.WriteLine($"Question id {q.Id} has quiz id {q.QuizId} with name {q.Quiz.Name}");
            }
            return await _context.Questions.Where(question => question.QuizId == id).ToListAsync();
        }

        // GET: api/Question/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return question;
        }

        // PUT: api/Question/5
        // To protect from over posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, Question question)
        {
            if (id != question.Id)
            {
                return BadRequest();
            }

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Question
        // To protect from over posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Question>> PostQuestion(QuestionDTO questionDto)
        {
            if (!QuizExists(questionDto.QuizId))
            {
                return BadRequest("The Quiz you are trying to add a question to does not exist");
            }
            var question = new Question
            {
                QuestionPrompt = questionDto.QuestionPrompt,
                Answer1 = questionDto.Answer1,
                Answer2 = questionDto.Answer2,
                Answer3 = questionDto.Answer3,
                CorrectAnswer = questionDto.CorrectAnswer,
                QuizId = questionDto.QuizId
            };
            
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestion", new { id = question.Id }, question);
        }

        // DELETE: api/Question/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.Id == id);
        }
        
        private bool QuizExists(int id)
        {
            return _context.Quizzes.Any(e => e.Id == id);
        }
    }
}
