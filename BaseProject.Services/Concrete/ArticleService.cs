using AutoMapper;
using BaseProject.Core;
using BaseProject.Core.Dtos;
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
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<NoDataResponse> Add(ArticleAddDto articleAddDto)
        {
            if (articleAddDto!=null)
            {
                var article = _mapper.Map<Article>(articleAddDto);

                article.Id = Guid.NewGuid().ToString();

                await _unitOfWork.Articles.AddAsync(article);

                await _unitOfWork.CommitAsync();

                return new NoDataResponse(ResultStatus.Success, ResponseMessages.Article.Add(article.Title));
            }

            return new NoDataResponse(ResultStatus.Error, ResponseMessages.GeneralErrors.AddError());
        }

        public async Task<NoDataResponse> Delete(string articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);

            if (article!=null)
            {
                article.IsActive = false;

                await _unitOfWork.Articles.DeleteAsync(article);

                await _unitOfWork.CommitAsync();

                return new NoDataResponse(ResultStatus.Success, ResponseMessages.Article.Delete(article.Title));
            }
            return new NoDataResponse(ResultStatus.Error, ResponseMessages.Article.NotFound(false));
        }

        public async Task<Response<ArticleDto>> Get(string articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId, a => a.User, a => a.Category);
            
            if (article!=null)
            {
                var articleDto = _mapper.Map<ArticleDto>(article);

                return new Response<ArticleDto>(ResultStatus.Success, articleDto);
            }
            return new Response<ArticleDto>(ResultStatus.Error, ResponseMessages.Article.NotFound(false));
        }

        public async Task<Response<List<ArticleDto>>> GetAll()
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a=>a.IsActive, a => a.User, a => a.Category);

            if (articles.Count>=0)
            {
                 var articlesDto = _mapper.Map<List<Article>, List<ArticleDto>>((List<Article>)articles);

                return new Response<List<ArticleDto>>(ResultStatus.Success, articlesDto);
            }
            return new Response<List<ArticleDto>>(ResultStatus.Error, ResponseMessages.Article.NotFound(true));
        }

    

        public async Task<Response<List<ArticleDto>>> GetAllByCategory(string categoryId)
        {
            var articles = await _unitOfWork.Articles.GetAllAsync(a => a.CategoryId == categoryId && a.IsActive, ar => ar.User, ar => ar.Category);

            if (articles.Count >= 0)
            {
                var articlesDto = _mapper.Map<List<Article>, List<ArticleDto>>((List<Article>)articles);

                return new Response<List<ArticleDto>>(ResultStatus.Success, articlesDto);
            }
            return new Response<List<ArticleDto>>(ResultStatus.Error, ResponseMessages.Article.NotFound(true));
        }

        public async Task<NoDataResponse> HardDelete(string articleId)
        {
            var article = await _unitOfWork.Articles.GetAsync(a => a.Id == articleId);

            if (article !=null)
            {
                await _unitOfWork.Articles.DeleteAsync(article);
                await _unitOfWork.CommitAsync();
                return new NoDataResponse(ResultStatus.Success, ResponseMessages.Article.HardDelete(article.Title));
            }
            return new NoDataResponse(ResultStatus.Error, ResponseMessages.Article.NotFound(false));

        }
    

        public async Task<NoDataResponse> Update(ArticleUpdateDto articleUpdateDto)
        {
            var article = _mapper.Map<Article>(articleUpdateDto);
            
            await _unitOfWork.Articles.UpdateAsync(article);
            
            await _unitOfWork.CommitAsync();
            
            return new NoDataResponse(ResultStatus.Success, ResponseMessages.Article.Update(article.Title));
        }
    }
}
