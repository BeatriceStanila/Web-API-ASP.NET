
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NzWalksDbContext: DbContext
    {
        // constructor passed to the base class 
        public NzWalksDbContext(DbContextOptions<NzWalksDbContext> dbContextOptions): base(dbContextOptions)
        {
                
        }

        // DbSet - a property of DbContext class that represents a collection of entities in the databse. 
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }


        // SEEDING DATA IN THE DATABASE

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulties: Easy, Medium, Hard
            // Create a new list of domain models for difficulties 
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("de202478-e59d-4f14-b246-3660aeaf737a"), // get a GUID id using C# interactive: Guid.NewGuid()  View > Other Windows > C# interactive
                    Name = "Easy",
                },
                new Difficulty()
                {
                    Id = Guid.Parse("dbf62308-ff1e-4306-a6e0-f1423136c52b"),
                    Name = "Medium",
                },
                new Difficulty()
                {
                    Id = Guid.Parse("0b2c030b-dffa-4feb-b618-781a22ddfa22"),
                    Name = "Hard",
                }

            };

            // Seed the difficulties data into the database using the model building object and has data method
            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            // Seed data for Regions
            var regions = new List<Region>()
            {
                new Region
               {
                    Id = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                },
            };

            // Seed the regions data into the database
            modelBuilder.Entity<Region>().HasData(regions);

            // run Entity Framework Core migration with NuGet Package: Add-Migration, Update-Database

        }

    }
}
