using BaseProject.Core.Dtos;
using BaseProject.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Services.Abstract
{
    public interface IArticleService
    {
        Task<Response<List<ArticleDto>>> GetAll();
        Task<Response<List<ArticleDto>>> SearchArticles(int pageIndex, int pageSize);
        Task<Response<ArticleDto>> Get(string articleId);
        Task<Response<List<ArticleDto>>> GetAllByCategory(string categoryId);
        Task<NoDataResponse> Add(ArticleAddDto articleAddDto);
        Task<NoDataResponse> Update(ArticleUpdateDto articleUpdateDto);
        Task<NoDataResponse> Delete(string articleId);
        Task<NoDataResponse> HardDelete(string articleId);


    }
}
