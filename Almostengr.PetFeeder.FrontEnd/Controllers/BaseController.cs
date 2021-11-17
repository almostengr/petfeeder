using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Almostengr.PetFeeer.Web.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Almostengr.PetFeeder.FrontEnd.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly ILogger<BaseController> _logger;
        private readonly HttpClient _httpClient;

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
            
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5002");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Entity> GetAsync<Entity>(string route) where Entity : BaseDto
        {
            Entity responseEntity = null;

            var response = await _httpClient.GetAsync(route);

            if (response.IsSuccessStatusCode)
            {
                responseEntity = JsonConvert.DeserializeObject<Entity>(response.Content.ReadAsStringAsync().Result);
            }

            return responseEntity;
        }

        public async Task<bool?> GetAsyncBool(string route)
        {
            bool? responseEntity = null;

            var response = await _httpClient.GetAsync(route);

            if (response.IsSuccessStatusCode)
            {
                responseEntity = JsonConvert.DeserializeObject<bool>(response.Content.ReadAsStringAsync().Result);
            }

            return responseEntity;
        }

        // public async Task<HttpStatusCode> DeleteAsync<Entity>(string route) where Entity : BaseDto
        // {
        //     var response = await _httpClient.DeleteAsync(route);

        //     return response.StatusCode;
        // }

        public async Task<Entity> PostAsync<Entity>(string route, Entity entity) where Entity : BaseDto
        {
            Entity responseEntity = null;

            var response = await _httpClient.PostAsync(route, ConvertToStringContent(entity));

            if (response.IsSuccessStatusCode)
            {
                responseEntity = JsonConvert.DeserializeObject<Entity>(response.Content.ReadAsStringAsync().Result);
            }

            return responseEntity;
        }

        // public async Task<Entity> PutAsync<Entity>(string route, Entity entity) where Entity : BaseDto
        // {
        //     Entity responseEntity = null;

        //     var response = await _httpClient.PutAsync(route, ConvertToStringContent(entity));

        //     if (response.IsSuccessStatusCode)
        //     {
        //         responseEntity = JsonConvert.DeserializeObject<Entity>(response.Content.ReadAsStringAsync().Result);
        //     }

        //     return responseEntity;
        // }

        private StringContent ConvertToStringContent<Entity>(Entity entity)
        {
            return new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
        }
    }
}