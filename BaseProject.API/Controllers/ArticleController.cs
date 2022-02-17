using BaseProject.Core.Dtos;
using BaseProject.Core.Dtos.CategoryDtos;
using BaseProject.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
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
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            var articles = await _articleService.GetAll();

            return Ok(articles);
        }


        [HttpPost]
        public async Task<IActionResult> GetArticleById(ArticleGetDto articleGetDto)
        {
            var article=await _articleService.Get(articleGetDto.Id);

            return Ok(article);
        }

        [HttpPost]
        public async Task<IActionResult> AddArticle(ArticleAddDto articleAddDto)
        {
            await _articleService.Add(articleAddDto);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> EditArticle(ArticleUpdateDto articleUpdateDto)
        {
            await _articleService.Update(articleUpdateDto);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteArticle(ArticleDeleteDto articleDeleteDto)
        {
            await _articleService.Delete(articleDeleteDto.Id);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> GetArticlesByCategoryId(CategoryGetDto categoryGetDto)
        {
            var articles=await _articleService.GetAllByCategory(categoryGetDto.Id);

            return Ok(articles);
        }



    }
}
