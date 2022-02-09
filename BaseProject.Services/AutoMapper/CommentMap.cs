using AutoMapper;
using BaseProject.Core;
using BaseProject.Core.Dtos.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Services.AutoMapper
{
    public class CommentMap:Profile
    {
        public CommentMap()
        {
            CreateMap<CommentAddDto, Comment>().ReverseMap();
            CreateMap<CommentDto, Comment>().ReverseMap();
        }
    }
}
