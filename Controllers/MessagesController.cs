using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SendingMessagesService.Dtos;
using SendingMessagesService.Errors;
using SendingMessagesService.Logic;
using SendingMessagesService.Utils;
using System.ComponentModel.DataAnnotations;

namespace SendingMessagesService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MessagesController : BaseController
    {
        private readonly MessagesQueue _messagesQueue;

        public MessagesController(MessagesQueue messagesQueue) : base()
        {
            _messagesQueue = messagesQueue;
        }

        [HttpPost]
        public IActionResult SendMessages([FromBody] IEnumerable<SendMessageDto> dtos)
        {
            if (dtos.Count() == 0)
                return Error("Отсутствуют сообщения для отправки!");

            List<Message> messages = new List<Message>();
            foreach (SendMessageDto dto in dtos)
            {
                messages.Add(Message.Create(dto.Subject, dto.Body, dto.Recipients).Value);
            }



            return StatusCode(201);
        }

        [HttpGet]
        public IActionResult GetMessages()
        {
            return Ok();
        }
    }
}
