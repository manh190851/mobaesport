using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoBaEsport.Application.Model.ChatBoxModel;

namespace MoBaESport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatBoxesController : ControllerBase
    {
        private readonly IManageChatBox _manageChatBox;

        public ChatBoxesController(IManageChatBox manageChatBox)
        {
            _manageChatBox = manageChatBox;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ChatBoxCreateModel model)
        {
            var result = await _manageChatBox.Create(model);

            if (result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpDelete("{ChatBoxId}")]
        public async Task<IActionResult> Delete(Guid userid, long ChatBoxId)
        {
            var result = await _manageChatBox.Delete(ChatBoxId);

            if (result == 0) return BadRequest();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> ViewChatBox(long chatboxId)
        {
            var result = await _manageChatBox.ViewChatBox(chatboxId);

            if (result == null) return BadRequest();

            return Ok(result);
        }
    }
}
