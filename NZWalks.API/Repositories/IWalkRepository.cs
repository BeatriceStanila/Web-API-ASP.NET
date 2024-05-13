using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        // this create async method will create a new walk and return a task of type walk
       Task<Walk> CreateAsync(Walk walk);
    }
}
