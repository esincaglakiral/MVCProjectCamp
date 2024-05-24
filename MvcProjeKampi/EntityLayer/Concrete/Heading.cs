using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Heading  //public olunca diğer sınıflardan ve tüm katmanlardan erişim sağlayabiliriz.
    {

        [Key]
        public int HeadingID { get; set; }

        [StringLength(50)]
        public string HeadingName { get; set; }

        public DateTime HeadingDate { get; set; }

        public bool HeadingStatus { get; set; }

        public int CategoryID { get; set; }  //bire çok ilişki oluşturacağımız sınıfın Primary Keyi (Id Name)
        public virtual Category Category { get; set; }  //Category sınıfından Category isminde bir property oluşturur.

        public int WriterID { get; set; }  //bire çok ilişki oluşturacağımız sınıfın Primary Keyi (Id Name)
        public virtual Writer Writer { get; set; }  //Writer sınıfından Writer isminde bir property oluşturur.


        public ICollection<Content> Contents { get; set; }  //bire çok ilişki, başlıkla içerik ilişkili hale getirildi.
        // burada Heading sınıfını Content sınıfı ile ilişkili olacak, ICollection türünde bir Contents propertysi oluşturdu
    }
}
