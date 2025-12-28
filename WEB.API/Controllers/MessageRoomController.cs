using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using WEB.API.Hubs;

namespace WEB.API.Controllers
{
    [ApiController]
    [Route("api/message-room")]
    public class MessageRoomController : ControllerBase
    {
        private readonly IHubContext<MessageHub> _hubContext;
        public MessageRoomController(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateMessage()
        {
            var message = "Test";
            await _hubContext.Clients.All
                .SendAsync("MessageSend",message);

            return Ok(new { Message = "Message Sent" });
        }

    }
}
