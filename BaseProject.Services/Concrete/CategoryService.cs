using AutoMapper;
using BaseProject.Core;
using BaseProject.Core.Dtos.CategoryDtos;
using BaseProject.Data.Abstract;
using BaseProject.Services.Abstract;
using BaseProject.Services.Utilities;
using BaseProject.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Services.Concrete
{
    public class CategoryService : ICategoryService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<NoDataResponse> Add(CategoryAddDto categoryAddDto)
        {
            if (categoryAddDto != null)
            {
                var category = _mapper.Map<Category>(categoryAddDto);

                category.Id = Guid.NewGuid().ToString();

                await _unitOfWork.Categories.AddAsync(category);

                await _unitOfWork.CommitAsync();

                return new NoDataResponse(ResultStatus.Success, ResponseMessages.Category.Add(category.Name));
            }

            return new NoDataResponse(ResultStatus.Error, ResponseMessages.GeneralErrors.AddError());
        }

        public async Task<NoDataResponse> Delete(string categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);

            if (category != null)
            {
                category.IsActive = false;

                await _unitOfWork.Categories.UpdateAsync(category);

                await _unitOfWork.CommitAsync();

                return new NoDataResponse(ResultStatus.Success, ResponseMessages.Category.Delete(category.Name));
            }
            return new NoDataResponse(ResultStatus.Error, ResponseMessages.Category.NotFound(false));
        }

        public async Task<Response<CategoryDto>> Get(string categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId, c => c.Articles);

            if (category != null)
            {
                var categoryDto = _mapper.Map<CategoryDto>(category);

                return new Response<CategoryDto>(ResultStatus.Success, categoryDto);
            }
            return new Response<CategoryDto>(ResultStatus.Error, ResponseMessages.Category.NotFound(false));
        }

        public async Task<Response<List<CategoryDto>>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(c => c.IsActive, c=>c.Articles);

            if (categories.Count >= 0)
            {
                var categoriesDto = _mapper.Map<List<Category>, List<CategoryDto>>((List<Category>)categories);

                return new Response<List<CategoryDto>>(ResultStatus.Success, categoriesDto);
            }
            return new Response<List<CategoryDto>>(ResultStatus.Error, ResponseMessages.Category.NotFound(true));
        }

        public async Task<NoDataResponse> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var category = _mapper.Map<Category>(categoryUpdateDto);

            await _unitOfWork.Categories.UpdateAsync(category);

            await _unitOfWork.CommitAsync();

            return new NoDataResponse(ResultStatus.Success, ResponseMessages.Category.Update(category.Name));
        }
    }
}
