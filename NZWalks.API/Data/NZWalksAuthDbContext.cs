using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
        {
        }

        // create the roles

        protected override void OnModelCreating(ModelBuilder builder)
        { 
            base.OnModelCreating(builder);

            var readerRoleId = "bca0745f-ba35-4fa4-b1ad-124caa375bdd";
            var writerRoleId = "1a6fed20-e457-43ae-bdbb-698a092d3c8a";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = readerRoleId,
                    NormalizedName = "Reader".ToUpper()
                },

                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = writerRoleId,
                    NormalizedName = "Writer".ToUpper()
                }
            };

            // seed the roles: when we run EFC migration, it will see this data
            //if the roles don't exist in the database, the EFC migration will add them
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
