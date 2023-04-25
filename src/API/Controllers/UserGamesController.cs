using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGamesController : ControllerBase
    {
        private readonly IUserGameService _userGameService;

        public UserGamesController(IUserGameService userGameService)
        {
            _userGameService = userGameService;
        }

        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var userGames = await _userGameService.GetAll();

            return Ok(userGames);
        }

        [HttpGet("{userId:int}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var userGames = await _userGameService.GetByUserId(userId);

            if (userGames == null) return NotFound();

            return Ok(userGames);
        }

        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add(UserGame userGame)
        {
            if (!ModelState.IsValid) return BadRequest();

            var userGameResult = _userGameService.Add(userGame);

            if (userGameResult == null) return BadRequest();

            return Ok(userGameResult);
        }

        [HttpPut]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(UserGame userGame)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result =  _userGameService.Add(userGame);

            if (result != null)
            {
                return Ok($"UserGame {userGame.Id} updated.");
            }

            return BadRequest();
        }

        //[HttpDelete("{id:int}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> Remove(int id)
        //{
        //    var user = await _userService.GetById(id);
        //    if (user == null) return NotFound();

        //    var result = await _userService.Remove(user);

        //    if (!result) return BadRequest();

        //    return Ok($"User {id} removed");
        //}
    }
}
