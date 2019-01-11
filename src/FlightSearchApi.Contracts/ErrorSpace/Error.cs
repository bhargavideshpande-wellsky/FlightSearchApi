namespace FlightSearchApi.Contracts
{
    public class Error
    {
        public Error(string code, string message)
        {
            Message = message;
            Code = code;
        }
        public string Message { get;}
        public string Code { get;}
    }
}
