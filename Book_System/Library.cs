using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Book_System
{
    [Serializable]
    public class Library
    {

        // Содержимое библиотеки
        public ObservableCollection<Book> Content;

        // Название библиотеки
        public string Name { get; private set; }

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
    }
}
