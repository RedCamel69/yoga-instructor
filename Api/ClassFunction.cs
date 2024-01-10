using System;
using System.Net;
using System.Threading.Tasks;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SharedModels;

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

            var classes = await _classService.GetAsync();

            return new OkObjectResult(classes);
        }

        [FunctionName("Class")]
        public async Task<IActionResult> GetClass(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "class/{classId}")] HttpRequest req,
            string classId,
            ILogger log)
        {
            try
            {
                log.LogInformation($"C# HTTP GET trigger function processed api/class/{classId} request.");
                return new OkObjectResult(await _classService.GetClassAsync(classId));
            }
            catch (Exception ex)
            {
                log.LogError($"C# HTTP GET trigger function api/course request exception:{ex.Message}");
                return new OkObjectResult(new ServiceResponse<Class>()
                {
                    Data = null,
                    Message = "Failed to retrieve course",
                    Success = false
                });
            }

            
        }

        [FunctionName("CreateClass")]
        public async Task<IActionResult> CreateClass(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "class")]
            HttpRequest req,
            //Tutor tutor,
            ILogger log)
        {


            try
            {
                string result = await req.ReadAsStringAsync();
                var cl = JsonConvert.DeserializeObject<Class>(result);

                log.LogInformation("C# HTTP POST trigger function processed api/student request.");
                return new OkObjectResult(await _classService.CreateClassAsync(cl));
            }
            catch (Exception ex)
            {
                log.LogError($"C# HTTP POST trigger function api/class exception:{ex.Message}");
                return new OkObjectResult(new ServiceResponse<Class>()
                {
                    Data = null,
                    Message = "Failed to create course",
                    Success = false
                });
            }
        }


        [FunctionName("UpdateClass")]
        public async Task<IActionResult> UpdateClass(
           [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "class")] HttpRequest req,
           ILogger log)
        {


            try
            {
                string result = await req.ReadAsStringAsync();
                var cl = JsonConvert.DeserializeObject<Class>(result);

                log.LogInformation("C# HTTP PUT trigger function processed api/class request.");
                return new OkObjectResult(await _classService.UpdateClassAsync(cl));
            }
            catch (Exception ex)
            {
                log.LogError($"C# HTTP PUT trigger function api/course exception:{ex.Message}");
                return new OkObjectResult(new ServiceResponse<Class>()
                {
                    Data = null,
                    Message = "Failed to uodate class",
                    Success = false
                });
            }
        }

    }
}
