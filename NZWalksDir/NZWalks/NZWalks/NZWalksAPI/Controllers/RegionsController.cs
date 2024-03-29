using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : Controller
    {
        private NZWalksDbContext _context;

        public RegionsController(NZWalksDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //Get Data From Database - Domain Models
            var regions = _context.Regions.ToList();

            //Map Ddomain models to Dtos
            var regionDto = new List<RegionDto>();
            foreach (var region in regions) 
            {
                regionDto.Add(new RegionDto()
                {
                    Id                  = region.Id,
                    Name                = region.Name,
                    Code                = region.Code,
                    RegionImageUrl      = region.RegionImageUrl,
                });
            }

            return Ok(regions);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id) 
        {
            var regionDomain = _context.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            var regionDto = new RegionDto
            {
                Id                  = regionDomain.Id,
                Name                = regionDomain.Name,
                Code                = regionDomain.Code,
                RegionImageUrl      = regionDomain.RegionImageUrl,
            };

            return Ok(regionDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDto regionRequest) 
        {
            //Map or convert DTO to domain Model
            var regionDomainModel = new Region 
            {
                Code                = regionRequest.Code,
                Name                = regionRequest.Name,
                RegionImageUrl      = regionRequest.RegionImageUrl,
            };

            //Use Domain Model to create Region
            _context.Regions.Add(regionDomainModel);
            _context.SaveChanges();

            var regionDto = new RegionDto
            {
                Id                  = regionDomainModel.Id,
                Name                = regionDomainModel.Name,
                Code                = regionDomainModel.Code,
                RegionImageUrl      = regionDomainModel.RegionImageUrl,

            };

            return CreatedAtAction(nameof(GetById), new {id = regionDto.Id}, regionDto);
        }
    }
}
