
using Microsoft.AspNetCore.Components;
using Shared;
using SharedModels;
using System.Net;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace BlazorApp.Client.Services.ClassesService
{
    public class ClassesService : IClassesService
    {
        private readonly HttpClient _http;

        public event Action ClassesChanged;

        public List<Class> Classes { get; set; } = new List<Class>();
        public string Response { get; set; }
        public bool RequestSuccessful { get; set; }
        private bool _showServiceRequestResponses;

        public ClassesService(HttpClient http)
        {
            _http = http;           
        }

        public async Task GetClasses()
        {
            var res =
                await _http.GetFromJsonAsync<ServiceResponse<List<Class>>>("api/Classes");



            if (res != null && res.Data != null)
            {
                Classes = res.Data;
            }

            if (res != null)
            {
                RequestSuccessful = res.Success;
                if (!res.Success)
                {
                    Response = "Error retrieving Classes " + (_showServiceRequestResponses ? res.Message : String.Empty);
                }
                else
                {
                    Response = "Classes successfully retrieved " + (_showServiceRequestResponses ? res.Message : String.Empty);
                }

            }

            ClassesChanged.Invoke();
        }

        public async Task CreateClass(Class newClass)
        {
            await _http.PostAsJsonAsync("api/class", newClass);
            //_navigationManger.NavigateTo("courses");
        }

        public async Task<Class?> GetClassById(string id)
        {
            var result = await _http.GetAsync($"api/class/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var serviceRespnse = await result.Content.ReadFromJsonAsync<ServiceResponse<Class>>();

                //todo: Inspect response for errors
                if (serviceRespnse != null)
                {
                    if (serviceRespnse.Data != null && serviceRespnse.Success == true)
                    {
                        return serviceRespnse.Data;
                    }
                    else
                    {
                        Response = $"Error retrieving student. Service indicates the action failed : {serviceRespnse.Message}";
                    }

                }
            }

            return null;
        }
    }
}
