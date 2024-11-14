namespace PinkPlate.API.Extensions
{
    public class Result
    {
        public bool Success { get; private set; }
        public int Code { get; private set; }
        public IEnumerable<string> Messages { get; private set; }
        public Object Data { get; private set; }

        public static Result Ok(object data)
        {
            return new Result
            {
                Success = true,
                Code = 200,
                Data = data
            };
        }

        public static Result Fail(IEnumerable<string> message, int code = 400)
        {
            return new Result
            {
                Success = false,
                Code = code,
                Messages = message,
                Data = null
            };
        }

        public static Result Fail(string message, int code = 400)
        {
            List<string> _messages = new List<string>();

            if (!string.IsNullOrEmpty(message))
                _messages.Add(message);

            return new Result
            {
                Success = false,
                Code = code,
                Messages = _messages,
                Data = null
            };
        }
    }
}
