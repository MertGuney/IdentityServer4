using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UdemyIdentityServer.FirstClient.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task LogOut()
        {

            await HttpContext.SignOutAsync("Cookies"); // startup DefaultScheme
            await HttpContext.SignOutAsync("oidc"); //startup DefaultChallengeScheme
        }
    }
}
