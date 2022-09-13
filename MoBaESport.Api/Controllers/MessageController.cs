using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoBaEsport.Application.Model.MessageModel;

namespace MoBaESport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IManageMessage _manageMessage;

        public MessageController(IManageMessage manageMessage)
        {
            _manageMessage = manageMessage;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]MessageCreateModel model)
        {
            var result = await _manageMessage.Create(model);

            if (result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid userId, long messageId)
        {
            var result = await _manageMessage.Delete(userId, messageId);

            if (result == 0) return BadRequest();

            return Ok(result);
        }

    }
}
