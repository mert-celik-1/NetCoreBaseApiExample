using BaseProject.Core;
using BaseProject.Core.Dtos.AuthenticationDtos;
using BaseProject.Core.Dtos.UserDtos;
using BaseProject.Core.Entities;
using BaseProject.Core.Repositories;
using BaseProject.Data.Abstract;
using BaseProject.Services.Abstract;
using BaseProject.Shared.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Services.Concrete
{
    public class AuthenticationService:IAuthenticationService
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IGenericRepository<UserRefreshToken> _userRefreshTokenService;

        public AuthenticationService(ITokenService tokenService, UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            //_userRefreshTokenService = userRefreshTokenService;
        }

        public async Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto)
        {
            if (loginDto == null) throw new ArgumentNullException(nameof(loginDto));

            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return new Response<TokenDto>(ResultStatus.Error, "Email or Password is wrong");

            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                return new Response<TokenDto>(ResultStatus.Error, "Email or Password is wrong");
            }
            var token = _tokenService.CreateToken(user);

            var userRefreshToken = await _unitOfWork.RefreshTokens.Where(x => x.UserId == user.Id).SingleOrDefaultAsync();

            if (userRefreshToken == null)
            {
                await _unitOfWork.RefreshTokens.AddAsync(new UserRefreshToken { UserId = user.Id, Code = token.RefreshToken, Expiration = token.RefreshTokenExpiration });
            }
            else
            {
                userRefreshToken.Code = token.RefreshToken;
                userRefreshToken.Expiration = token.RefreshTokenExpiration;
            }

            await _unitOfWork.CommitAsync();

            return  new Response<TokenDto>(ResultStatus.Success,token);
        }
        public async Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _unitOfWork.RefreshTokens.Where(x => x.Code == refreshToken).SingleOrDefaultAsync();

            if (existRefreshToken == null)
            {
                return new Response<TokenDto>(ResultStatus.Error, "Refresh Token Not Found");
            }

            var user = await _userManager.FindByIdAsync(existRefreshToken.UserId);

            if (user == null)
            {
                return new Response<TokenDto>(ResultStatus.Error, "User Id Not Found");
            }

            var tokenDto = _tokenService.CreateToken(user);

            existRefreshToken.Code = tokenDto.RefreshToken;
            existRefreshToken.Expiration = tokenDto.RefreshTokenExpiration;

            await _unitOfWork.CommitAsync();

            return new Response<TokenDto>(ResultStatus.Success, tokenDto);
        }

        public async Task<Response<NoDataResponse>> RevokeRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _unitOfWork.RefreshTokens.Where(x => x.Code == refreshToken).SingleOrDefaultAsync();
            if (existRefreshToken == null)
            {
                return new Response<NoDataResponse>(ResultStatus.Error, "Refresh Token Not Found");
            }

            await _unitOfWork.RefreshTokens.DeleteAsync(existRefreshToken);

            await _unitOfWork.CommitAsync();

            return new Response<NoDataResponse>(ResultStatus.Success,"Success");
        }
    }
}
