using AutoMapper;
using LibraNET.Data.Models;
using LibraNET.Web.ViewModels;

namespace LibraNET.Services.Mapping
{
    public class LibraNetProfile : Profile
    {
        public LibraNetProfile()
        {
            CreateMap<Book, HomeBookViewModel>()
                .ForMember(d => d.ImageId, 
                opt => opt.MapFrom(s => s.ImageId.ToString()));
        }
    }
}
