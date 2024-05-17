using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class ImageUploadRequestDTO
    {
        // this is all for separation of concerns, so we can have our request object different for our domain object
        // because we don't want to thightly couple the Domain object to the client 
        // we are accepting the POST requst as a DTO and then it will be mapped into Domain Model 

        [Required]
        public IFormFile File { get; set; }

        [Required]
        public string FileName { get; set; }

        public string? FileDescription { get; set; }

    }
}
