using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSearchApi.Contracts
{
    public class ApiLog
    {
        public string ApiName { get; set; }
        public byte[] Request { get; set; }
        public byte[] Response { get; set; }
        public string Url { get; set; }

    }
}
