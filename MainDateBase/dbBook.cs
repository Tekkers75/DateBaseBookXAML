using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainDateBase
{
    public class DBBook
    {
        // filename?

        // todo: observable list

        //List<Book> book = new List<Book>();
        //{
        //    new Book("1","1","1",2,2,3)
        //};

        public ObservableCollection<Book> books;


        /// Вернуть список
        //public List<Book> Book
        //{
        //    get { return book; }
        //}

        public DBBook()
        {
            books = new ObservableCollection<Book>();
        }

        /// Добавление книги в список
        public void AddBook(string author, string title, string genre, int year, int count, int price)
        {
            Book newBook = new Book(author, title, genre, year, count, price);
            books.Add(newBook);
        }


        /// Сохранить БД в файл
        public void SaveDB(string name)
        {
            ///Почитать
            using (StreamWriter sw = new StreamWriter(name, false, System.Text.Encoding.Unicode))
            {
                foreach (Book s in books)
                {
                    sw.WriteLine(s.ToString());
                }
            }
        }

        /// Открыть БД из файла
        public void OpenFile(string name)
        {
            if (!System.IO.File.Exists(name))
                throw new Exception("Файл не существует");

            if (books.Count != 0)
                DeleteDB();

            using (StreamReader sw = new StreamReader(name))
            {
                while (!sw.EndOfStream)
                {
                    string str = sw.ReadLine();
                    String[] dataFromFile = str.Split(new String[] { "|" },
                        StringSplitOptions.RemoveEmptyEntries);

                    string author = dataFromFile[0];
                    string title = dataFromFile[1];
                    string genre = dataFromFile[2];
                    int year = int.Parse(dataFromFile[3]);
                    int count = int.Parse(dataFromFile[4]);
                    int price = int.Parse(dataFromFile[5]);
                    AddBook(author, title, genre, year, count, price);
                }
            }
        }

        public void DeleteDB()
        {
            books.Clear();
        }

        public void DeleteBook(int ind)
        {
            books.RemoveAt(ind);
        }
    }
}

