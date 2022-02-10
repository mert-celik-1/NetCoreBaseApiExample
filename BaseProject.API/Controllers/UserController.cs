using BaseProject.Core.Dtos.UserDtos;
using BaseProject.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            var result=await _userService.CreateUserAsync(createUserDto);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetUserByUserName(GetUserDto getUserDto)
        {
            var result = await _userService.GetUserByNameAsync(getUserDto.UserName);

            return Ok(result);
        }


    }
}
