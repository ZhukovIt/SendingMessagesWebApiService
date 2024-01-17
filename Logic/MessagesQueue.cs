using CSharpFunctionalExtensions;

namespace SendingMessagesService.Logic
{
    public sealed class MessagesQueue
    {
        private readonly Dictionary<int, List<Message>> _queue = new Dictionary<int, List<Message>>();

        public void Add(int key, Message message)
        {
            if (!_queue.ContainsKey(key))
                _queue[key] = new List<Message>();

            _queue[key].Add(message);
        }

        public Maybe<IReadOnlyList<Message>> Get(int key)
        {
            if (!_queue.ContainsKey(key))
                return Maybe.None;

            return _queue[key];
        }
    }
}
