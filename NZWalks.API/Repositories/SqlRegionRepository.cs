using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SqlRegionRepository : IRegionRepository
    {
        // here we want to make use of DbContext class because it has to be used through the repository and not through the controller 

        private readonly NzWalksDbContext dbContext;
        public SqlRegionRepository(NzWalksDbContext dbContext)
        {
           this.dbContext = dbContext;
        }

        public NzWalksDbContext DbContext { get; }

        // implementation of the get all interface, that will be injected in the Program.cs file

        // GET ALL IMPLEMENTATION
        public async Task<List<Region>> GetAllAsync()
        {
            // use the dbContext class inside the method
            
           return await dbContext.Regions.ToListAsync();
        }

        // GET BY ID IMPLEMENTATION
        public async Task<Region?> GetById(Guid id)
        {
           return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        // CREATE IMPLEMENTATION
        public async Task<Region> CreateRegion(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        // UPDATE IMPLEMENTATION
        public async Task<Region> UpdateRegion(Guid id, Region region)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRegion == null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;  
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            
            await dbContext.SaveChangesAsync();
            return existingRegion;
        }

        // DELETE IMPLEMENTATION
        public async Task<Region?> DeleteRegion(Guid id)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRegion == null)
            {
                return null;
            }

            dbContext.Regions.Remove(existingRegion);
            await dbContext.SaveChangesAsync();

            return existingRegion;
            
        }
    }
}
