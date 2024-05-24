using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresi boş bırakılamaz");
            //RuleFor(x => x.SenderMail).NotEmpty().WithMessage("Gönderici Adresini Boş Geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Kısmını Boş Geçemezsiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj İçeriği Kısmını Boş Geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Lütfen en az 5 karakter girişi yapınız");
            RuleFor(x => x.Subject).MaximumLength(40).WithMessage("Lütfen 40 karakterden fazla değer girişi yapmayın");
            RuleFor(x => x.MessageContent).MinimumLength(25).WithMessage("Lütfen en az 25 karakter girişi yapınız");
            RuleFor(x => x.MessageContent).MaximumLength(250).WithMessage("Lütfen 250 karakterden fazla değer girişi yapmayın");
        }
    
    }
}
