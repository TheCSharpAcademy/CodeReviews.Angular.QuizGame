using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GamesController : ControllerBase
{
    private readonly GameService _service;

    public GamesController(GameService service)
    {
        _service = service;
    }

    // GET: api/Games
    [HttpGet]
    public async Task<ActionResult<GamesViewModel>> GetGames(int pageIndex, int pageSize)
    {
        try
        {
            var result = await _service.GetGames(pageIndex, pageSize);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // GET: api/Games/5
    [HttpGet("{id}")]
    public Task<ActionResult<Game>> GetGame(string id)
    {


        return null;
    }

    // PUT: api/Games/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGame(string id, Game game)
    {
        if (id != game.Id)
        {
            return BadRequest();
        }

        try
        {

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
    public async Task<ActionResult<GameDTO>> PostGame(GameDTO gameDTO)
    {

        try
        {
            Console.WriteLine(gameDTO);
            _service.CreateGame(gameDTO);
            return Ok();

        }
        catch (DbUpdateException)
        {
            return NoContent();
        }

        return Ok();
    }

    // DELETE: api/Games/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGame(string id)
    {
        try
        {
            _service.DeleteGame(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest();
        }
    }

    private bool GameExists(string id)
    {
        return true;
    }
}

