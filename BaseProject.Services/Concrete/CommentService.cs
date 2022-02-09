using AutoMapper;
using BaseProject.Core;
using BaseProject.Core.Dtos.Comment;
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
    public class CommentService : ICommentService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<NoDataResponse> Add(CommentAddDto commentAddDto)
        {
            if (commentAddDto != null)
            {
                var comment = _mapper.Map<Comment>(commentAddDto);

                comment.Id = Guid.NewGuid().ToString();

                await _unitOfWork.Comments.AddAsync(comment);

                await _unitOfWork.CommitAsync();

                return new NoDataResponse(ResultStatus.Success, ResponseMessages.Comment.Add(comment.Text));
            }

            return new NoDataResponse(ResultStatus.Error, ResponseMessages.GeneralErrors.AddError());
        }

        public async Task<NoDataResponse> Delete(string commentId)
        {
            var comment = await _unitOfWork.Comments.GetAsync(c => c.Id == commentId);

            if (comment != null)
            {
                comment.IsActive = false;

                await _unitOfWork.Comments.UpdateAsync(comment);

                await _unitOfWork.CommitAsync();

                return new NoDataResponse(ResultStatus.Success, ResponseMessages.Comment.Delete(comment.Text));
            }
            return new NoDataResponse(ResultStatus.Error, ResponseMessages.Comment.NotFound(false));
        }

        public async Task<Response<List<CommentDto>>> GetCommentByArticle(string articleId)
        {
            var comments = await _unitOfWork.Comments.GetAllAsync(a => a.ArticleId == articleId && a.IsActive);

            if (comments.Count >= 0)
            {
                var commentsDto = _mapper.Map<List<Comment>, List<CommentDto>>((List<Comment>)comments);

                return new Response<List<CommentDto>>(ResultStatus.Success, commentsDto);
            }
            return new Response<List<CommentDto>>(ResultStatus.Error, ResponseMessages.Comment.NotFound(true));
        }
    }
}
