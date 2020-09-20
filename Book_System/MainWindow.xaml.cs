using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Microsoft.Win32;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Book_System
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        delegate IEnumerable<Book> SortCollection(ObservableCollection<Book> content, bool bydescending);
        private static string extension = ".library";
        private static string filter = "Library file (*" + extension + ")|*" + extension;
        public static Library activeLibrary = new Library();
        public static Book activeBook;
        private static Dictionary<string, SortCollection> sortList = new Dictionary<string, SortCollection>
        {
            ["ISBN"] = Library.SortByISBN,
            ["Название"] = Library.SortByName,
            ["Автор"] = Library.SortByAuthor,
            ["Год написания"] = Library.SortByYear,
            ["Цена"] = Library.SortByPrice,
            ["Издательство"] = Library.SortByPublisher
        };

        public MainWindow()
        {
            InitializeComponent();
            lvBooksList.ItemsSource = activeLibrary.Content;
            cbSortList.ItemsSource = sortList.Keys;
        }

        /// <summary>
        /// Нажатие на кнопку "Добавить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbAdd_Click(object sender, RoutedEventArgs e)
        {
            activeBook = new Book();
            new EditBookWindow().ShowDialog();
        }

        /// <summary>
        /// Нажатие на кнопку "Изменить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbEdit_Click(object sender, RoutedEventArgs e)
        {
            activeBook = (Book)lvBooksList.SelectedItem;
            new EditBookWindow().ShowDialog();
        }

        /// <summary>
        /// Нажатие на кнопку "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbDelete_Click(object sender, RoutedEventArgs e)
        {
            Book temp = (Book)lvBooksList.SelectedItem;
            activeLibrary.Content.Remove(temp);
        }

        /// <summary>
        /// Нажатие на кнопку "Создать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbNewFile_Click(object sender, RoutedEventArgs e)
        {
            activeLibrary.Content.Clear();
            lvBooksList.ItemsSource = activeLibrary.Content;
        }

        /// <summary>
        /// Нажатие на кнопку "Открыть"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = filter;
            if ((bool)openFileDialog.ShowDialog())
            {
                // Успешное открытие файла
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    try
                    {
                        activeLibrary.Content.Clear();
                        Library tempLibrary = (Library)formatter.Deserialize(fs);
                        foreach (Book temp in tempLibrary.Content)
                            activeLibrary.Content.Add(temp);
                        tbLibraryName.Text = tempLibrary.Name;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Нажатие на кнопку "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbSaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = filter;
            if ((bool)saveFileDialog.ShowDialog())
            {
                // Успешное сохранение файла
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate))
                {
                    try
                    {
                        activeLibrary.Name = tbLibraryName.Text;
                        formatter.Serialize(fs, activeLibrary);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void cbSortList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sort(activeLibrary);
        }

        private void cbInvert_Checked(object sender, RoutedEventArgs e)
        {
            Sort(activeLibrary);
        }

        private void Sort(Library library)
        {
            if (cbSortList.SelectedItem == null)
                return;
            foreach (var elem in sortList)
            {
                if (elem.Key.Equals(cbSortList.SelectedItem.ToString()))
                {
                    lvBooksList.ItemsSource = elem.Value(library.Content, (bool)cbInvert.IsChecked);
                }
            }
        }
    }
}
