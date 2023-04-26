using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgesController: ControllerBase
    {
        private readonly IBadgeService _badgeService;

        public BadgesController(IBadgeService badgeService)
        {
            _badgeService = badgeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var badges = await _badgeService.GetAll();

            return Ok(badges);
        }

        [HttpGet("{id:int}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var badge = await _badgeService.GetById(id);

            if (badge == null) return NotFound();

            return Ok(badge);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult Add(Badge badge)
        {
            if (!ModelState.IsValid) return BadRequest();

            var badgeResult = _badgeService.Add(badge);

            if (badgeResult == null) return BadRequest();

            return Ok($"Badge {badge.BadgeName} inserted");
        }

        [HttpPut("{id:int}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Badge badge)
        {
            if (id != badge.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            bool result = await _badgeService.Update(badge);

            if (result)
            {
                return Ok($"Badge {id} updated.");
            }

            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove(int id)
        {
            var badge = await _badgeService.GetById(id);
            if (badge == null) return NotFound();

            var result = await _badgeService.Remove(badge);

            if (!result) return BadRequest();

            return Ok($"Badge {id} removed");
        }
    }
}
