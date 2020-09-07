using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_System
{
    public class Book : IComparable
    {

        // ID книги
        private Guid guid;

        // ISBN книги
        public string ISBN { get; private set; }

        // Название книги
        public string Name { get; private set; }

        // Автор книги
        public string Author { get; private set; }

        // Год написания книги
        public string Year { get; private set; }

        // Цена за книгу
        public decimal Price { get; private set; }

        // Издательство
        public string Publisher { get; private set; }

        public Book()
        {
            this.guid = new Guid();
            this.Name = "UNNAMED";
            this.Author = "NONAME";
            this.Year = "-";
            this.Price = 0.00m;
            this.Publisher = "";
        }

        public Book(string name, string author)
        {
            this.guid = new Guid();
            this.Name = name;
            this.Author = author;
            this.Year = "-";
            this.Price = 0.00m;
            this.Publisher = "";
        }

        public Book(string name, string author, string year, decimal price, string publisher)
        {
            this.guid = new Guid();
            this.Name = name;
            this.Author = author;
            this.Year = year;
            this.Price = price;
            this.Publisher = publisher;
        }

        public override string ToString()
        {
            string delimiter = "; ";
            string value = ": ";
            string name = "Название книги";
            string author = "Автор книги";
            string year = "Год написания";
            string price = "Цена";
            string publisher = "Издательство";
            string result = name + value + this.Name + delimiter +
                            author + value + this.Author + delimiter +
                            year + value + this.Year + delimiter +
                            price + value + this.Price + delimiter +
                            publisher + value + this.Publisher + delimiter;
            return result;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) 
                return 1;

            Book tempBook = obj as Book;
            if (tempBook != null)
            {
                bool condition = this.Name.ToLower().Equals(tempBook.Name.ToLower());
                if (condition)
                    return 0;
                else
                    return 1;
            }
            else
                throw new ArgumentException("Object isn't a Book!");
        }
    }
}
