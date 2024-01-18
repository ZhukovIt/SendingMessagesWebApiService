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
        public IActionResult SendMessages([FromBody] SendMessageDto[] messageDtos)
        {
            if (messageDtos.Count() == 0)
                return Error("Отсутствуют сообщения для отправки!");

            foreach (SendMessageDto dto in messageDtos)
            {
                Subject subject = Subject.Create(dto.Subject).Value;
                Body body = Body.Create(dto.Body).Value;
                Recipients recipients = Recipients.Create(dto.Recipients).Value;
                Message message = new Message(subject, body, recipients);
                _messagesQueue.Add(message);
            }

            return Created();
        }

        [HttpGet]
        public IActionResult GetMessages([FromQuery] int rcpt)
        {
            if (rcpt == 0)
                return Error($"Для попытки получения сообщений необходимо указать параметр {nameof(rcpt)}!");

            Maybe<IReadOnlyList<Message>> messagesOrNone = _messagesQueue.Get(rcpt);
            if (messagesOrNone.HasNoValue)
                return NotFound($"Для получателя с {nameof(rcpt)} = {rcpt} нет сообщений!");

            List<GetMessageDto> dtos = messagesOrNone.Value.Select(msg => new GetMessageDto()
            {
                Subject = msg.Subject,
                Body = msg.Body
            })
            .ToList();

            return Ok(dtos);
        }
    }
}
