using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoBaEsport.Application.Model.MessageModel;

namespace MoBaESport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IManageMessage _manageMessage;

        public MessagesController(IManageMessage manageMessage)
        {
            _manageMessage = manageMessage;
        }

        [HttpPost("create-message")]
        public async Task<IActionResult> Create([FromBody]MessageCreateModel model)
        {
            var result = await _manageMessage.Create(model);

            if (result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpDelete("delete-message")]
        public async Task<IActionResult> Delete([FromQuery]Guid userId, [FromQuery]long messageId)
        {
            var result = await _manageMessage.Delete(userId, messageId);

            if (result == 0) return BadRequest();

            return Ok(result);
        }

    }
}
