using AutoMapper;
using SocailMedia.Data.DTO;
using SocailMedia.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();                    
        }
    }
}
