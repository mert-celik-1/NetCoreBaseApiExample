using BaseProject.Core.Dtos.Comment;
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
    public class CommentsController : ControllerBase
    {

        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        [HttpPost]
        public async Task<IActionResult> AddComment(CommentAddDto commentAddDto)
        {
            await _commentService.Add(commentAddDto);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComment(CommentDeleteDto commentDeleteDto)
        {
            await _commentService.Delete(commentDeleteDto.Id);

            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> GetCommentsByArticleId(CommentGetDto commentGetDto)
        {
            var comments = await _commentService.GetCommentByArticle(commentGetDto.Id);

            return Ok(comments);
        }


    }
}
