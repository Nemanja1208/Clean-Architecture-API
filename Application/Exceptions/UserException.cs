namespace Application.Exceptions
{
    internal class UserException : Exception
    {
        public string ExceptionReason { get; }
        public object MessageDetails { get; }
        public UserException(string exceptionReason, List<string> errors) : base("Something went wrong...")
        {
            ExceptionReason = exceptionReason;

            switch (exceptionReason)
            {
                case "registration":
                    MessageDetails = new
                    {
                        Type = "REGISTRATION",
                        Errors = errors
                    };
                    break;
                default: break;
            }
        }
    }
}
