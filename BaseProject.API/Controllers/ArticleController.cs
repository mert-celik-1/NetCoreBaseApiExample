using BaseProject.Core.Dtos;
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
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }


        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            var articles = await _articleService.GetAll();

            return Ok(articles);
        }

        [HttpPost]
        public async Task<IActionResult> AddArticle(ArticleAddDto articleAddDto)
        {
            await _articleService.Add(articleAddDto);

            return Ok();
        }


    }
}
