using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Shared;

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

            var classes = new List<Class>() { new Class() { Name = "Strong Yoga", Date = "12th Jan" }, new Class() { Name = "Relaxing Yoga", Date = "14th jan" } }.ToList();


            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteAsJsonAsync(new ServiceResponse<object>() { Data= classes, Message= "Success", Success=true});

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
