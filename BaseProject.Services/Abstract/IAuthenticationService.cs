using BaseProject.Core.Dtos.AuthenticationDtos;
using BaseProject.Core.Dtos.UserDtos;
using BaseProject.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Services.Abstract
{
    public interface IAuthenticationService
    {
        Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto);

        Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken);

        Task<Response<NoDataResponse>> RevokeRefreshToken(string refreshToken);

    }
}
