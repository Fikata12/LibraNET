using Microsoft.AspNetCore.Http;

namespace LibraNET.Services.Data.Contracts
{
	public interface IImageService
	{
		Task<string> UploadBookImageAsync(IFormFile file);
		Task<string> UploadAuthorImageAsync(IFormFile file);
        string? GetBookImageNameById(string bookImageId);
        string? GetAuthorImageNameById(string authorImageId);
		Task EditBookImageAsync(IFormFile file, string imageId);
        Task EditAuthorImageAsync(IFormFile file, string imageId);
    }
}
