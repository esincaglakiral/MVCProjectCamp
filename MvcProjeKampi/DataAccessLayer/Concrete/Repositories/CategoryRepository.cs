using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal

    //CategoryRepository sınıfı => ICategoryDal interface'inden miras alır. 
    //ICategoryDal implement interface yapılır ve içerisindeki metotlar buraya gelir. 
    //Burada da metotların görevlerini tanımlarız. Interface'te ise metotların türü ve isimleri tanımlanmıştı.

    {
        Context c = new Context();
        DbSet<Category> _object;

        public void Delete(Category p) // silme
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category p) // ekleme
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<Category> List()
        {
            return _object.ToList();  //ToList() metodu listeleme için kullanılır.
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)  // şartlı listeleme
        {
            throw new NotImplementedException();
        }

        public void Update(Category p)  // güncelleme
        {
            c.SaveChanges();  
        }
    }
}
