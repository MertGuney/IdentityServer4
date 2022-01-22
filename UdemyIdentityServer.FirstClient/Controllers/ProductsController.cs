using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UdemyIdentityServer.FirstClient.Models;

namespace UdemyIdentityServer.FirstClient.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IConfiguration _configuration;

        public ProductsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products = new List<Product>();
            HttpClient client = new HttpClient();

            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");// token alıcağımız server
            if (disco.IsError)
            {
            }
            ClientCredentialsTokenRequest clientCredentialsTokenRequest = new ClientCredentialsTokenRequest();
            clientCredentialsTokenRequest.ClientId = _configuration["Client:ClientId"];
            clientCredentialsTokenRequest.ClientSecret = _configuration["Client:ClientSecret"];
            clientCredentialsTokenRequest.Address = disco.TokenEndpoint;
            var token = await client.RequestClientCredentialsTokenAsync(clientCredentialsTokenRequest);

            if (token.IsError)
            {
            }
            client.SetBearerToken(token.AccessToken);

            var response = await client.GetAsync("https://localhost:5016/api/products/getproducts");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<Product>>(content);
            }
            else
            {
            }

            return View(products);
        }
    }
}
