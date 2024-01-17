using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using SendingMessagesService.Dtos;
using SendingMessagesService.Logic;
using System.ComponentModel.DataAnnotations;

namespace SendingMessagesService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendMessages([Required, FromBody] IEnumerable<SendMessageDto> dtos)
        {
            Result validateResult = Result.Success();
            foreach (SendMessageDto dto in dtos)
            {
                Result<Message> messageResult = Message.Create(dto.Subject, dto.Body, dto.Recipients);
                validateResult = Result.Combine(validateResult, messageResult);
            }
            if (validateResult.IsFailure)
                return BadRequest(validateResult.Error);

            return Ok();
        }

        [HttpGet]
        public IActionResult GetMessages()
        {
            return Ok();
        }
    }
}
