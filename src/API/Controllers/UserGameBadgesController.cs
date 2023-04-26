using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGameBadgesController : ControllerBase
    {
        private readonly IUserGameBadgeService _userGameBadgeService;

        public UserGameBadgesController(IUserGameBadgeService userGameBadgeService)
        {
            _userGameBadgeService = userGameBadgeService;
        }

        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var userGameBadges = await _userGameBadgeService.GetAll();

            return Ok(userGameBadges);
        }

        [HttpGet("{id:int}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByUserId(int id)
        {
            var userGameBadges = await _userGameBadgeService.GetById(id);

            if (userGameBadges == null) return NotFound();

            return Ok(userGameBadges);
        }

        [HttpGet("badges/{id:int}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByUserGameId(int id)
        {
            var userGameBadges = _userGameBadgeService.GetByUserGameId(id);

            if (userGameBadges == null) return NotFound();

            return Ok(userGameBadges);
        }

        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add(UserGameBadge userGameBadge)
        {
            if (!ModelState.IsValid) return BadRequest();

            var userGameBadgeResult = _userGameBadgeService.Add(userGameBadge);

            if (userGameBadgeResult == null) return BadRequest();

            return Ok(userGameBadgeResult);
        }

        [HttpPut]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(UserGameBadge userGameBadge)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = _userGameBadgeService.Add(userGameBadge);

            if (result != null)
            {
                return Ok($"UserGameBadge {userGameBadge.Id} updated.");
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
