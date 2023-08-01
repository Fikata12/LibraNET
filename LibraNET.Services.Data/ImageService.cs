using LibraNET.Services.Data.Contracts;
using Microsoft.AspNetCore.Http;

namespace LibraNET.Services.Data
{
	public class ImageService : IImageService
	{
		public async Task<string> UploadBookImageAsync(IFormFile file)
		{
			Guid imageId = Guid.NewGuid();
			var fileName = imageId.ToString() + ".jpg";
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Books", fileName);

			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(fileStream);
			}

			return imageId.ToString();
		}

		public async Task<string> UploadAuthorImageAsync(IFormFile file)
		{
			Guid imageId = Guid.NewGuid();
			var fileName = imageId.ToString() + ".jpg";
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Authors", fileName);

			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(fileStream);
			}

			return imageId.ToString();
		}

		public string? GetBookImageNameById(string bookImageId)
		{
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Books");

			var imagePaths = Directory.GetFiles(filePath);

			var imagePath = imagePaths.FirstOrDefault(p => p.ToLower().Contains(bookImageId.ToLower()));

			var imageName = Path.GetFileName(imagePath);

			return imageName;
		}

		public string? GetAuthorImageNameById(string authorImageId)
		{
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Authors");

			var imagePaths = Directory.GetFiles(filePath);

			var imagePath = imagePaths.FirstOrDefault(p => p.ToLower().Contains(authorImageId.ToLower()));

			var imageName = Path.GetFileName(imagePath);

			return imageName;
		}

        public async Task EditBookImageAsync(IFormFile file, string imageId)
        {
            var fileName = imageId + ".jpg";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Books", fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
        }

        public async Task EditAuthorImageAsync(IFormFile file, string imageId)
        {
            var fileName = imageId + ".jpg";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Authors", fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
        }

	}
}
