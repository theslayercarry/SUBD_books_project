using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SUBD_books_project.DB_Classes;

namespace SUBD_books_project
{
    public partial class Form_main : Form
    {
        Database database = new Database();

        public static int id_book;
        String check;
        public Form_main()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            CreateColumns();
            datagridview_update();

            ORM_uploading_data_testing(); // Тестирование ORM - загрузок
        }

        // Создание колонок для формы datagridview
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id_book", "id");
            dataGridView1.Columns.Add("title", "Название книги");
            dataGridView1.Columns.Add("pages", "Количество страниц");
            dataGridView1.Columns.Add("publishing_house", "Издатель");
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 245;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 210;
        }

        // Объявление типов считываемых данных
        private void ReadSingleRow_books(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetString(3));

        }

        // Выгрузка данных из базы данных в колонки datagridview
        private void RefreshDataGrid_books(DataGridView dwg)
        {
            dwg.Rows.Clear();

            SqlCommand command = new SqlCommand($"select books.id, books.title as 'Название книги', pages as 'Количество страниц', publishing_houses.title as 'Издатель' from books\r\njoin publishing_houses on books.id_publishing_house = publishing_houses.id;", database.getConnection());
            database.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_books(dwg, reader);
            }
            reader.Close();
        }

        private void button_insert_Click(object sender, EventArgs e) // Обработка нажатия кнопки - добавление записи
        {
            Form_INSERT_BOOKS frm1 = new Form_INSERT_BOOKS();
            this.Hide();
            frm1.ShowDialog();

            datagridview_update();

            this.Show();
        }

        private void button_update_Click(object sender, EventArgs e) // Обработка нажатия кнопки - редактирование записи
        {
            if (check != null) // проверка того, выбрана ли у нас запись
            {
                Form_UPDATE_BOOKS frm1 = new Form_UPDATE_BOOKS();
                this.Hide();
                frm1.ShowDialog();

                datagridview_update();

                this.Show();
            }
            else
                MessageBox.Show("Ни одна запись не выбрана.");
        }

        private void button_delete_Click(object sender, EventArgs e) // Обработка нажатия кнопки - удаление записи
        {
            if (check != null) // проверка того, выбрана ли у нас запись
            {
                SqlCommand command = new SqlCommand($"delete from books where id = @id_book", database.getConnection());
                command.Parameters.Add("@id_book", SqlDbType.Int).Value = id_book;

                database.openConnection();

                if (command.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("Запись успешно удалена.", "Удаление записи...");

                    datagridview_update();
                    database.closeConnection();
                }
            }
            else
                MessageBox.Show("Ни одна запись не выбрана.");
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e) // Данное событие срабатывает при клике на любую строку формы datagridview 
        {                                                                                  // (после этого в переменную id_book присваивается id книги из базы данных - row.Cells[0])
            int selectedRow = e.RowIndex;
            String i;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                i = row.Cells[0].Value.ToString();
                check = i;
                id_book = Convert.ToInt32(i);
            }
        }

        private void datagridview_update() // Метод для обновления значений формы datagridview после добавления, редактирования или удаления записи
        {
            RefreshDataGrid_books(dataGridView1);
            dataGridView1.ClearSelection();
            check = null;
        }

        private void ORM_uploading_data_testing()
        {
            /*// ВИДЫ ЗАГРУЗОК ORM И ВРЕМЯ ИХ ВЫПОЛНЕНИЯ: //
            // 1) Жадная загрузка (Eager Loading)
            var stopwatchEager = Stopwatch.StartNew();
            using (var context = new db_books_conandoyleContext())
            {
                var publishers_with_Books = context.PublishingHouses
                                              .Include(p => p.Books)
                                              .ToList();

                foreach (var publisher in publishers_with_Books)
                {
                    Console.WriteLine($"Издатель: {publisher.Title}");
                    foreach (var book in publisher.Books)
                    {
                        Console.WriteLine($"- Книга: \"{book.Title}\"");
                    }
                }
            }
            stopwatchEager.Stop();
            Console.WriteLine($"Жадная загрузка: {stopwatchEager.ElapsedMilliseconds} ms\n\n");


            // 2) Явная загрузка (Explicit Loading)
            var stopwatchExplicit = Stopwatch.StartNew();
            using (var context = new db_books_conandoyleContext())
            {
                var publisher = context.PublishingHouses.FirstOrDefault(p => p.Id == 1);

                if (publisher != null)
                {
                    context.Entry(publisher)
                           .Collection(p => p.Books)
                           .Load();

                    Console.WriteLine($"Издатель: {publisher.Title}");
                    foreach (var book in publisher.Books)
                    {
                        Console.WriteLine($"- Книга: \"{book.Title}\"");
                    }
                }
            }
            stopwatchExplicit.Stop();
            Console.WriteLine($"Явная загрузка: {stopwatchExplicit.ElapsedMilliseconds} ms\n\n");


            // 3) Ленивая загрузка (Lazy Loading)
            var stopwatchLazy = Stopwatch.StartNew();
            using (var context = new db_books_conandoyleContext())
            {
                var publisher = context.PublishingHouses.FirstOrDefault(p => p.Id == 1);

                if (publisher != null)
                {
                    Console.WriteLine($"Издатель: {publisher.Title}");
                    foreach (var book in publisher.Books)
                    {
                        Console.WriteLine($"- Книга: \"{book.Title}\"");
                    }
                }
            }
            stopwatchLazy.Stop();
            Console.WriteLine($"Ленивая загрузка: {stopwatchLazy.ElapsedMilliseconds} ms\n\n");*/


            // 1) Прямой SQL - запрос для получения всех издателей с их книгами
            var stopwatchSql = Stopwatch.StartNew();

            string queryString = $"select publishing_houses.title, books.title from publishing_houses\r\n  join books on publishing_houses.id = books.id_publishing_house;";
            database.openConnection();

            using (SqlCommand command = new SqlCommand(queryString, database.getConnection()))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string PublisherName = reader.GetString(0);
                        string bookTitle = reader.GetString(1);

                        Console.WriteLine($"Издатель: {PublisherName}, Книга - \"{bookTitle}\"");
                    }
                    reader.Close();
                }
            }

            stopwatchSql.Stop();
            Console.WriteLine($"Прямой SQL-запрос: {stopwatchSql.ElapsedMilliseconds} ms\n\n");


            // 2) Прямой SQL - запрос для получения конкретного издателя с его книгами
            stopwatchSql = Stopwatch.StartNew();

            queryString = $"select publishing_houses.title, books.title from publishing_houses\r\n  join books on publishing_houses.id = books.id_publishing_house where publishing_houses.id = @publishing_houses_id;";
            database.openConnection();

            using (SqlCommand command = new SqlCommand(queryString, database.getConnection()))
            {
                command.Parameters.AddWithValue("@publishing_houses_id", 6); // нужный ID издателя

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string PublisherName = reader.GetString(0);
                        string bookTitle = reader.GetString(1);

                        Console.WriteLine($"Издатель: {PublisherName}, Книга - \"{bookTitle}\"");
                    }
                    reader.Close();
                }
            }

            stopwatchSql.Stop();
            Console.WriteLine($"Прямой SQL-запрос (один автор): {stopwatchSql.ElapsedMilliseconds} ms\n\n");


            /*// Использование JOIN и LEFT JOIN: //
            // 1) JOIN
            Console.WriteLine($"\nJOIN:");
            using (var context = new db_books_conandoyleContext())
            {
                var publishers_with_Books = from book in context.Books
                                       join publisher in context.PublishingHouses
                                       on book.IdPublishingHouse equals publisher.Id
                                       select new
                                       {
                                           BookTitle = book.Title,
                                           Publiher = $"{publisher.Title}"
                                       };

                foreach (var item in publishers_with_Books)
                {
                    Console.WriteLine($"Книга: {item.BookTitle}, Издатель: {item.Publiher}");
                }
            }

            // 2) Left JOIN
            Console.WriteLine($"\nLeft JOIN:");
            using (var context = new db_books_conandoyleContext())
            {
                var publishers_with_Books = from book in context.Books
                                       join publisher in context.PublishingHouses
                                       on book.IdPublishingHouse equals publisher.Id into PublishersGroup
                                       from publisher in PublishersGroup.DefaultIfEmpty()
                                       select new
                                       {
                                           BookTitle = book.Title,
                                           Publiher = publisher != null ? $"{publisher.Title}" : "Неизвестный издатель"
                                       };

                foreach (var item in publishers_with_Books)
                {
                    Console.WriteLine($"Книга: {item.BookTitle}, Издатель: {item.Publiher}");
                }
            }*/
        }
    }
}
