﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{  
    public class Writer  //public olunca diğer sınıflardan ve tüm katmanlardan erişim sağlayabiliriz.
    {
        [Key]
        public int WriterID { get; set; }

        [StringLength(50)]
        public string WriterName { get; set; }

        [StringLength(50)]
        public string WriterSurName { get; set; }

        [StringLength(250)]
        public string WriterImage { get; set; }

        [StringLength(200)]
        public string WriterAbout { get; set; }

        [StringLength(50)]
        public string WriterMail { get; set; }

        [StringLength(20)]
        public string WriterPassword { get; set; }

        [StringLength(50)]
        public string WriterTitle { get; set; }

        public bool WriterStatus { get; set; }

        public ICollection<Heading> Headings { get; set; }  //bire çok ilişki Writer ile başlık ilişkili hale getirildi
                                                            // burada Writer sınıfını Heading sınıfı ile ilişkili olacak, ICollection türünde property oluşturdu

        public ICollection<Content> Contents { get; set; }
    }
}