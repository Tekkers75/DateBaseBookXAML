// @author Саранчин К.А.
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
            //DBBook dB = new DBBook();
            if (check_input())
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
        }

        private bool check_input()
        {
            SolidColorBrush error_color = new SolidColorBrush();
            SolidColorBrush usual_color = new SolidColorBrush();

            ///цвет ошибочных полей 
            error_color.Color = Color.FromRgb(252, 187, 187);
            /////цвет полей обычный
            usual_color.Color = Colors.White;

            bool hasError = false;

            if (string.IsNullOrWhiteSpace(textBox_Author.Text))
            {
                textBox_Author.Background = error_color;
                hasError = true;
            }
            else
            {
                textBox_Author.Background = usual_color;
            }

            if (string.IsNullOrWhiteSpace(textBox_Title.Text))
            {
                textBox_Title.Background = error_color;
                hasError = true;
            }
            else
            {
                textBox_Title.Background = usual_color;
            }

            if (string.IsNullOrWhiteSpace(textBox_Genre.Text))
            {
                textBox_Genre.Background = error_color;
                hasError = true;
            }
            else
            {
                textBox_Genre.Background = usual_color;
            }

            int year;
            if (!int.TryParse(textBox_Year.Text, out year))
            {
                textBox_Year.Background = error_color;
                hasError = true;
            }
            else
            {
                textBox_Year.Background = usual_color;
            }

            int count;
            if (!int.TryParse(textBox_Count.Text, out count))
            {
                textBox_Count.Background = error_color;
                hasError = true;
            }
            else
            {
                textBox_Count.Background = usual_color;
            }

            int price;
            if (!int.TryParse(textBox_Price.Text, out price))
            {
                textBox_Price.Background = error_color;
                hasError = true;
            }
            else
            {
                textBox_Price.Background = usual_color;
            }
            return !hasError;
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