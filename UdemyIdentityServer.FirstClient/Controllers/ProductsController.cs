using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UdemyIdentityServer.FirstClient.Models;
using UdemyIdentityServer.FirstClient.Services;

namespace UdemyIdentityServer.FirstClient.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IApiResourceHttpClient _apiResourceHttpClient;
        public ProductsController(IConfiguration configuration, IApiResourceHttpClient apiResourceHttpClient)
        {
            _configuration = configuration;
            _apiResourceHttpClient = apiResourceHttpClient;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient client = await _apiResourceHttpClient.GetHttpClient(); // token set edilmiş bir client nesnesi geliyor
            List<Product> products = new List<Product>();


            // bu işlemler gereksiz cünkü tokenı cookie den alıcaz
            //HttpClient client = new HttpClient();
            //var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");// token alıcağımız server
            //if (disco.IsError)
            //{
            //}
            //ClientCredentialsTokenRequest clientCredentialsTokenRequest = new ClientCredentialsTokenRequest();
            //clientCredentialsTokenRequest.ClientId = _configuration["Client:ClientId"];
            //clientCredentialsTokenRequest.ClientSecret = _configuration["Client:ClientSecret"];
            //clientCredentialsTokenRequest.Address = disco.TokenEndpoint;
            //var token = await client.RequestClientCredentialsTokenAsync(clientCredentialsTokenRequest);
            //if (token.IsError)
            //{
            //}
            //client.SetBearerToken(token.AccessToken);

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
