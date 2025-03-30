using Braintree;
using Microsoft.Extensions.Configuration;
using OwlStock.Services.Interfaces;

namespace OwlStock.Services
{
    public class BraintreeService : IBraintreeService
    {
        private readonly IConfiguration _configuration;

        public BraintreeService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IBraintreeGateway CreateGateway()
        {
            return new BraintreeGateway()
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = _configuration["BraintreeGateway:MerchantId"],
                PublicKey = _configuration["BraintreeGateway:PublicKey"],
                PrivateKey = _configuration["BraintreeGateway:PrivateKey"]
            };
        }

        public IBraintreeGateway GetGateway()
        {
            return CreateGateway();
        }
    }
}
