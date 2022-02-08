using BaseProject.Core.Dtos.CategoryDtos;
using BaseProject.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Services.Abstract
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAll();
        Task<Response<CategoryDto>> Get(string categoryId);
        Task<NoDataResponse> Add(CategoryAddDto categoryAddDto);
        Task<NoDataResponse> Update(CategoryUpdateDto categoryUpdateDto);
        Task<NoDataResponse> Delete(string categoryId);

    }
}
