using BaseProject.Core.Dtos.UserDtos;
using BaseProject.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Services.Abstract
{
    public interface IUserService
    {
        Task<Response<UserDto>> CreateUserAsync(CreateUserDto createUserDto);

        Task<Response<UserDto>> GetUserByNameAsync(string userName);
    }
}
