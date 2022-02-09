using BaseProject.Core.Dtos.CategoryDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProject.API.Validator
{
    public class AddCategoryDtoValidator : AbstractValidator<CategoryAddDto>
    {
        public AddCategoryDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori alanı boş bırakılamaz");
        }
    }
}
