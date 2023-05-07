using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace MainDateBase
{
    /// <summary>
    /// Логика взаимодействия для FormSearch.xaml
    /// </summary>
    public partial class FormSearch : Window
    {
        public FormSearch()
        {
            InitializeComponent();
        }

        private void Button_Search_Click(object sender, RoutedEventArgs e)
        {
            MainWindow search = this.Owner as MainWindow;
            //if ((search.book.books.Count == 0) || (TextBox_Search.Text == ""))
            //    return;

            (search.datagrid.ItemsSource as DataTable).DefaultView.RowFilter = TextBox_Search.Text;
            


        }
    }
}
