using BaseProject.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Data.Concrete
{
    //User refresh token instance alinmasini duzelt
    public class UnitOfWork : IUnitOfWork
    {
        private ArticleRepository _articleRepository;
        private CategoryRepository _categoryRepository;
        private CommentRepository _commentRepository;
        private UserRefreshTokenRepository _userRefreshTokenRepository;
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }


        public IArticleRepository Articles => _articleRepository ?? new ArticleRepository(_context);

        public ICategoryRepository Categories => _categoryRepository ?? new CategoryRepository(_context);

        public ICommentRepository Comments => _commentRepository ?? new CommentRepository(_context);

        public IUserRefreshTokenRepository RefreshTokens => new UserRefreshTokenRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
