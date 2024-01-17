using Newtonsoft.Json;
using SendingMessagesService.Errors;

namespace SendingMessagesService.Utils
{
    [Serializable]
    public class Envelope<T>
    {
        public T Result { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime TimeGenerated { get; set; }

        public Envelope()
        {

        }

        protected internal Envelope(T result, string errorMessage)
        {
            Result = result;
            ErrorMessage = errorMessage;
            TimeGenerated = DateTime.UtcNow;
        }
    }

    public class Envelope : Envelope<string>
    {
        public string ErrorCode { get; }

        public string FieldName { get; }

        [JsonConstructor]
        public Envelope()
        {

        }

        protected Envelope(Error error, string fieldName) : base(null, error.Message)
        {
            ErrorCode = error.Code;
            FieldName = fieldName;
        }

        protected Envelope(string errorMessage)
            : base(null, errorMessage)
        {
        }

        public static Envelope<T> Ok<T>(T result)
        {
            return new Envelope<T>(result, null);
        }

        public static Envelope Ok()
        {
            return new Envelope(null);
        }

        public static Envelope Error(string errorMessage)
        {
            return new Envelope(errorMessage);
        }

        public static Envelope Error(Error _Error, string _FieldName)
        {
            return new Envelope(_Error, _FieldName);
        }
    }
}
