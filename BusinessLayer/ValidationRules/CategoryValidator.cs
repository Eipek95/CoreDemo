using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori Açıklamasını Boş Geçemezsiniz");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("En fazla 50 karekter");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("En az 2 karekter");
        }
    }
}
