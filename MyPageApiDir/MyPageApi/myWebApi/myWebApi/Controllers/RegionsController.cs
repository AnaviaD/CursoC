﻿using Microsoft.AspNetCore.Mvc;
using myWebApi.Data;
using myWebApi.Models.Domain;
using myWebApi.Models.DTO;

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
            //Get data from Database - Domain models
            var regions = dbContext.Regions.ToList();

            //Map Domain Models to Dtos
            var regionsDTO = new List<RegionDTO>();

            foreach (var region in regions)
            {
                regionsDTO.Add(new RegionDTO()
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl,
                });

            }

            //Return DTOs
            return Ok(regionsDTO);
        }


        //GET Single Region (Get Region By ID)
        //GET: https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            //Get region Domain model from Database
            var region = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (region == null)
            {
                return NotFound();
            }

            //Map Region Domain model to DTO
            var regionsDTO = new RegionDTO
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImageUrl = region.RegionImageUrl,
            };

            return Ok(regionsDTO);
        }


        [HttpPost]
        public IActionResult Create([FromBody] RegionRequestDTO addRegionRequest)
        { 
            var regionDomainModel  = new Region
            {
                Name            =   addRegionRequest.Name,
                Code            =   addRegionRequest.Code,
                RegionImageUrl  =   addRegionRequest.RegionImageUrl,
            };

            dbContext.Regions.Add(regionDomainModel);
            dbContext.SaveChanges();

            //Map domain model back to DTO
            var regionDTO = new RegionDTO
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };

            return CreatedAtAction(nameof(GetById), new { Id = regionDomainModel.Id }, regionDomainModel);
        }

        //Update Region
        //PUT: https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequest updatReq)
        {
            //check if region Exist
            var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if(regionDomainModel == null) return NotFound();

            //Map DTO to Domain model
            regionDomainModel.Name              = updatReq.Name;
            regionDomainModel.Code              = updatReq.Code;
            regionDomainModel.RegionImageUrl    = updatReq.RegionImageUrl;

            dbContext.SaveChanges();

            //Convert Domain Model to Dto
            var regionDto = new RegionDTO
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };

            return Ok(regionDto);

        }


        //Delete Region
        //Delete: https://localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteRegion([FromRoute] Guid id) 
        {
            var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomainModel == null) return NotFound();

            //Delete Region
            dbContext.Regions.Remove(regionDomainModel);
            dbContext.SaveChanges();

            return Ok();
        }


    }
}
