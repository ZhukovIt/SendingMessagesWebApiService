using Microsoft.AspNetCore.Mvc;
using SendingMessagesService.Dtos;

namespace SendingMessagesService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        [Route("/")]
        [HttpPost]
        public void SendMessages([FromBody] IEnumerable<SendMessageDto> dtos)
        {

        }

        [Route("/")]
        [HttpGet]
        public void GetMessages()
        {

        }
    }
}
