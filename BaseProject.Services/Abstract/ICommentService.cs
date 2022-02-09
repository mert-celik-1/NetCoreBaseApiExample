using BaseProject.Core.Dtos.Comment;
using BaseProject.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Services.Abstract
{
    public interface ICommentService
    {
        Task<Response<List<CommentDto>>> GetCommentByArticle(string articleId);
        Task<NoDataResponse> Add(CommentAddDto commentAddDto);
        Task<NoDataResponse> Delete(string commentId);
    }
}
