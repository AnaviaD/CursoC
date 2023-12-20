using Microsoft.AspNetCore.Mvc;

namespace Android.Controllers
{
    [ApiController]
    [Route("android")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("users")]
        public dynamic Homs()
        {
            //android/users
            return new
            {
                nombre = "jesus",
                edad = 33
            };
            
        }
    }
}
