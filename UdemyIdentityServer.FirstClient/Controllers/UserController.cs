using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace UdemyIdentityServer.FirstClient.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
