using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizGameAPI.Data;
using QuizGameAPI.Models;

namespace QuizGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly QuizContext _context;

        public GamesController(QuizContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGameRecords()
        {
            return await _context.GameRecords.ToListAsync();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var game = await _context.GameRecords.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, Game game)
        {
            if (id != game.Id)
            {
                return BadRequest();
            }

            _context.Entry(game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
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

        // POST: api/Games
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(CreateGameDTO createGameDto)
        {
            var game = new Game
            {
                PlayerName = createGameDto.PlayerName,
                TotalAmountOfQuestions = createGameDto.TotalAmountOfQuestions,
                CorrectAmountOfAnswers = createGameDto.CorrectAmountOfAnswers,
                QuizId = createGameDto.QuizId,
                // Manually set the Quiz property
                Quiz = await _context.QuizRecords.FindAsync(createGameDto.QuizId)
            };

            _context.GameRecords.Add(game);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _context.GameRecords.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _context.GameRecords.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameExists(int id)
        {
            return _context.GameRecords.Any(e => e.Id == id);
        }
    }
}
