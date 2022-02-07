using AutoMapper;
using BaseProject.Core;
using BaseProject.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Services.AutoMapper
{
    public class ArticleMap:Profile
    {
        public ArticleMap()
        {
            CreateMap<ArticleAddDto, Article>().ReverseMap();
            CreateMap<ArticleUpdateDto, Article>().ReverseMap();
            CreateMap<ArticleDto, Article>().ReverseMap();
        }
        
    }
}
