using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

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
            
            container.Add(new Uri(_baseUrl), new Cookie("CompanyDB",_httpContext.Request.Headers["api-company"]));
            container.Add(new Uri(_baseUrl), new Cookie("B1SESSION", _httpContext.Request.Headers["api-sessionid"]));

            var response = await _httpClient.GetAsync(string.Format("{0}{1}", _baseUrl, "/b1s/v1/BusinessPartners"));

            string apiResponse = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<BusinessPartnersDto>(apiResponse); ;
        }

        public async Task<Session> PostLogin(LoginDetails loginDetails)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(loginDetails, _options), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(string.Format("{0}{1}",_baseUrl,"/b1s/v1/Login"), content);

            string apiResponse = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Session>(apiResponse);
        }

        public async Task<BPDetails> GetBusinessPartnersById(string id)
        {

            var container = _httpContext.RequestServices.GetService(typeof(CookieContainer)) as CookieContainer;

            container.Add(new Uri(_baseUrl), new Cookie("CompanyDB", _httpContext.Request.Headers["api-company"]));
            container.Add(new Uri(_baseUrl), new Cookie("B1SESSION", _httpContext.Request.Headers["api-sessionid"]));
            var response = await _httpClient.GetAsync(string.Format("{0}{1}", _baseUrl, "/b1s/v1/BusinessPartners" +"('"+ id +"')"));

            string apiResponse = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<BPDetails>(apiResponse);
        }

        public async Task<bool> DeleteBusinessPartners(string id)
        {
            var container = _httpContext.RequestServices.GetService(typeof(CookieContainer)) as CookieContainer;

            container.Add(new Uri(_baseUrl), new Cookie("CompanyDB", _httpContext.Request.Headers["api-company"]));
            container.Add(new Uri(_baseUrl), new Cookie("B1SESSION", _httpContext.Request.Headers["api-sessionid"]));

            var response = await _httpClient.DeleteAsync(string.Format("{0}{1}", _baseUrl, "/b1s/v1/BusinessPartners" + "('" + id + "')"));
         
            string apiResponse = await response.Content.ReadAsStringAsync();

            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }                     
        }

        public async Task<bool> UpdateBusinessPartners(BPDetails bp)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(bp, _options), Encoding.UTF8, "application/json");

            var container = _httpContext.RequestServices.GetService(typeof(CookieContainer)) as CookieContainer;

            container.Add(new Uri(_baseUrl), new Cookie("CompanyDB", _httpContext.Request.Headers["api-company"]));
            container.Add(new Uri(_baseUrl), new Cookie("B1SESSION", _httpContext.Request.Headers["api-sessionid"]));

            var response = await _httpClient.PatchAsync(string.Format("{0}{1}", _baseUrl, "/b1s/v1/BusinessPartners" + "('" + bp.CardCode + "')"),content);

            string apiResponse = await response.Content.ReadAsStringAsync();

            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public async Task<bool> CreateBusinessPartners(BPDetails bp)
        {
            StringContent content = new StringContent(JsonSerializer.Serialize(bp, _options), Encoding.UTF8, "application/json");

            var container = _httpContext.RequestServices.GetService(typeof(CookieContainer)) as CookieContainer;

            container.Add(new Uri(_baseUrl), new Cookie("CompanyDB", _httpContext.Request.Headers["api-company"]));
            container.Add(new Uri(_baseUrl), new Cookie("B1SESSION", _httpContext.Request.Headers["api-sessionid"]));

            var response = await _httpClient.PostAsync(string.Format("{0}{1}", _baseUrl, "/b1s/v1/BusinessPartners"), content);

            string apiResponse = await response.Content.ReadAsStringAsync();

            //var json = JObject.Parse(apiResponse)["error"];

            //var jsonMessage = JObject.Parse(json["message"].ToString());

            //var jsonValue = JObject.Parse(jsonMessage["lang"].ToString());

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
       
        }
    }
}
