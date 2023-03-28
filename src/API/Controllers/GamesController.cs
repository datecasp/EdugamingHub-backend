using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var games = await _gameService.GetAll();

            return Ok(games);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var game = await _gameService.GetById(id);

            if (game == null) return NotFound();

            return Ok(game);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add(Game game)
        {
            if (!ModelState.IsValid) return BadRequest();

            var gameResult = _gameService.Add(game);

            if (gameResult == null) return BadRequest();

            return Ok($"Game {game.QuizzNameValue} inserted");
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Game game)
        {
            if (id != game.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            bool result = await _gameService.Update(game);

            if (result)
            {
                return Ok($"Game {id} updated.");
            }

            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove(int id)
        {
            var game = await _gameService.GetById(id);
            if (game == null) return NotFound();

            var result = await _gameService.Remove(game);

            if (!result) return BadRequest();

            return Ok($"Game {id} removed");
        }
    }
}
