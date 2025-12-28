using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using WEB.API.Hubs;
using WEB.API.DTOs;

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
        public async Task<IActionResult> CreateMessage( [FromBody] SendMessageDTO dto)
        {
            await _hubContext.Clients.All
                .SendAsync("MessageSend",dto.Message);

            return Ok(new { Message = "Message Sent" });
        }

    }
}
