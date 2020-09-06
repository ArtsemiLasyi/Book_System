using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Microsoft.Win32;
using System.Windows.Controls;
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
        private static String extension = ".library";
        private static String filter = "Library file (*" + extension +")|*" + extension;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Нажатие на кнопку "Добавить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbAdd_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi from Button_Click");
        }

        /// <summary>
        /// Нажатие на кнопку "Изменить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbEdit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi from Button_Click");
        }

        /// <summary>
        /// Нажатие на кнопку "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi from Button_Click");
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
            }
        }
    }
}
