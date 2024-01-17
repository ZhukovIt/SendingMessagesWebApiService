using SendingMessagesService.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SendingMessagesService.Dtos
{
    [Message]
    public sealed class SendMessageDto
    {
        [Required]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public IReadOnlyList<int> Recipients { get; set; }
    }
}
