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

			var imagePath = imagePaths.FirstOrDefault(n => n.ToLower().Contains(bookImageId.ToLower()));

			var imageName = Path.GetFileName(imagePath);

			return imageName;
		}

		public string? GetAuthorImageNameById(string authorImageId)
		{
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Authors");

			var imagePaths = Directory.GetFiles(filePath);

			var imagePath = imagePaths.FirstOrDefault(n => n.Contains(authorImageId));

			var imageName = Path.GetFileName(imagePath);

			return imageName;
		}

		public async Task<IFormFile> GetBookImageAsFormFile(string? bookImageId)
		{
			var imageName = GetBookImageNameById(bookImageId!);

			if (imageName == null)
			{
				return null!;
			}

			var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Books", imageName);

			byte[] imageBytes = await File.ReadAllBytesAsync(imagePath);

			return new FormFile(new MemoryStream(imageBytes), 0, imageBytes.Length, "image", imageName)
			{
				Headers = new HeaderDictionary(),
				ContentType = "image/jpeg"
			};
		}

		public async Task<IFormFile> GetAuthorImageAsFormFile(string? authorImageId)
		{
			var imageName = GetAuthorImageNameById(authorImageId!);

			if (imageName == null)
			{
				return null!;
			}

			var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Authors", imageName);

			byte[] imageBytes = await File.ReadAllBytesAsync(imagePath);

			return new FormFile(new MemoryStream(imageBytes), 0, imageBytes.Length, "image", imageName)
			{
				Headers = new HeaderDictionary(),
				ContentType = "image/jpeg"
			};
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

        string GetContentType(string imagePath)
		{
			switch (Path.GetExtension(imagePath).ToLower())
			{
				case ".jpg":
				case ".jpeg":
					return "image/jpeg";
				case ".png":
					return "image/png";
				default:
					return "image/jpeg";
			}
		}
	}
}
