using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {

        // this class implement the walk interface - CTRL DOT > Implement interface


        // inject the dbContext inside a constructor 
        private readonly NzWalksDbContext dbContext;
        public SQLWalkRepository(NzWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // post
        public async Task<Walk> CreateAsync(Walk walk)
        {
            // use the walk domain model and dbContext to save it to the database 
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        // get all
        public async Task<List<Walk>> GetAllAsync()
        {
            // use the dbContext to get the list of walks from the database
            return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();

        }

        // get by id
        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dbContext.Walks
                      .Include("Difficulty")
                      .Include("Region")
                      .FirstOrDefaultAsync(x => x.Id == id);
        
        }
    }
}
