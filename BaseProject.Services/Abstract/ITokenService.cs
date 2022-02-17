using BaseProject.Core;
using BaseProject.Core.Dtos.AuthenticationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Services.Abstract
{
    public interface ITokenService
    {
        TokenDto CreateToken(User user);
    }
}
