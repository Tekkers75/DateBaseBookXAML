using MainDateBase;
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

namespace MainDateBase
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class FormAddBook : Window
    {
        public FormAddBook()
        {
            InitializeComponent();
        }

        private void Button_Add_Book_Click(object sender, RoutedEventArgs e)
        {

            MainWindow mForm = this.Owner as MainWindow;
            DBBook dB = new DBBook();
            try
            {
                string author = textBox_Author.Text;
                string title = textBox_Title.Text;
                string genre = textBox_Genre.Text;
                int year = int.Parse(textBox_Year.Text);
                int count = int.Parse(textBox_Count.Text);
                int price = int.Parse(textBox_Price.Text);

                textBox_Author.Text = "";
                textBox_Title.Text = "";
                textBox_Genre.Text = "";
                textBox_Year.Text = "";
                textBox_Count.Text = "";
                textBox_Price.Text = "";

                mForm.Databook.AddBook(author, title, genre, year, count, price);
                int n = mForm.Databook.books.Count;
            }
            catch
            {
                MessageBox.Show("Пустое поле");
            }
        }

        private void Button_Close_Form_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void textBox_Price_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}


//private void button_AddBook_Click(object sender, EventArgs e)
//{
//    MainWindow mForm = this.Owner as MainWindow;
//    DBBook dB = new DBBook();

//    /// Добавить пустой параметр? 
//    /// Добавить цвет поля
//    /// Добавить разные исключения, неправильный формат, пустое поле.
//   // try
//    {

//        string author = textBox_Author.Text;
//        string title = textBox_Title.Text;
//        string genre = textBox_Genre.Text;
//        int year = int.Parse(textBox_Year.Text);
//        int count = int.Parse(textBox_Count.Text);
//        int price = int.Parse(textBox_Price.Text);

//        textBox_Author.Text = "";
//        textBox_Title.Text = "";
//        textBox_Genre.Text = "";
//        textBox_Year.Text = "";
//        textBox_Count.Text = "";
//        textBox_Price.Text = "";

//        mForm.book.AddBook(author, title, genre, year, count, price);
//        int n = mForm.book.books.Count;   //int n = mForm.book.Book.Count;
//                                          //mForm.dataGridView1.Rows.Add(author, title, genre, year, count, price);


//        /// Как работать с DataSource, заранее делать список?
//        /// Иначе он не дает заполнить 
//        //mForm.book.books.Add(new Book(author, title, genre, year, count, price));
//        //mForm.book.books.Add (author, title, genre, year, count, price)
//        //mForm.dataGridView1.DataSource = mForm.book.books;


//    }
//    //catch
//    //{
//    //   // MessageBox.Show("Пустое поле");
//    //}
//}