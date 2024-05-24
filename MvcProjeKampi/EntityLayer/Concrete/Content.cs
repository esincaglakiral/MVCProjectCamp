using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content  //public olunca diğer sınıflardan ve tüm katmanlardan erişim sağlayabiliriz.
    {
        [Key]
        public int ContentID { get; set; }

        [StringLength(1000)]
        public string ContentValue { get; set; }

        public DateTime ContentDate { get; set; }

        public bool ContentStatus { get; set; }

        public int HeadingID { get; set; }  //bire çok ilişki oluşturacağımız sınıfın Primary Keyi (Id Name)
        public virtual Heading Heading { get; set; }  //Heading sınıfından Heading isminde bir property oluşturur.


        public int? WriterID { get; set; }  //bire çok ilişki oluşturacağımız sınıfın Primary Keyi (Id Name)
        public virtual Writer Writer { get; set; }  //Writer sınıfından Writer isminde bir property oluşturur.
    }
}
