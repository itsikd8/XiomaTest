using System;
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

            await ProcessRepositories(user);

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
    }


}
