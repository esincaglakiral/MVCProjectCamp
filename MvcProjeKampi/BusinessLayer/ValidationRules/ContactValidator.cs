using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresini Boş Geçemezsiniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adını Boş Geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Kısmını Boş Geçemezsiniz");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj İçeriği Kısmını Boş Geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Lütfen en az 5 karakter girişi yapınız");
            RuleFor(x => x.Subject).MaximumLength(40).WithMessage("Lütfen 40 karakterden fazla değer girişi yapmayın");
            RuleFor(x => x.Message).MinimumLength(25).WithMessage("Lütfen en az 25 karakter girişi yapınız");
            RuleFor(x => x.Message).MaximumLength(250).WithMessage("Lütfen 250 karakterden fazla değer girişi yapmayın");
        }
    }
}
