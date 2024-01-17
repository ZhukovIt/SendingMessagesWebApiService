using CSharpFunctionalExtensions;

namespace SendingMessagesService.Logic
{
    public sealed class Message
    {
        public Subject Subject { get; }

        public Body Body { get; }

        public Recipients Recipients { get; }

        public Message(Subject subject, Body body, Recipients recipients)
        {
            Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            Body = body ?? throw new ArgumentNullException(nameof(body));
            Recipients = recipients ?? throw new ArgumentNullException(nameof(recipients));
        }
    }
}
