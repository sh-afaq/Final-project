using AutoMapper;
using IT.Business.Models;
using IT.Data.Models;


namespace IT.Business.DataServices
{
    public class BusinessEntityMappings:Profile
    {
        public BusinessEntityMappings() 
        { 
        CreateMap<UserModel,User>().ReverseMap();
        CreateMap<BlogModel, Blog>().
                ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl)).
                ReverseMap();
        }
    }
}
