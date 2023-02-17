using AutoMapper;
using IT.Business.Models;
using IT.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT.Business.DataServices
{
    public class BusinessEntityMappings:Profile
    {
        public BusinessEntityMappings() 
        { 
        CreateMap<UserModel,User>().ReverseMap();
        CreateMap<BlogModel, Blog>().ReverseMap();
        }
    }
}
