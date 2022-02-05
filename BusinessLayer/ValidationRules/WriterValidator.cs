using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Soyadı Kısmı Boş Geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Adresi Boş Geçilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre Boş Geçilemez");
            RuleFor(x => x.WriterPasswordAgain).NotEmpty().WithMessage("Şifre Boş Geçilemez");
            RuleFor(x => x.WriterPassword).Matches(@"[A-Z]+").WithMessage("Şifreniz En az bir büyük karekter içermeli");
            RuleFor(x => x.WriterPassword).Matches(@"[a-z]+").WithMessage("Şifreniz En az bir küçük karekter içermeli");
            RuleFor(x => x.WriterPassword).Matches(@"[0-9]+").WithMessage("Şifreniz En az bir rakam içermeli");
            RuleFor(x => x.WriterPassword).Matches(@"[\!\?\*\.]+").WithMessage("Şifreniz En az bir (!? *.) içermeli ");
            RuleFor(x => x.WriterPassword).Equal(x => x.WriterPasswordAgain).WithMessage("Şifreleriniz Uyuşmuyor");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen En az 2 karekter girişi yapın");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen En fazla 50 karekter girişi yapın");
        }
    }
}
