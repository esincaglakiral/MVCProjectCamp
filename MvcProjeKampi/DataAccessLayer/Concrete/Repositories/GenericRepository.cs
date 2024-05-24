using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepositoryDal<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;

        public GenericRepository() //constructor (ctor yazıp tab tuşuna iki kez basmalısın.)
        {
            _object = c.Set<T>();  //_object isimli field dışardan gönderilen değer neyse ona eşitlencek.
        }

        // constructor yapıcı metotdur, her bir class'ın kendi ismiyle constructor'ı vardır yani bu kod bloğunu ben yazmasam bile default olarak çalışır .
        // Aynı zamanda  class'ı Heap'te bellekte oluştururken yapmasını istediğin  bir işlem varsa bu yapıcı kod bloğuna yazarsın.
        // Benim burada yapmak istediğim işlem T değerine karşılık gelen sınıfı tutan _object e bir değer ataması yaptırmak.Setter değer vermeye,atamaya yarar, 
        // değeri yazdırma işlemini set ile yaparız.bu yüzdden c için T tipindeki   sınıfları yazdırıp, _object'e değer atamasını yaptık.
        // constructor ile class ı newlediğinde çalışan bloğu devreye soktuğunu unutmamalıyız.

        void IRepositoryDal<T>.Delete(T p)
        {
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            //_object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter); // sadece bir tane değer döndürcek, aşağıdakinden farklı olarak id bazlı tek bi değer döndürür.
        }

        void IRepositoryDal<T>.Insert(T p)
        {
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added; //Entity State Komutları ekleme işlemini _object field'i ile değilde Entity State Komutları ile yaptım
            //_object.Add(p);
            c.SaveChanges();
        }

        List<T> IRepositoryDal<T>.List()
        {
            return _object.ToList();  //ToList() metodu listeleme için kullanılır.
        }

        List<T> IRepositoryDal<T>.List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList(); // şartlı listeleme, buraada filtrelenmiş olan bir liste döndürür
        }

        void IRepositoryDal<T>.Update(T p)
        {
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
