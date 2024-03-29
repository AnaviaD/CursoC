using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : Controller
    {
        private readonly NZWalksDbContext       _context;
        private readonly IRegionRepository      regionRepository;

        public RegionsController(NZWalksDbContext context, IRegionRepository regionRepository)
        {
            this._context               = context;
            this.regionRepository       = regionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get Data From Database - Domain Models
            var regions = await regionRepository.GetAllAsync();

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
        public async Task<IActionResult> GetById([FromRoute] Guid id) 
        {
            var regionDomain = await regionRepository.GetByIdAsync(id);

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
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto regionRequest) 
        {
            //Map or convert DTO to domain Model
            var regionDomainModel = new Region 
            {
                Code                = regionRequest.Code,
                Name                = regionRequest.Name,
                RegionImageUrl      = regionRequest.RegionImageUrl,
            };

            //Use Domain Model to create Region
            regionDomainModel =  await regionRepository.CreateAsync(regionDomainModel);

            var regionDto = new RegionDto
            {
                Id                  = regionDomainModel.Id,
                Name                = regionDomainModel.Name,
                Code                = regionDomainModel.Code,
                RegionImageUrl      = regionDomainModel.RegionImageUrl,

            };

            return CreatedAtAction(nameof(GetById), new {id = regionDto.Id}, regionDto);
        }



        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequest updateRequest)
        {

            var regionDomainModel = new Region
            { 
                Code = updateRequest.Code,
                Name = updateRequest.Name,
                RegionImageUrl= updateRequest.RegionImageUrl,
            };

            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel != null)
            {
                return null;
            }

            var regionDto = new RegionDto
            {
                Id                  = regionDomainModel.Id,
                Name                = regionDomainModel.Name,
                Code                = regionDomainModel.Code,
                RegionImageUrl      = regionDomainModel.RegionImageUrl,
            };

            return Ok(regionDto);
        }
    }
}
