using BaseProject.Core.Entities;
using BaseProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Data.Abstract
{
    public interface IUserRefreshTokenRepository: IGenericRepository<UserRefreshToken>
    {
    }
}
