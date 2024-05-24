using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal) // constructor ( dependency injection)
        {
            _headingDal = headingDal;
        }

        public Heading GetByID(int id)
        {
            return _headingDal.Get(x => x.HeadingID == id);  // id'den gelen değerin eşit olup olmadığını sorgular
        }
        public List<Heading> GetList()
        {
            return _headingDal.List();
        }

        public List<Heading> GetListByWriter(int id) //writer paneli için sadece o writer'a (göndereceğimiz idye göre) bağlı başlıkları listelicek
        {
            return _headingDal.List(x => x.WriterID == id);
        }

   

        public void HeadingAddBL(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public void HeadingDeleteBL(Heading heading)
        {
            //heading.HeadingStatus = false;  // burada direk silmek yerine silinde status'u flase'a döncek
            _headingDal.Update(heading); // güncellicek 
        }

        public void HeadingUpdateBL(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
