using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KütüphaneOtomasyonuBerke.Object.Books
{
   public class InsertBook
    {
        public string BookName { get; set; }
        public int Author { get; set; }
        public string PublisherName { get; set; }
        public DateTime ReleasedDate { get; set; }
        public Int16 PageCount { get; set; }
        public Int16 QuantityInStock { get; set; }
    }
}
