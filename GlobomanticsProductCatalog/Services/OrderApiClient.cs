using GlobomanticsProductCatalog.Data;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GlobomanticsProductCatalog.Services
{
    public class OrderApiClient
    {
        //For LOCAL
        //private const string API_URL = "https://localhost:1234";
        //For DEVELOPMENT
        //private const string API_URL = "https://api-dev.globomantics.com";
        //For STAGING
        //private const string API_URL = "https://api-staging.globomantics.com";
        //For PRODUCTION
        //private const string API_URL = "https://api.globomantics.com";

        //private int STORE_ID = 1234;

        private HttpClient HttpClient = new HttpClient();
        private OrderApiClientConfig config;

        public OrderApiClient(IOptions<OrderApiClientConfig> config)
        {
            HttpClient.DefaultRequestHeaders.Add("ApiKey", config.Value.ApiKey);

            this.config = config.Value;
        }

        public async Task PlaceOrder(Order order)
        {
            if (order.ProductId == 0)
            {
                throw new InvalidOperationException("Product ID not specified!");
            }

            var url = $"{this.config.ApiUrl}/api/create-order?storeId={this.config.StoreId}";

            //The API doesn't exist since this is just a sample, so 
            //don't uncomment the following lines! :) 
            //var response = await HttpClient.PostAsJsonAsync(url, order);
            //response.EnsureSuccessStatusCode();
        }


        public async Task CancelOrder(Order order)
        {
            var url = $"{this.config.ApiUrl}/api/cancel-order?storeId={this.config.StoreId}";

            //The API doesn't exist since this is just a sample, so 
            //don't uncomment the following lines! :) 
            //var response = await HttpClient.PostAsJsonAsync(url, order);
            //response.EnsureSuccessStatusCode();
        }
    }
}
