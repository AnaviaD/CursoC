using Microsoft.AspNetCore.Mvc;
using myWebApi.Models.Domain;

namespace myWebApi.Controllers
{
    //https://localhost:1234/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        //GET All regions
        //GET: https://localhost:portnumber/api/regions
        [HttpGet]
        public IActionResult GetAll() 
        {
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Auckland Region",
                    Code = "AKL",
                    RegionImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FAuckland&psig=AOvVaw1aLUGP7uuoamizszOaMo4n&ust=1720660710411000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCOie9eSmm4cDFQAAAAAdAAAAABAE"
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Wellington Region",
                    Code = "WLG",
                    RegionImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FAuckland&psig=AOvVaw1aLUGP7uuoamizszOaMo4n&ust=1720660710411000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCOie9eSmm4cDFQAAAAAdAAAAABAE"
                }
            };
            return Ok(regions);
        }
    }
}
