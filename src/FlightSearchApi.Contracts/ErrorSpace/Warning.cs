namespace FlightSearchApi.Contracts
{
    public class Warning
    {
        public Warning(string code, string message)
        {
            Message = message;
            Code = code;
        }
        public string Message { get; }
        public string Code { get; }
    }
}
