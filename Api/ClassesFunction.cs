using System;
using System.Linq;
using System.Net;
using BlazorApp.Shared;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class ClassesFunction
    {
        private readonly ILogger _logger;

        public ClassesFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ClassesFunction>();
        }

        [Function("Classes")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {

            var classes = new[] { new { Name = "Strong Yoga", Date = "12th Jan" }, new { Name = "Relaxing Yoga", Date = "14th jan" } }.ToList();


            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteAsJsonAsync(classes);

            return response;
        }

        private string GetSummary(int temp)
        {
            var summary = "Mild";

            if (temp >= 32)
            {
                summary = "Hot";
            }
            else if (temp <= 16 && temp > 0)
            {
                summary = "Cold";
            }
            else if (temp <= 0)
            {
                summary = "Freezing";
            }

            return summary;
        }
    }
}
