using FlightSearchApi.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FlightSearchApi.Plugins
{
    public class FlightFileStore:IDataStore
    {
        public List<Flight> GetFlightData()
        {
            string path = "../FlightSearchApi.Plugins/MockAdapters/Resources/FlightDetails.json";
            using (StreamReader r = new StreamReader(path))
            {
                var json = r.ReadToEnd();
                var flights = JsonConvert.DeserializeObject<List<Flight>>(json);
                return flights;
            }
        }
    }
}
