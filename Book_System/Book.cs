using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_System
{
    [Serializable]
    public class Book : IComparable
    {

        // ISBN книги
        public string ISBN { get; private set; }

        // Название книги
        public string Name { get; private set; }

        // Автор книги
        public string Author { get; private set; }

        // Год написания книги
        public int Year { get; private set; }

        // Цена за книгу
        public decimal Price { get; private set; }

        // Издательство
        public string Publisher { get; private set; }

        public Book()
        {
            this.ISBN = "";
            this.Name = "";
            this.Author = "";
            this.Year = 0;
            this.Price = 0.00m;
            this.Publisher = "";
        }

        public bool IsEmpty()
        {
            if ((this.ISBN.Equals("")) || (this.Name.Equals("")))
                return true;
            else
                return false;
        }

        public Book(string isbn, string name, string author)
        {
            this.ISBN = isbn;
            this.Name = name;
            this.Author = author;
            this.Year = 0;
            this.Price = 0.00m;
            this.Publisher = "";
        }

        public Book(string isbn, string name, string author, int year, decimal price, string publisher)
        {
            this.ISBN = isbn;
            this.Name = name;
            this.Author = author;
            this.Year = year;
            this.Price = price;
            this.Publisher = publisher;
        }

        /// <summary>
        /// Приведение объекта к строковому виду
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string delimiter = "; ";
            string value = ": ";
            string ISBN = "ISBN";
            string name = "Название книги";
            string author = "Автор книги";
            string year = "Год написания";
            string price = "Цена";
            string publisher = "Издательство";
            string result = ISBN + value + this.ISBN + delimiter +
                            name + value + this.Name + delimiter +
                            author + value + this.Author + delimiter +
                            year + value + this.Year + delimiter +
                            price + value + this.Price + delimiter +
                            publisher + value + this.Publisher + delimiter;
            return result;
        }

        /// <summary>
        /// Сравнение с определенным объектом
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj == null) 
                return 1;

            Book tempBook = obj as Book;
            if (tempBook != null)
            {
                int ind1 = int.Parse(this.ISBN);
                int ind2 = int.Parse(tempBook.ISBN);
                if (ind1 == ind2)
                    return 0;
                else
                {
                    if (ind1 > ind2)
                        return 1;
                    else
                        return -1;
                }       
            }
            else
                throw new ArgumentException("Это не книга!");
        }

        /// <summary>
        /// Получение хэш-кода
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int isbn = this.ISBN.GetHashCode();
            int name = this.Name.GetHashCode();
            int author = this.Author.GetHashCode();
            int year = this.Year.GetHashCode();
            int publisher = this.Publisher.GetHashCode();
            int price = this.Price.GetHashCode();
            long hash = (isbn + name + author + price + year + publisher) % (int.MaxValue);
            int result = (int)hash;
            return result;
        }

        /// <summary>
        /// Проверка на идентичность двух объектов
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Book tempBook = obj as Book;
            if (tempBook != null)
            {
                int hash1 = GetHashCode();
                int hash2 = tempBook.GetHashCode();
                if (hash1 == hash2)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public static int BookComparison(Book book1, Book book2)
        {
            return book1.CompareTo(book2);
        }
    }
}
