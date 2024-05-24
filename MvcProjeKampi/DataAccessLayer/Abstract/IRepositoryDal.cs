using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepositoryDal<T>  //bu metotların içerisini GenericRepository'de doldurduk.
    {
        // Burada oluşturulan metotlar interfacelerin tamamı için yapılmış olur. 
        // Çünkü ben tüm bu interfacelerin değerini IRepositoryDal'dan kalıtsal olarak aldım
        // IRepositoryDal içerisinde hangi metot tanımlanmışsa oluşturulan tüm interfaceler için geçerlidir.

        List<T> List(); //listeleme

        void Insert(T p); //ekleme

        T Get(Expression<Func<T, bool>> filter);

        void Update(T p); //güncelleme

        void Delete(T p); //silme

        List<T> List(Expression<Func<T, bool>> filter);  // şartlı listeleme (filtereleme yaparak listeleme yapar), 
        //örneğin sadece yazar adı ali olanları bu metot sayesinde getirebiliriz.
    }
}
