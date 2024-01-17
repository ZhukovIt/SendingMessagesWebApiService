using CSharpFunctionalExtensions;
using SendingMessagesService.Dtos;

namespace SendingMessagesService.Logic
{
    public sealed class MessagesQueue
    {
        private readonly List<Message> _queue = new List<Message>();

        public void Add(Message message)
        {
            _queue.Add(message);
        }

        public Maybe<IReadOnlyList<Message>> Get(int key)
        {
            List<Message> messages = _queue
                .Where(msg => msg.Recipients.Value.Contains(key))
                .ToList();

            if (messages.Count == 0)
                return Maybe.None;
            return messages;
        }
    }
}
