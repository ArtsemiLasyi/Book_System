using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Book_System
{
    /// <summary>
    /// Логика взаимодействия для AddBook.xaml
    /// </summary>
    public partial class EditBookWindow : Window
    {
        public EditBookWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Подтверждение изменения книги
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbOk_Click(object sender, RoutedEventArgs e)
        {
            // Проверка данных
            if (tbBookName.Text.Equals(""))
            {
                MessageBox.Show("Название книги не должно быть пустым!");
            }
            else
            {
                string isbn = tbBookISBN.Text.Trim();
                isbn = isbn.ToUpper().Replace("-", "");
                isbn = isbn.Replace(" ", "").Trim();
                if (!IsCorrectISBN(isbn))
                {
                    MessageBox.Show("Некорректный ISBN!");
                }
                else
                {
                    string name = tbBookName.Text.Trim();
                    string author = tbBookAuthor.Text.Trim();
                    int year;
                    decimal price;
                    try
                    {
                        price = decimal.Parse(tbBookYear.Text.Trim());
                        year = int.Parse(tbBookYear.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("Некорректная цена и/или год!");
                        return;
                    }
                    string publisher = tbBookPublisher.Text.Trim();

                    //Изменение текущей библиотеки
                    if (MainWindow.activeBook.IsEmpty())
                    {
                        MainWindow.activeBook = new Book(isbn, name, author, year, price, publisher);
                        MainWindow.activeLibrary.Content.Add(MainWindow.activeBook);
                    }
                    else
                    {
                        int index = MainWindow.activeLibrary.Content.IndexOf(MainWindow.activeBook);
                        MainWindow.activeLibrary.Content.Remove(MainWindow.activeBook);
                        MainWindow.activeBook = new Book(isbn, name, author, year, price, publisher);
                        MainWindow.activeLibrary.Content.Insert(index, MainWindow.activeBook);
                    }
                    ClearTextBoxes();
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Отмена изменения книги
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes();
            this.Close();
        }

        /// <summary>
        /// Очистка текстовых полей
        /// </summary>
        private void ClearTextBoxes()
        {
            tbBookName.Text = "";
            tbBookAuthor.Text = "";
            tbBookYear.Text = "";
            tbBookPrice.Text = "";
            tbBookPublisher.Text = "";
        }


        /// <summary>
        /// Проверка ISBN на корректность
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        private bool IsCorrectISBN(string isbn)
        {
            int[] numbers;    //массив цифр
            int sum = 0;      // контрольная сумма   
            
            numbers = isbn.ToCharArray().Select(i => i == 'X' ? 10 : int.Parse(i.ToString())).ToArray();
            
            if (numbers.Length == 10)
            {
                for (int i = 0; i < numbers.Length; i++)
                    sum += numbers[i] * (10 - i);
                if (sum % 11 == 0)
                    return true;
                else
                    return false;
            }
            else if (numbers.Length == 13)
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// При появлении окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            if (MainWindow.activeBook != null)
            {
                tbBookName.Text = MainWindow.activeBook.Name;
                tbBookAuthor.Text = MainWindow.activeBook.Author;
                tbBookISBN.Text = MainWindow.activeBook.ISBN;
                tbBookPrice.Text = MainWindow.activeBook.Price.ToString();
                tbBookYear.Text = MainWindow.activeBook.Year.ToString();
                tbBookPublisher.Text = MainWindow.activeBook.Publisher.ToString();
            }
        }
    }
}
