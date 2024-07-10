using Microsoft.AspNetCore.Mvc;
using myWebApi.Data;
using myWebApi.Models.Domain;

namespace myWebApi.Controllers
{
    //https://localhost:1234/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;

        public RegionsController(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        //GET All regions
        //GET: https://localhost:portnumber/api/regions
        [HttpGet]
        public IActionResult GetAll() 
        {
            var regions = dbContext.Regions.ToList();

            return Ok(regions);
        }
    }
}
