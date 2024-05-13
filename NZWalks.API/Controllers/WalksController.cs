﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository )
        { 
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }
        // CREATE a new walk | POST

        [HttpPost]
        public async Task<IActionResult> CreateWalk([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            /*
             1. create a new request DTO for this method - inside the DTO folder: AddWalkRequestDto

             2. map the input parameter(DTO) to a Domain Model 
                2.1 create the mapping profile for Walk Domain Model and AddWalkRequestDto - inside Mappings folder
                2.2 inject IMapper from automapper using a constructor 

             3. call the repository for walks to create a new walk
                3.1 create the method definiton for the walk interface - inside the repositories folder - IWalksRepository 
                3.2 create the concreate implementation - inside the repositories folder - SQLWalkRepository 
                3.3 once this implementation is created, inject it in the Program.cs and in the constructor here(the interface only)  
                3.4 use this implementation to call the Create function and pass in the walk Domain Model 

            4. map Domain Model to DTO in order to send the response back to the client
                4.1 create a WalkDto class - inside the DTO folder 
                4.2 create a map for walkDto - inside the automapperprofie 
             */

            // map DTO to Domain Model - destination and source 
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);
            await walkRepository.CreateAsync(walkDomainModel);

            // map Domain Model to DTO and return it
            return Ok(mapper.Map<WalkDto>(walkDomainModel));

        }

    }
}