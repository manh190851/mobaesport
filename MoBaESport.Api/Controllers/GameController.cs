using Microsoft.AspNetCore.Mvc;
using MoBaEsport.Application.Model.GameModel;
using MoBaEsport.Application.Model.ReactionModel;

namespace MoBaEsport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {
        public IManageGame _manageGame;

        public GameController(IManageGame manageGame)
        {
            _manageGame = manageGame;
        }

        [HttpPost("create-game")]
        public async Task<IActionResult> Create([FromBody]GameCreateModel model)
        {
            var result = await _manageGame.Create(model);
            if (result == 0) return BadRequest();
            return Ok(result);
        }

        [HttpPut("update-game")]
        public async Task<IActionResult> Update([FromBody]GameViewModel model)
        {
            var result = await _manageGame.Update(model);
            if (result == 0) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("delete-game")]
        public async Task<IActionResult> Delete([FromQuery]long gameId)
        {
            var result = await _manageGame.Delete(gameId);
            if (result == 0) return BadRequest();
            return Ok();
        }

        [HttpGet("get-game-id")]
        public async Task<IActionResult> GetGameById([FromQuery]long gameId)
        {
            var result = await _manageGame.GetGameById(gameId);
            if (result == null) return BadRequest();
            return Ok();
        }

        [HttpPatch("change-game-active")]
        public async Task<IActionResult> ChangeActive([FromQuery] long gameId, [FromBody]bool isActive)
        {
            var result = await _manageGame.ChangeActive(gameId, isActive);
            if(result == 0) return BadRequest();
            return Ok();
        }
    }
}
