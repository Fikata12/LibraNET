using LibraNET.Services.Data.Contracts;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace LibraNET.Services.Data
{
	public class ImageService : IImageService
	{
		public async Task<Guid> UploadBookImageAsync(IFormFile file)
		{
			Guid imageId = Guid.NewGuid();
			var fileName = imageId.ToString() + Path.GetExtension(file.FileName);
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Books", fileName);

			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(fileStream);
			}

			return imageId;
		}

		public async Task<Guid> UploadAuthorImageAsync(IFormFile file)
		{
			Guid imageId = Guid.NewGuid();
			var fileName = imageId.ToString() + Path.GetExtension(file.FileName);
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Authors", fileName);

			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(fileStream);
			}

			return imageId;
		}

		public string GetBookImageNameById(Guid bookImageId)
		{
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Books");

			var imageNames = Directory.GetFiles(filePath);

			var imagePath = imageNames.First(n => n.Contains(bookImageId.ToString()));

			var imageName = Path.GetFileName(imagePath);

			return imageName;
		}

		public string GetAuthorImageNameById(Guid bookImageId)
		{
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Authors");

			var imageNames = Directory.GetFiles(filePath);

			var imagePath = imageNames.First(n => n.Contains(bookImageId.ToString()));

			var imageName = Path.GetFileName(imagePath);

			return imageName;
		}
	}
}
