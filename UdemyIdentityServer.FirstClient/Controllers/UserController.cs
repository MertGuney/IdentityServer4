using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UdemyIdentityServer.FirstClient.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetRefreshToken()
        {
            HttpClient httpClient = new HttpClient();
            var disco = await httpClient.GetDiscoveryDocumentAsync("https://localhost:5001");// token alıcağımız server
            if (disco.IsError)
            {
            }

            var refreshToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

            RefreshTokenRequest request = new RefreshTokenRequest();
            request.ClientId = _configuration["ClientResourceOwner:ClientId"];
            request.ClientSecret = _configuration["ClientResourceOwner:ClientSecret"];
            request.RefreshToken = refreshToken;
            request.Address = disco.TokenEndpoint;
            var token = await httpClient.RequestRefreshTokenAsync(request);
            if (token.IsError)
            {
                return RedirectToAction("Index", "Home");
            }
            var tokens = new List<AuthenticationToken>()
            {
                new AuthenticationToken{Name=OpenIdConnectParameterNames.IdToken,Value=token.IdentityToken},
                new AuthenticationToken{Name=OpenIdConnectParameterNames.RefreshToken,Value=token.RefreshToken},
                new AuthenticationToken{Name=OpenIdConnectParameterNames.AccessToken,Value=token.AccessToken},
                new AuthenticationToken{Name=OpenIdConnectParameterNames.ExpiresIn,Value=DateTime.UtcNow.AddSeconds(token.ExpiresIn).ToString("o",CultureInfo.InvariantCulture)},
            };

            var authenticationResult = await HttpContext.AuthenticateAsync();
            var properties = authenticationResult.Properties;

            properties.StoreTokens(tokens);

            await HttpContext.SignInAsync("Cookies", authenticationResult.Principal, properties);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync("Cookies"); // startup DefaultScheme
            //await HttpContext.SignOutAsync("oidc"); //startup DefaultChallengeScheme
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles ="admin")]
        public IActionResult AdminAction()
        {
            return View();
        }
        [Authorize(Roles = "admin,customer")]
        public IActionResult CustomerAction()
        {
            return View();
        }
    }
}
