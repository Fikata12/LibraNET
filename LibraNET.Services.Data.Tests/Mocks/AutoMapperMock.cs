using AutoMapper;
using LibraNET.Data;
using LibraNET.Services.Mapping;
using Microsoft.EntityFrameworkCore;

namespace LibraNET.Services.Data.Tests.Mocks
{
	public class AutoMapperMock
	{
		public static IMapper Instance
		{
			get
			{
				var configuration = new MapperConfiguration(cfg => cfg.AddProfile<LibraNetProfile>());

				return configuration.CreateMapper();
			}
		}
	}
}
