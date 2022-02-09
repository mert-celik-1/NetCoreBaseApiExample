using BaseProject.Core.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProject.API.Validator
{

    public class AddArticleDtoValidator : AbstractValidator<ArticleAddDto>
    {
        public AddArticleDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Konu alanı boş bırakılamaz");

            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik alanı boş bırakılamaz");
        }
    }
}
