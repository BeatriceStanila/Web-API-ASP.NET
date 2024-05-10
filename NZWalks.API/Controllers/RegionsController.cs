using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NzWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NzWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }


        // GET all regions: https://localhost:7125/api/Regions
        [HttpGet]  
        public async Task<IActionResult> GetAll()
        {
            // Get Data from Database - Domain Models
            var regionsDomain = await regionRepository.GetAllAsync();

            // Map/Convert Domain Models to DTOs
            // Automapper will convert the regionsDomain to RegionDTo
            // Return DTOs to the client
            return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
        }

        // GET region by ID: https://localhost:7125/api/Regions/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) 
        {

           // Get the Domain Model from Database

           //var region =  dbContext.Regions.Find(id);   only takes the primary key, so it can't be used to find a region by code, name or image

            var regionDomain = await regionRepository.GetById(id);
           
            if(regionDomain == null)
            {
                return NotFound();
            }

            // Map/Convert Domain Model to DTOs
                // Return DTO to the client
            return Ok(mapper.Map<RegionDto>(regionDomain));
            
        }

        // POST to create new region https://localhost:7125/api/Regions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Map/Convert DTO to Domain Model
            var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

            // Use Domain Model to create region
            //await dbContext.Regions.AddAsync(regionDomainModel);
            await regionRepository.CreateRegion(regionDomainModel);

             
            // Map Domain Model back to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            // POST method does not return an OK respone, instead returns an action 
            return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDto);
        }

        // UPDATE Region: https://localhost:7125/api/Regions/{id}
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute]  Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            // Map DTO to Domain model
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);
        

           regionDomainModel = await regionRepository.UpdateRegion(id, regionDomainModel);

            // If the region was not found
            if(regionDomainModel == null)
            {
                return NotFound();
            }

            // Return an OK respone
            // Convert Domain Model to DTO
             return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }


        // DELETE Region: https://localhost:7125/api/Regions/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel =  await  regionRepository.DeleteRegion(id);

            // If the region was not found
            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // return the deleted region back - this is optional
            // Map Domain Model to DTO
              return Ok(mapper.Map<RegionDto>(regionDomainModel));

        }
    }
}
