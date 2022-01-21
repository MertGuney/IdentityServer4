using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UdemyIdentityServer.SecondApi.Models;

namespace UdemyIdentityServer.SecondApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class PicturesController : ControllerBase
    {
        public IActionResult GetPictures()
        {
            var pictures = new List<Picture>() {
                new Picture() { Id=1, Name="Doga0",Url="doga0resmi.jpg"},
                new Picture() { Id=2, Name="Doga1",Url="doga1resmi.jpg"},
                new Picture() { Id=3, Name="Doga2",Url="doga2resmi.jpg"},
                new Picture() { Id=4, Name="Doga3",Url="doga3resmi.jpg"},
            };
            return Ok(pictures);
        }
    }
}
