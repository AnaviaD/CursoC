using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Controllers
{
    //  https://localhost:1234/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;

        public RegionsController(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        //Get All Regions method
        //  https://localhost:portnumber/api/regions
        [HttpGet]
        public IActionResult GetAll()
        {
            // Get Data From Database - Domain models
            var regions = dbContext.Regions.ToList();

            //Map Domain Models to DTOs
            var regionsDto = new List<RegionDto>();
            foreach (var region in regions)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl
                });
            }

            //Return DTOs
            return Ok(regionsDto);
        }


        //Get All Regions method
        //  https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id);
            var region = dbContext.Regions.FirstOrDefault(r => r.Id == id);

            if (region == null)
            {
                return NotFound();
            }

            //Map/Covert Region Domain Model to RegionDTO
            var regionIdDto = new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };

            //Return DTO back to client
            return Ok(regionIdDto);
        }



        //POST to create new Region
        //POST   https://localhost:portnumber/api/regions
        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDto addRegion)
        {
            //Map or Convert to Domain Model
            var regionDomainModel = new Region
            {
                Code = addRegion.Code,
                Name = addRegion.Name,
                RegionImageUrl = addRegion.RegionImageUrl
            };


            //Use Domain Model to create Region
            dbContext.Regions.Add(regionDomainModel);
            dbContext.SaveChanges();

            //Map Domain model back to DTO
            var regionDto = new RegionDto 
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetById), new {id = regionDomainModel.Id}, regionDto);

        }


        ////Get All Regions method
        ////  https://localhost:portnumber/api/regions
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var regions = new List<Region>
        //    {
        //        new Region
        //        {
        //            Id      = Guid.NewGuid(),
        //            Name    = "Auckaln Region",
        //            Code    = "AKL",
        //            RegionImageUrl  = "https://www.youtooproject.com/wp-content/uploads/2018/08/estudiar-en-auckland.jpg"
        //        },
        //        new Region
        //        {
        //            Id      = Guid.NewGuid(),
        //            Name    = "Wellington Region",
        //            Code    = "WLG",
        //            RegionImageUrl  = "https://www.youtooproject.com/wp-content/uploads/2018/08/image1-1.png"
        //        }
        //    };

        //    return Ok(regions);
        //}
    }
}
