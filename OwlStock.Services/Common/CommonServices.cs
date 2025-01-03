
using Microsoft.Extensions.Configuration;
using OwlStock.Infrastructure.Common;
using System.Text.Json;
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

        public string GetEnumDescription(Enum enumeration)
        {
            if (string.IsNullOrEmpty(enumeration.ToString()))
            {
                throw new ArgumentNullException(nameof(enumeration));
            }

            CategoryDescriptions enumerationDescriptions = new();

            object field = enumerationDescriptions
                .GetType()
                .GetFields()
                .Where(f => f.Name.Contains(enumeration.ToString()))
                .Select(f => f.GetValue(enumerationDescriptions))
                .FirstOrDefault() ?? throw new NullReferenceException($"Member that contains name {enumeration} does not exists");

            return field.ToString() ?? "N/A";
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
