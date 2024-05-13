using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() 
        {

            // REGION MAPPERS
            // get
            CreateMap<Region, RegionDto>().ReverseMap();

            // create
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();

            //update and delete
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();

            // WALK MAPPERS 
            // add walk
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
        }
    }
}
