using NZWalks.API.Models.Domain;
using System.Runtime.InteropServices;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
        // need definitions of the methods I want to expose 
        // we expose the interface to the application not the implementation

        // GET ALL
      Task<List<Region>> GetAllAsync(); //this method will be use by the controller

        //GET BY ID
        Task<Region?> GetById(Guid id);

        //CREATE
        Task<Region> CreateRegion(Region region);

        //UPDATE
        Task<Region?> UpdateRegion(Guid id, Region region);

        //DELETE
        Task<Region?> DeleteRegion(Guid id);
    }
}
