using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NzWalksDbContext: DbContext
    {
        // constructor passed to the base class 
        public NzWalksDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
                
        }

        // DbSet - a property of DbContext class that represents a collection of entities in the databse. 

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }
    }
}
