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
    public class CategoryRepository:GenericRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }
        private AppDbContext AppDbContext
        {
            get { return _context as AppDbContext; }
        }

        //public async Task<Category> GetById(string categoryId)
        //{
        //    return await AppDbContext.Categories.SingleOrDefaultAsync(c => c.Id == categoryId);
        //}
    }
}
