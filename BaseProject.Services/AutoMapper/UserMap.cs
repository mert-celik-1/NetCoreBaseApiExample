using AutoMapper;
using BaseProject.Core;
using BaseProject.Core.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Services.AutoMapper
{
    public class UserMap:Profile
    {
        public UserMap()
        {
            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
