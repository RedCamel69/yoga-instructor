using System.Net;
using System.Threading.Tasks;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
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

        [FunctionName("Classes")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            //var classes = new List<Class>() { new Class() { Name = "Strong Yoga", Date = "12th Jan" }, new Class() { Name = "Relaxing Yoga", Date = "14th jan" } }.ToList();

            var classes = await _classService.GetClassesAsync();

            return new OkObjectResult(classes);
        }

    }
}
