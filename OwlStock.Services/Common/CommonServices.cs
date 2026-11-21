using Microsoft.Extensions.Configuration;
using OwlStock.Services.Interfaces;
using System.Text.Json.Nodes;

namespace OwlStock.Services.Common
{
    public class CommonServices : ICommonServices
    {
        private readonly IConfiguration _configuration;

        public CommonServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> VerifyReCaptcha(string response)
        {
            using HttpClient client = new();
            string verifyURL = _configuration["ReCaptcha:VerifyURL"] ?? throw new NullReferenceException("Key cannot be found (VerifyURL)");
            string secret = _configuration["ReCaptcha:SecretKey"] ?? throw new NullReferenceException("Key cannot be found (SecretKey)");
            
            MultipartFormDataContent content = new()
            {
                { new StringContent(response), "response" },
                { new StringContent(secret), "secret" }
            };

            HttpResponseMessage responseMessage = await client.PostAsync(verifyURL, content);

            if (responseMessage.IsSuccessStatusCode)
            {
                string responseString = await responseMessage.Content.ReadAsStringAsync();
                JsonNode? responseJSON = JsonNode.Parse(responseString);

                if (responseJSON != null)
                {
                    bool? success = (bool?)responseJSON["success"];

                    if (success != null && success == true)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
