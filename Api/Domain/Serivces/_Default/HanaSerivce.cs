using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Api.Domain.Serivces._Default
{
    public class HanaSerivce : IHanaSerivce
    {
        private readonly HttpClient _httpClient;
        private JsonSerializerOptions _options;
        private string _baseUrl = "https://35.156.189.63:50000";
        private readonly HttpContext _httpContext;
        public HanaSerivce(HttpClient httpClient, IHttpContextAccessor contextAccessor)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions{ };
            _httpContext = contextAccessor.HttpContext;
        }

        public async Task<BusinessPartnersDto> GetBusinessPartners()
        {
            //StringContent content = new StringContent(JsonSerializer.Serialize(loginDetails, _options), Encoding.UTF8, "application/json");
            var container = _httpContext.RequestServices.GetService(typeof(CookieContainer)) as CookieContainer;
            
            container.Add(new Uri(_baseUrl), new Cookie("CompanyDB","" ));
            
            var response = await _httpClient.GetAsync(string.Format("{0}{1}", _baseUrl, "b1s/v1/BusinessPartners"));

            string apiResponse = await response.Content.ReadAsStringAsync();

            return null;
        }

        public async Task<Session> PostLogin(LoginDetails loginDetails)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(loginDetails, _options), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(string.Format("{0}{1}",_baseUrl,"/b1s/v1/Login"), content);

            string apiResponse = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Session>(apiResponse);
        }


    }
}
