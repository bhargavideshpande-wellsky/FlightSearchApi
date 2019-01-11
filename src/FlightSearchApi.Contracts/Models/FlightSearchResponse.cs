using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSearchApi.Contracts
{
   public class Flight
    {
        public string FlightNumber { get; set; }
        public string EquipmentCode { get; set; }
        public string AirlineCode { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
    }
    public class SearchResponse
    {
        public Flight Flight { get; set; }
        public List<Error> Errors { get; set; }
        public List<Warning> Warnings { get; set; }
    }
}
