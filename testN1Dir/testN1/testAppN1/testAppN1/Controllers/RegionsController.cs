using Microsoft.AspNetCore.Mvc;

namespace testAppN1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : Controller
    {

        public RegionsController(NZ)
        {
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {

            return View();
        }
    }
}
