using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IUploadImageRepository
    {
        Task<Image> UploadImage(Image image); 
    }
}
