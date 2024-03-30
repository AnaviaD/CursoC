using AutoMapper;
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
        private readonly IMapper autoMapper;

        public RegionsController(NZWalksDbContext context, 
            IRegionRepository regionRepository,
            IMapper autoMapper)
        {
            this._context               = context;
            this.regionRepository       = regionRepository;
            this.autoMapper             = autoMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get Data From Database - Domain Models
            var regions = await regionRepository.GetAllAsync();
            
            //Automapper converte Domain model a DTO 
            var regionsDTO = autoMapper.Map<List<RegionDto>>(regions);

            return Ok(regionsDTO);
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

            var regionDto = autoMapper.Map<RegionDto>(regionDomain);

            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto regionRequest) 
        {
            //Map or convert DTO to domain Model
            var regionDomainModel = autoMapper.Map<Region>(regionRequest);

            //Use Domain Model to create Region
            regionDomainModel =  await regionRepository.CreateAsync(regionDomainModel);

            var regionDto = autoMapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new {id = regionDto.Id}, regionDto);
        }



        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequest updateRequest)
        {

            var regionDomainModel = autoMapper.Map<Region>(updateRequest);

            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel != null)
            {
                return null;
            }

            var regionDto = autoMapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);
        }
    }
}
