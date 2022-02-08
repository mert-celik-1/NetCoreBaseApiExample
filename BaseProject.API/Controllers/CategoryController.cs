using BaseProject.Core.Dtos.CategoryDtos;
using BaseProject.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetAll();

            return Ok(categories);
        }


        [HttpPost]
        public async Task<IActionResult> GetCategoryById(CategoryGetDto categoryGetDto)
        {
            var category = await _categoryService.Get(categoryGetDto.Id);

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryAddDto categoryAddDto)
        {
            await _categoryService.Add(categoryAddDto);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(CategoryUpdateDto categoryUpdateDto)
        {
            await _categoryService.Update(categoryUpdateDto);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(CategoryDeleteDto categoryDeleteDto)
        {
            await _categoryService.Delete(categoryDeleteDto.Id);

            return Ok();
        }

    }
}
