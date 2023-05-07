using Microsoft.Win32;
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
            //using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            //    if (filename == "")
            //    {
            //        if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            //        filename = saveFileDialog.FileName;

            //    }
            //book.SaveDB(filename);
        }

        private void Button_Open_Click(object sender, RoutedEventArgs e)
        {
            //using (OpenFileDialog openFileDialog = new OpenFileDialog())
            //{
            //    if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;

            //    filename = openFileDialog.FileName;
            //    //this.Text = filename + " - База данных книжного магазина";

            //    dataGridView1.Rows.Clear();
            //    book.OpenFile(filename);

            //    WriteToDataGrid();
            }
        }
    }

