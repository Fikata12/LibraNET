using LibraNET.Services.Data.Contracts;
using Microsoft.AspNetCore.Http;

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

		public string GetBookImageNameById(string bookImageId)
		{
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Books");

			var imageNames = Directory.GetFiles(filePath);

			var imagePath = imageNames.First(n => n.ToLower().Contains(bookImageId.ToLower()));

			var imageName = Path.GetFileName(imagePath);

			return imageName;
		}

		public string GetAuthorImageNameById(string authorImageId)
		{
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Authors");

			var imageNames = Directory.GetFiles(filePath);

			var imagePath = imageNames.First(n => n.Contains(authorImageId));

			var imageName = Path.GetFileName(imagePath);

			return imageName;
		}
	}
}
