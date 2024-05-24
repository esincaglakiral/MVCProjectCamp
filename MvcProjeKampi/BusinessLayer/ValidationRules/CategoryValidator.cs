using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklamayı Boş Geçemezsiniz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayın");
        }
    }
}


// Eğer client taraflı (view tarafında) doğrulama yapılsaydı kullanıcı doğrulamayı bir kaç oynamayla rahatlıkla geçebilirdi. 
// fakat backend tarafına entegre edilmiş doğrulamayı geçemez. yani özet olarak projelerimizde client taraflı 
// doğrulamayı kullanıcıya bilgi vermek server taraflı doğrulamayı ise gerçekten datayı doğrulama yapmak için entegre ederiz.
// fluent validation kullanma sebebimiz olayı 1 kere yapıp her yerde kullanmak. 
// javascript le yapmak isteseydik her sayfada tekrar tekrar yazmak düzenlemek gerekebilirdi her sayfanın alanlarına göre. 
// fluent validation ile ise kategoriyi bir kere valide edip her sayfada bu class sayesinde validasyon yapabiliyoruz.

// Özetle: Client ve Server tabanlı olmak üzere 2 defa Validation işlemlerine tabi tutarız uygulamamızı.
// 1- Server tabanlı validation muhakkak uygulamamız gereken doğrulama işlemleridir.Çünlü kullanıcıdan doğru bir şekilde veri almamız gerekir.
// 2- Client tabanlı validation işlemleri zorunluluk olmamakla beraber kullanıcıyı doğru bir şekilde yönlendirmemizi sağlayan doğrulama işlemidir.
// Aralarındaki fark ise kullanıcı tarayıcı tarafından (client) validation işlemlerini rahatlıkla geçebilir.
// Bu durumda Server tarafında validation işlemleri uygulamadıysak sistemimizde istenmeyen veriler ve kontrolün bizden çıkması gibi durumlar ortaya çıkabilir.