using Microsoft.AspNetCore.Http;

namespace LibraNET.Services.Data.Contracts
{
	public interface IImageService
	{
		Task<Guid> UploadBookImageAsync(IFormFile file);
		Task<Guid> UploadAuthorImageAsync(IFormFile file);
		string GetBookImageNameById(string bookImageId);
		string GetAuthorImageNameById(string authorImageId);
	}
}
