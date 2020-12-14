using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace TextXiomaApi
{
    class Program
    {
   
        static async Task Main(string[] args)
        {
            var user = new LoginUser()
            {
                UserName = "manager",
                Password = "1234",
                CompanyDB = "SBODEMOUS"
            };

            await ProcessRepositories1(user);

        }

        private static async Task ProcessRepositories(LoginUser user)
        {

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var httpClient = new HttpClient(clientHandler))
            {

                var options = new JsonSerializerOptions
                {
                    
                };


                StringContent content = new StringContent(JsonSerializer.Serialize(user, options), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("https://35.156.189.63:50000/b1s/v1/Login", content);

                string apiResponse = await response.Content.ReadAsStringAsync();
            }

            //HttpResponseMessage response = await client.PostAsync(
            //"https://35.156.189.63:50000/b1s/v1/Login", user);
            //response.EnsureSuccessStatusCode();
        }

        private static async Task ProcessRepositories1(LoginUser user)
        {

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            
            var cookieContainer  = new System.Net.CookieContainer();
            clientHandler.CookieContainer = cookieContainer;
            
            using (var httpClient = new HttpClient(clientHandler))
            {

                var options = new JsonSerializerOptions
                {

                };

                cookieContainer.Add(new Uri("https://35.156.189.63:50000/"), new Cookie("CompanyDB", "SBODEMOUS"));
                cookieContainer.Add(new Uri("https://35.156.189.63:50000/"), new Cookie("B1SESSION", "da007e8e-37f8-11eb-8000-025c0989ab50"));
                //StringContent content = new StringContent(JsonSerializer.Serialize(user, options), Encoding.UTF8, "application/json");

                var response = await httpClient.GetAsync("https://35.156.189.63:50000/b1s/v1/BusinessPartners");

                string apiResponse = await response.Content.ReadAsStringAsync();
            }

            
        }
    }


}
