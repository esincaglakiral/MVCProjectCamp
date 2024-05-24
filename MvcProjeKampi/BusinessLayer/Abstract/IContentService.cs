using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList(string p);
        List<Content> GetListByWriter(int id);

        List<Content> GetListByHeadingID(int id); //id'ye göre listeleme, mesela başlığa göre(başlığın id'si) tüm içerikleri getiricek

        void ContentAddBL(Content content);

        Content GetByID(int id);

        void ContentDeleteBL(Content content);

        void ContentUpdateBL(Content content);

    }
}
