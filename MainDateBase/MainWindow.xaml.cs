// @author Саранчин К.А.
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
using System.Windows.Threading;

namespace MainDateBase
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// Счетчик нажатий кнопки Сортировка
        int countCLICK = 0;
        public MainWindow()
        {
            InitializeComponent();
            /// todo
            /// как работает ItemSource
            datagrid.ItemsSource = Databook.books;
            //System.Windows.Threading.DispatcherTimer 
            Label_Save.Visibility = Visibility.Hidden;
            InitializeTimer();
        }

        ///Создание таймера для автосохранения
        DispatcherTimer timer = new DispatcherTimer();
        ///Создание таймера для скрытия надписи "автосохранение"
        DispatcherTimer timer1 = new DispatcherTimer();
        public DBBook Databook = new DBBook();
        public string filename = "";

        /// Обработчик события на нажатие кнопку Добавить
        /// Открывает новую форму
        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            FormAddBook addform = new FormAddBook();
            addform.Owner = this;
            addform.Show();
        }

        /// Обработчик события на нажатие кнопку Сохранить
        /// Открывается диалоговое окно для выбора пути и сохранения в файл
        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (filename == "")
            {
                if (saveFileDialog.ShowDialog() == DialogResult) return;
                filename = saveFileDialog.FileName;

            }
            Databook.SaveDB(filename);
        }

        /// Обработчик события на нажатие кнопку Открыть
        /// Открывается диалоговое окно для выбора пути и открытия файла
        private void Button_Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                filename = openFileDialog.FileName;
                //this.Text = filename + " - База данных книжного магазина";


                Databook.OpenFile(filename);

            }
        }

        /// Обработчик события на нажатие кнопку Удалить строку
        /// Удаляет выделенную строчку из базы данных
        private void Button_Del_Click(object sender, RoutedEventArgs e)
        {
            int ind = datagrid.SelectedIndex;
            Databook.books.RemoveAt(ind);

            //if (ind <= datagrid.Items.Count)
            //{
            //    book.
            //}
            //datagrid.Items.RemoveAt(ind);
            ////datagrid.
            //book.DeleteBook(ind);

        }

        /// Обработчик события на нажатие кнопку Удалить все
        /// Удаляет всю базу данных
        private void Button_Del_All_Click(object sender, RoutedEventArgs e)
        {
            Databook.books.Clear();
            //book.DeleteDB();
        }

        /// Создание таймера для автосохранения
        private void InitializeTimer()
        {
            // После истечения интервала, запускается обработчик события
            timer.Tick += new EventHandler(AutoSaveTimer);
            // Таймер с интервалом в 5 минут
            timer.Interval = new TimeSpan(0, 5, 0);
            // Запуск таймера 
            timer.Start();
            // Таймер с интервалом в 5 минут и 3 секунды
            timer1.Tick += new EventHandler(AutoSaveTimerHide);
            timer1.Interval = new TimeSpan(0, 5, 3);
            timer1.Start();
        }

        /// Обработчик события для автосохранения
        /// Сохраняет файл в выбранный файл и показывает надпись Автосохранение
        private void AutoSaveTimer(object sender, EventArgs e)
        {
            Databook.SaveDB(filename);
            Label_Save.Visibility = Visibility.Visible;
            timer.Start();
        }

        /// Обработчик события для автосохранения
        /// Скрывает надпись Автосохранение
        private void AutoSaveTimerHide(object sender, EventArgs e)
        {
            //Databook.SaveDB(filename);
            Label_Save.Visibility = Visibility.Hidden;
            timer.Start();
        }


        /// Обработчик события на нажатие кнопку Сортировка
        /// Сортирует базу данных по столбцу Автор
        private void Button_Sort_Click(object sender, RoutedEventArgs e)
        {
            countCLICK++; // увеличиваем счетчик на 1 при каждом нажатии на кнопку

            // проверяем значение счетчика и выполняем соответствующее действие
            if (countCLICK == 1)
            {
                //создаем обьект класса SortDescription . сортируем по столбцу "Author" по возрастанию
                var sortByName = new SortDescription("Автор", ListSortDirection.Ascending);
                //применяем сортировку
                datagrid.Items.SortDescriptions.Add(sortByName);
                //обновляем данные в таблице
                datagrid.Items.Refresh();
            }
            else if (countCLICK == 2)
            {
                //создаем обьект класса SortDescription . сортируем по столбцу "Author" по возрастанию
                var sortByName = new SortDescription("Автор", ListSortDirection.Descending);
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

        /// Обработчик события на нажатие кнопку меню, открыть
        /// Открывается диалоговое окно для выбора пути и открытия файла
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Button_Open_Click(sender, e);
        }

        /// Обработчик события на нажатие кнопку меню, сохранить
        /// Открывается диалоговое окно для выбора пути и сохранения в файл
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Button_Save_Click(sender, e);
        }

        /// Обработчик события на нажатие кнопку меню, Об авторе
        /// Показывает сообщение о разработчике
        private void Author_Click(object sender, RoutedEventArgs e)
        {
            string Info = "Разработчик: Саранчин К.А., студент группы ВМК-21\n\n";
            MessageBox.Show(Info, "О разработчике", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        

    }
}
