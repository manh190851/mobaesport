using Microsoft.AspNetCore.Mvc;
using MoBaEsport.APIServices;

namespace MobaEsport.WebApp.Controllers
{
    public class ChatBoxController : Controller
    {
        private readonly IRelationshipAPI _relationshipAPI;
        private readonly IChatBoxAPI _chatBoxAPI;

        public ChatBoxController(IRelationshipAPI relationshipAPI, IChatBoxAPI chatBoxAPI)
        {
            _relationshipAPI = relationshipAPI;
            _chatBoxAPI = chatBoxAPI;
        }

        public IActionResult Index(long chatboxId)
        {
            var chatBox = _chatBoxAPI.GetChatBox(chatboxId);
            return View(chatBox);
        }
    }
}
