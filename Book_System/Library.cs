using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_System
{
    public class Library
    {
        // ID библиотеки
        private Guid guid;

        // Содержимое библиотеки
        public List<Book> Content;

        // Название библиотеки
        public string Name { get; private set; }

        public Library()
        {
            this.guid = new Guid();
            this.Content = new List<Book>();
        }

        public Library(List<Book> content, string name)
        {
            this.guid = new Guid();
            this.Content = content;
            this.Name = name;
        }

        public Library(string name)
        {
            this.guid = new Guid();
            this.Content = new List<Book>();
            this.Name = name;
        }
    }
}
