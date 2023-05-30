// @author Саранчин К.А.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainDateBase
{
    /// Класс описание книг
    public class Book
    {
        string author;
        string title;
        string genre;
        int year;
        int count;
        int price;

        public Book()
        {
            author = "";
            title = "";
            genre = "";
            year = 0;
            count = 0;
            price = 0; 
        }




        public Book(string author, string title, string genre, int year, int count, int price)
        {
            this.author = author;
            this.title = title;
            this.genre = genre;
            this.year = year;
            this.count = count;
            this.price = price;
        }

        public string Автор
        {
            
            get { return author; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Автор не может быть пустым");
            }
                    author = value; 
            }
        }

        public string Название
        {
            get { return title; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Название не может быть пустым");
                }
                title = value; 
            }
        }

        public string Жанр
        {
            get { return genre; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Жанр не может быть пустым");
                }
                genre = value; 
            }
        }

        public int Год
        {
            get { return year; }
            set {
                if (value <= 0)
                {
                    throw new ArgumentException("Год не может быть меньше или равен нулю");
                }
                year = value; 
            }
        }

        public int Количество
        {
            get { return count; }
            set { count = value; }
        }

        public int Цена
        {
            get { return price; }
            set { price = value; }
        }

        public override string ToString()
        {
            return author + "|" + title + "|" + genre + "|" +
                year + "|" + count + "|" + price;
        }
    }
}
