﻿// @author Саранчин К.А.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainDateBase
{
    public class Book
    {
        string author;
        string title;
        string genre;
        int year;
        int count;
        int price;

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
            set { author = value; }
        }

        public string Название
        {
            get { return title; }
            set { title = value; }
        }

        public string Жанр
        {
            get { return genre; }
            set { genre = value; }
        }

        public int Год
        {
            get { return year; }
            set { year = value; }
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
