using AutoMapper;
using BaseProject.Core;
using BaseProject.Core.Dtos.UserDtos;
using BaseProject.Services.Abstract;
using BaseProject.Services.Utilities;
using BaseProject.Shared.Response;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Services.Concrete
{
    public class UserService : IUserService
    {

        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;


        public UserService(UserManager<User> userManager,IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<Response<UserDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);

            user.Id = Guid.NewGuid().ToString();

            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return new Response<UserDto>(ResultStatus.Error, errors);
            }
            return new Response<UserDto>(ResultStatus.Success,ResponseMessages.User.Create());
        }

        public async Task<Response<UserDto>> GetUserByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            var userDto = _mapper.Map<UserDto>(user);

            if (user == null)
            {
                return new Response<UserDto>(ResultStatus.Error, ResponseMessages.User.NotFound());
            }

            return new Response<UserDto>(ResultStatus.Success, ResponseMessages.User.Get(userName),userDto);

        }

    }
}
