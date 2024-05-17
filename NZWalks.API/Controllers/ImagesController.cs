using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IUploadImageRepository uploadImageRepository;

        public ImagesController(IUploadImageRepository uploadImageRepository)
        {
            this.uploadImageRepository = uploadImageRepository;
        }
        // POST because we're uploading a image
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> UploadImage([FromForm] ImageUploadRequestDTO imageRequest )
        {
            ValidateFileUpload(imageRequest);

            if (ModelState.IsValid)
            {
                // first convert the DTO to Domain Model because repositories only deals with Domain Models
                var imageDomainModel = new Image
                {
                    File = imageRequest.File,
                    FileExtension = Path.GetExtension(imageRequest.File.FileName),
                    FileSizeInBytes = imageRequest.File.Length,
                    FileName = imageRequest.FileName,
                    FileDescription = imageRequest.FileDescription,
                    
                    // file path will be added from the repository instead
                };

                // use repository to upload image
                // use a repository interface and implementation to save the file to the local path and in the database 
                await uploadImageRepository.UploadImage(imageDomainModel);

                return Ok(imageDomainModel);
            }
            return BadRequest(ModelState);
        }

        // private validation method
        private void ValidateFileUpload(ImageUploadRequestDTO imageRequest)
        {
            // validate the extenstion

            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(imageRequest.File.FileName)) )
            {
                ModelState.AddModelError("file", "Unsupported file extension.");
            }

            // validate the size of the file 

            if (imageRequest.File.Length > 10485760) // 10 MB
            {
                ModelState.AddModelError("file", "File size more than 10MB, please upload a smaller file.");
            }
        }
    }
}
