using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage
{
    public class Book
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"{Title} {Description} {Author} {Price} {Year}";
        }
    }
}
