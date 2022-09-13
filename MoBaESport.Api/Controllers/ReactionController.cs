using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoBaEsport.Application.Model.ReactionModel;

namespace MoBaESport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionController : ControllerBase
    {
        private readonly IManageReaction _manageReaction;

        public ReactionController(IManageReaction manageReaction)
        {
            _manageReaction = manageReaction;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ReactionCreateModel model)
        {
            var result = await _manageReaction.Create(model);

            if (result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpPut("{reactionId}")]
        public async Task<IActionResult> Update([FromForm] ReactionUpdateModel model, long reactionId)
        {
            var result = await _manageReaction.Update(model, reactionId);

            if (result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpDelete("{reactionId}")]
        public async Task<IActionResult> Delete(long ReactionId)
        {
            var result = await _manageReaction.Delete(ReactionId);

            if (result == 0) return BadRequest();

            return Ok(result);
        }
    }
}
