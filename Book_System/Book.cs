using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_System
{
    public class Book
    {
        public String Name { get; private set; }
        public String Author { get; private set; }
        public decimal Value { get; private set; }

        public Book()
        {
            this.Name = "";
            this.Author = "";
            this.Value = 0.00m;
        }
    }
}
