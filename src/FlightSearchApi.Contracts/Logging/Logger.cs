using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FlightSearchApi.Contracts
{
    public static class Logger
    {
        public static void AddApiLog(string apiName)
        {
            ApiLog log = new ApiLog();
            log.ApiName = apiName;
            //log.Request = request;
            //log.Response = response;
            //log.Url = url;
            string JSONresult = JsonConvert.SerializeObject(log);
            var path = @"C:\Users\bdeshpande\Desktop\logging.txt";
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(JSONresult.ToString());
                tw.Close();
            }
        }

    }
}
