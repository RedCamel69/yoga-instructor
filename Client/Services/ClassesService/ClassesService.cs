﻿
using Microsoft.AspNetCore.Components;
using Shared;
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
                    Response = "Error retrieving Tutors " + (_showServiceRequestResponses ? res.Message : String.Empty);
                }
                else
                {
                    Response = "Tutors successfully retrieved " + (_showServiceRequestResponses ? res.Message : String.Empty);
                }

            }

            ClassesChanged.Invoke();
        }
    }
}
