using SendingMessagesService.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SendingMessagesService.Dtos
{
    public sealed class SendMessageDto
    {
        [Required, Subject]
        public string Subject { get; set; }

        [Required, Body]
        public string Body { get; set; }

        [Required, Recipients]
        public IReadOnlyList<int> Recipients { get; set; }
    }
}
