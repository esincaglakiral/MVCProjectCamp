
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal : IRepositoryDal<Category>  //ICategoryDal, IRepositoryDal içerisindeki metotları miras alıyor.
    {
        ////CRUD Operasyonlarını birer metot olarak tanımlıcaz
        

    }
}
