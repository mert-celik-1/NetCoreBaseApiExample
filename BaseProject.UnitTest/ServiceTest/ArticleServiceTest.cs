using AutoMapper;
using BaseProject.Core;
using BaseProject.Core.Dtos;
using BaseProject.Data.Abstract;
using BaseProject.Services.Abstract;
using BaseProject.Services.Cache;
using BaseProject.Services.Concrete;
using BaseProject.Services.Utilities;
using BaseProject.Shared.Response;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace BaseProject.UnitTest.ServiceTest
{
    public class ArticleServiceTest
    {
        private IArticleService _articleService;
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IMapper> _mapper;
        private Mock<ICacheService> _cache;
        public ArticleServiceTest()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _mapper = new Mock<IMapper>();
            _cache = new Mock<ICacheService>();
            _articleService = new ArticleService(_unitOfWork.Object, _mapper.Object,_cache.Object);
        }

        [Fact]
        public async void AddArticle_AddError_WhenDtoIsNull()
        {
            ArticleAddDto articleDto = null;

            var result=await _articleService.Add(articleDto);

            Assert.Equal(ResponseMessages.GeneralErrors.AddError(),result.Message);
            Assert.Equal(ResultStatus.Error,result.ResultStatus);

        }

        [Fact]
        public async void AddArticle_Succees()
        {
            Article article = new Article 
            {
                Category=new Category(),
                CategoryId="1",
                Content="test",
                IsActive=true,
                Title="test",
                User=new User(),
                UserId="1"
            };

            ArticleAddDto articleAddDto = new ArticleAddDto();

            _mapper.Setup(x => x.Map<Article>(articleAddDto)).Returns(article);
            _unitOfWork.Setup(x => x.Articles.AddAsync(article)).Returns(Task.FromResult(article));

            var result = await _articleService.Add(articleAddDto);

            Assert.Equal(ResponseMessages.Article.Add(article.Title), result.Message);
            Assert.Equal(ResultStatus.Success, result.ResultStatus);

        }

        [Fact]
        public async void DeleteArticle_NotFound_WhenArticleIsNull()
        {
            string articleId = "1";

            Article article = null;

            _unitOfWork.Setup(x => x.Articles.GetAsync(a=>a.Id==articleId)).Returns(Task.FromResult(article));

            var result = await _articleService.Delete(articleId);

            Assert.Equal(ResponseMessages.Article.NotFound(false), result.Message);
            Assert.Equal(ResultStatus.Error, result.ResultStatus);

        }

        [Fact]
        public async void DeleteArticle_Success()
        {
            string articleId = "1";

            Article article = new Article() { Title = "test" };

            _unitOfWork.Setup(x => x.Articles.GetAsync(a => a.Id == articleId)).Returns(Task.FromResult(article));

            var result = await _articleService.Delete(articleId);

            Assert.Equal(ResponseMessages.Article.Delete(article.Title), result.Message);
            Assert.Equal(ResultStatus.Success, result.ResultStatus);

        }

        [Fact]
        public async void GetArticle_NotFound_WhenArticleIsNull()
        {
            string articleId = "1";

            Article article = null;

            _unitOfWork.Setup(x => x.Articles.GetAsync(a => a.Id == articleId)).Returns(Task.FromResult(article));

            var result = await _articleService.Get(articleId);

            Assert.Equal(ResponseMessages.Article.NotFound(false), result.Message);
            Assert.Equal(ResultStatus.Error, result.ResultStatus);

        }

        [Fact]
        public async void GetArticle_Success()
        {
            string articleId = "1";

            Article article = new Article() { Title = "test" };

            _unitOfWork.Setup(x => x.Articles.GetAsync(a => a.Id == articleId, a => a.User, a => a.Category)).Returns(Task.FromResult(article));

            var result = await _articleService.Get(articleId);

            Assert.Equal(ResultStatus.Success, result.ResultStatus);

        }



    }
}
