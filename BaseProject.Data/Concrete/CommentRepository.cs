using BaseProject.Core;
using BaseProject.Core.Repositories;
using BaseProject.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Data.Concrete
{
    public class CommentRepository: GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext context) : base(context)
        {
        }

        private AppDbContext AppDbContext
        {
            get { return _context as AppDbContext; }
        }
    }
}
