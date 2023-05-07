using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainDateBase
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            datagrid.ItemsSource = book.books;
        }

        public DBBook book = new DBBook();
        public string filename = "";

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            Window1 addform = new Window1();
            addform.Owner = this;
            addform.Show();
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (filename == "")
            {
                if (saveFileDialog.ShowDialog() == DialogResult) return;
                filename = saveFileDialog.FileName;

            }
            book.SaveDB(filename);
        }

        private void Button_Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                filename = openFileDialog.FileName;
                //this.Text = filename + " - База данных книжного магазина";


                book.OpenFile(filename);

            }
        }

        private void Button_Del_Click(object sender, RoutedEventArgs e)
        {
            int ind = datagrid.SelectedIndex;
            book.books.RemoveAt(ind);



            //if (ind <= datagrid.Items.Count)
            //{
            //    book.
            //}
            //datagrid.Items.RemoveAt(ind);
            ////datagrid.
            //book.DeleteBook(ind);


        }

        private void Button_Del_All_Click(object sender, RoutedEventArgs e)
        {
            book.books.Clear();
            //book.DeleteDB();
        }

        private void Button_Search_Click(object sender, RoutedEventArgs e)
        {
            FormSearch FS = new FormSearch();
            FS.Owner = this;
            FS.Show();
        }

        int countCLICK = 0;
        private void Button_Sort_Click(object sender, RoutedEventArgs e)
        {
            countCLICK++; // увеличиваем счетчик на 1 при каждом нажатии на кнопку

            // проверяем значение счетчика и выполняем соответствующее действие
            if (countCLICK == 1)
            {
                //создаем обьект класса SortDescription . сортируем по столбцу "Author" по возрастанию
                var sortByName = new SortDescription("Author", ListSortDirection.Ascending);
                //применяем сортировку
                datagrid.Items.SortDescriptions.Add(sortByName);
                //обновляем данные в таблице
                datagrid.Items.Refresh();
            }
            else if (countCLICK == 2)
            {
                //создаем обьект класса SortDescription . сортируем по столбцу "Author" по возрастанию
                var sortByName = new SortDescription("Author", ListSortDirection.Descending);
                //удаление сущ.фильтрации
                datagrid.Items.SortDescriptions.Clear();
                //применяем сортировку
                datagrid.Items.SortDescriptions.Add(sortByName);
                //обновляем данные в таблице
                datagrid.Items.Refresh();
            }
            else
            {

                countCLICK = 0;
                datagrid.Items.SortDescriptions.Clear();
            }
        }






    }
}
