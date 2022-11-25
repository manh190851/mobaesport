using Microsoft.AspNetCore.Mvc;
using MoBaEsport.APIServices;
using MoBaEsport.Application.Model.MessageModel;

namespace MobaEsport.WebApp.Controllers
{
    public class ChatBoxController : Controller
    {
        private readonly IChatBoxAPI _chatBoxAPI;

        public ChatBoxController(IChatBoxAPI chatBoxAPI)
        {
            _chatBoxAPI = chatBoxAPI;
        }

        public async Task<IActionResult> CreateMessage(MessageCreateModel model)
        {
            throw new NotImplementedException();
        }
    }
}
