using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Book_System
{
    [Serializable]
    public class Library
    {

        // Содержимое библиотеки
        public ObservableCollection<Book> Content;

        // Название библиотеки
        public string Name { get; set; }

        public Library()
        {
            this.Content = new ObservableCollection<Book>();
            this.Name = "";
        }

        public Library(ObservableCollection<Book> content, string name)
        {
            this.Content = content;
            this.Name = name;
        }

        public Library(string name)
        {
            this.Content = new ObservableCollection<Book>();
            this.Name = name;
        }

        /// <summary>
        /// Сортировка по ISBN
        /// </summary>
        /// <param name="content"></param>
        /// <param name="bydescending"></param>
        /// <returns></returns>
        public static IEnumerable<Book> SortByISBN(ObservableCollection<Book> content, bool orderbydescending)
        {
            if (orderbydescending)
                return content.OrderByDescending(x => x.ISBN);
            else
                return content.OrderBy(x => x.ISBN);
        }

        /// <summary>
        /// Сортировка по названию
        /// </summary>
        /// <param name="content"></param>
        /// <param name="bydescending"></param>
        /// <returns></returns>
        public static IEnumerable<Book> SortByName(ObservableCollection<Book> content, bool orderbydescending)
        {
            if (orderbydescending)
                return content.OrderByDescending(x => x.Name);
            else
                return content.OrderBy(x => x.Name);
        }

        /// <summary>
        /// Сортировка по автору
        /// </summary>
        /// <param name="content"></param>
        /// <param name="bydescending"></param>
        /// <returns></returns>
        public static IEnumerable<Book> SortByAuthor(ObservableCollection<Book> content, bool orderbydescending)
        {
            if (orderbydescending)
                return content.OrderByDescending(x => x.Author);
            else
                return content.OrderBy(x => x.Author);
        }

        /// <summary>
        /// Сортировка по цене
        /// </summary>
        /// <param name="content"></param>
        /// <param name="bydescending"></param>
        /// <returns></returns>
        public static IEnumerable<Book> SortByPrice(ObservableCollection<Book> content, bool orderbydescending)
        {
            if (orderbydescending)
                return content.OrderByDescending(x => x.Price);
            else
                return content.OrderBy(x => x.Price);
        }

        /// <summary>
        /// Сортировка по году
        /// </summary>
        /// <param name="content"></param>
        /// <param name="bydescending"></param>
        /// <returns></returns>
        public static IEnumerable<Book> SortByYear(ObservableCollection<Book> content, bool orderbydescending)
        {
            if (orderbydescending)
                return content.OrderByDescending(x => x.Year);
            else
                return content.OrderBy(x => x.Year);
        }

        /// <summary>
        /// Сортировка по издательству
        /// </summary>
        /// <param name="content"></param>
        /// <param name="bydescending"></param>
        /// <returns></returns>
        public static IEnumerable<Book> SortByPublisher(ObservableCollection<Book> content, bool orderbydescending)
        {
            if (orderbydescending)
                return content.OrderByDescending(x => x.Publisher);
            else
                return content.OrderBy(x => x.Publisher);
        }

    }
}
