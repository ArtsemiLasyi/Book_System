using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_System
{
    class BookComparer : IComparer<Book>
    {
        public int Compare(Book book1, Book book2)
        {
            int ind1 = int.Parse(book1.ISBN);
            int ind2 = int.Parse(book2.ISBN);
            if (ind1 > ind2)
                return 1;
            else if (ind1 < ind2)
                return -1;
            else
                return 0;
        }
    }
}
