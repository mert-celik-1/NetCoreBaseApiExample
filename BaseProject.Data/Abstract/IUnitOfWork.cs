using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Data.Abstract
{
    public interface IUnitOfWork
    {
        IArticleRepository Articles { get; }
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        IUserRefreshTokenRepository RefreshTokens { get; }

        Task CommitAsync();

        void Commit();
    }
}
