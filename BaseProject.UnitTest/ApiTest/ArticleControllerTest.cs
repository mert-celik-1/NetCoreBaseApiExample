using System.Collections.Generic;
using System.Threading.Tasks;
using BaseProject.API.Controllers;
using BaseProject.Core.Dtos;
using BaseProject.Services.Abstract;
using BaseProject.Shared.Response;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BaseProject.UnitTest.ApiTest
{
    public class ArticleControllerTest
    {
        private ArticleController _articleController;
        private Mock<IArticleService> _articleService;

        public ArticleControllerTest()
        {
            _articleService = new Mock<IArticleService>();
            _articleController = new ArticleController(_articleService.Object);
        }

        [Fact]
        public async void GetArticles_OkResult_Success()
        {
            List<ArticleDto> articles = new List<ArticleDto>();

            Response<List<ArticleDto>> response = new Response<List<ArticleDto>>(ResultStatus.Success, "test",articles);

            _articleService.Setup(x => x.GetAll()).Returns(Task.FromResult(response));

            var result = await _articleController.GetArticles();

            var okResult = Assert.IsType<OkObjectResult>(result);

            var returnArticles = Assert.IsType<Response<List<ArticleDto>>>(okResult.Value);

            Assert.Equal(returnArticles.Data, articles);  
        }

        [Fact]
        public async void AddArticle_OkResult_Success()
        {
            ArticleAddDto article = new ArticleAddDto();

            NoDataResponse response = new NoDataResponse(ResultStatus.Success, "test");

            _articleService.Setup(x => x.Add(article)).Returns(Task.FromResult(response));

            var result = await _articleController.AddArticle(article);

            var okResult = Assert.IsType<OkResult>(result);

            _articleService.Verify(x => x.Add(article), Times.Once);
        }



    }
}
