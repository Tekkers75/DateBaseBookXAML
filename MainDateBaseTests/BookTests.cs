using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainDateBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MainDateBase.Tests
{
    [TestClass()]
    public class BookTests
    {
        [TestMethod()]
        public void BookTestНазвание()
        {
            Book book = new Book();

            Assert.AreEqual("", book.Название);

            book.Название = "Книга";
            Assert.AreEqual("Книга", book.Название);


            book.Название = "Один на один";
            Assert.AreEqual("Один на один", book.Название);

        }

        [TestMethod()]
        public void BookTestАвтор()
        {
            Book book = new Book();

            Assert.AreEqual("", book.Автор);

            book.Автор = "Достоевский";
            Assert.AreEqual("Достоевский", book.Автор);

            book.Автор = "Earo";
            Assert.AreEqual("Earo", book.Автор);
            

        }

        [TestMethod()]
        public void BookTestЖанр()
        {
            Book book = new Book();

            Assert.AreEqual("", book.Жанр);

            book.Жанр = "Роман";
            Assert.AreEqual("Роман", book.Жанр);

            book.Жанр = "Roman";
            Assert.AreEqual("Roman", book.Жанр);


        }


        [TestMethod()]
        public void BookTestГод()
        {
            Book book = new Book();

            Assert.AreEqual(0, book.Год);

            book.Год = 1994;
            Assert.AreEqual(1994, book.Год);

            book.Год = 2004;
            Assert.AreEqual(2004, book.Год);


        }



        [TestMethod()]
        public void BookTestКоличество()
        {
            Book book = new Book();

            Assert.AreEqual(0, book.Количество);

            book.Количество = 14;
            Assert.AreEqual(14, book.Количество);

            book.Количество = 4;
            Assert.AreEqual(4, book.Количество);

        }


        [TestMethod()]
        public void BookTestЦена()
        {
            Book book = new Book();

            Assert.AreEqual(0, book.Цена);

            book.Цена = 124;
            Assert.AreEqual(124, book.Цена);

            book.Цена = 16865;
            Assert.AreEqual(16865, book.Цена);

        }


        [TestMethod()]
        public void BookTestAll()
        {
            Book book = new Book("Достоевский", "Преступление и наказание", "Роман", 1865, 200,340);

            Assert.AreEqual("Достоевский", book.Автор);
            Assert.AreEqual("Преступление и наказание", book.Название);
            Assert.AreEqual("Роман", book.Жанр);
            Assert.AreEqual(1865, book.Год);
            Assert.AreEqual(200, book.Количество);
            Assert.AreEqual(340, book.Цена);

        }




    }
}