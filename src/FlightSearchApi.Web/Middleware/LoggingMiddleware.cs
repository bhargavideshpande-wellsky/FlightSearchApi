using FlightSearchApi.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSearchApi.Web
{
    public class LoggingMiddleware
    {
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        private readonly RequestDelegate _next;

        public async Task Invoke(HttpContext httpContext)
      {
            //Stopwatch stopWatch = Stopwatch.StartNew();

            await _next.Invoke(httpContext);

            //stopWatch.Stop();

            //var request = await GetRequestPayload(httpContext);
            //var response = await GetResponsePayload(httpContext);
            //var uri = httpContext.Request?.Path.ToUriComponent();

            Logger.AddApiLog("SearchApi");
        }

        protected internal virtual async Task<Func<byte[]>> GetRequestPayload(HttpContext httpContext)
        {
            if (httpContext.Request.ContentLength == null || httpContext.Request.ContentLength.Value == 0)
            {
                return null;
            }

            httpContext.Request.Body.Seek(0, SeekOrigin.Begin);
            string requestBodyText = new StreamReader(httpContext.Request.Body).ReadToEnd();
            httpContext.Request.Body.Seek(0, SeekOrigin.Begin);
            Func<byte[]> requestData = () => string.IsNullOrWhiteSpace(requestBodyText) ? new byte[0] : Encoding.UTF8.GetBytes(requestBodyText);
            return requestData;
        }
        protected internal virtual async Task<Func<byte[]>> GetResponsePayload(HttpContext httpContext)
        {
            httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseBodyText = new StreamReader(httpContext.Response.Body).ReadToEnd();
            httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
            Func<byte[]> responseData = () => string.IsNullOrWhiteSpace(responseBodyText) ? new byte[0] : Encoding.UTF8.GetBytes(responseBodyText);
            return responseData;
        }
    }
}
