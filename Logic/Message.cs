using CSharpFunctionalExtensions;

namespace SendingMessagesService.Logic
{
    public sealed class Message : ValueObject
    {
        public string Subject { get; }

        public string Body { get; }

        private List<int> _recipientIDs;

        public IReadOnlyList<int> RecipientIDs => _recipientIDs;

        private Message(string subject, string body, IEnumerable<int> recipientIDs)
        {
            Subject = subject;
            Body = body;
            _recipientIDs = recipientIDs.ToList();
        }

        public static Result<Message> Create(string subject, string body, IEnumerable<int> recipientIDs)
        {
            if (string.IsNullOrWhiteSpace(subject))
                return Result.Failure<Message>("Тема сообщения является обязательной!");
            if (string.IsNullOrWhiteSpace(body))
                return Result.Failure<Message>("Тело сообщения является обязательным!");
            if (recipientIDs == null || recipientIDs.Count() == 0)
                return Result.Failure<Message>("Наличие хотя бы одного получателя для сообщения обязательно!");

            return Result.Success(new Message(subject, body, recipientIDs));
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Subject;
            yield return Body;
            foreach (int recipientID in _recipientIDs)
            {
                yield return recipientID;
            }
        }
    }
}
