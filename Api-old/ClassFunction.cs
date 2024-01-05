using System.Net;
using Api.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class ClassFunction
    {
        private readonly ILogger _logger;
        private readonly IClassService _classService;

        public ClassFunction(ILoggerFactory loggerFactory, IClassService service)
        {
            _logger = loggerFactory.CreateLogger<ClassFunction>();
            _classService = service;
        }

        [Function("Class")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {

            //var classes = new List<Class>() { new Class() { Name = "Strong Yoga", Date = "12th Jan" }, new Class() { Name = "Relaxing Yoga", Date = "14th jan" } }.ToList();

            var classes = await _classService.GetClassesAsync();

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(classes);

            //response.WriteAsJsonAsync(new ServiceResponse<List<Class>>() { Data= classes, Message= "Success", Success=true});

            return response;
        }

    }
}
