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

namespace SUBD_books_project
{
    public partial class Form_UPDATE_BOOKS : Form
    {
        Database database = new Database();

        // Переменные для передачи значений из базы данных в формы textBox:
        String title; // Название книги
        int pages, id_publishing_house, id_book; // Количество страниц; id издателя; id книги, которую мы редактируем

        public Form_UPDATE_BOOKS()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // расположение формы по центру экрана
        }

        private void Form_UPDATE_BOOKS_Load(object sender, EventArgs e)
        {
            // Заполнение формы comboBox первичными ключами из таблицы (publishing_houses - издатели книг) с запретом вводить свои значения:
            DataTable publishing_houses = new DataTable();
            {
                SqlCommand command = new SqlCommand($"select id, title from publishing_houses;", database.getConnection());
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(publishing_houses);

                comboBox_publishing_houses.DataSource = publishing_houses;
                comboBox_publishing_houses.DisplayMember = "title";
                comboBox_publishing_houses.ValueMember = "id";
            }
            comboBox_publishing_houses.DropDownStyle = ComboBoxStyle.DropDownList;


            // Заполнение формы textBox значениями по id книги, которую мы редактируем:

            id_book = Form_main.id_book;
            database.openConnection();
            {

                SqlCommand command = new SqlCommand($"select title from books where id = @id_book", database.getConnection());
                command.Parameters.Add("@id_book", SqlDbType.Int).Value = id_book;
                title = command.ExecuteScalar().ToString();

                command = new SqlCommand($"select pages from books where id = @id_book", database.getConnection());
                command.Parameters.Add("@id_book", SqlDbType.Int).Value = id_book;
                pages = Int32.Parse(command.ExecuteScalar().ToString());

                command = new SqlCommand($"select id_publishing_house from books where id = @id_book", database.getConnection());
                command.Parameters.Add("@id_book", SqlDbType.Int).Value = id_book;
                id_publishing_house = Int32.Parse(command.ExecuteScalar().ToString());

            }
            database.closeConnection();

            // Как раз-таки здесь и используются переменные, объявленные выше
            label_id.Text = id_book.ToString();
            textBox_title.Text = title;
            textBox_pages.Text = pages.ToString();
            comboBox_publishing_houses.SelectedValue = id_publishing_house;
        }

        private void button_update_Click(object sender, EventArgs e) // Обработка события нажатия кнопки - редактирование записи в базе данных с условием, что ни одно из полей для ввода != null
        {
            if (textBox_title.Text == "" || textBox_pages.Text == "")
            {
                MessageBox.Show("1.Введите название книги.\r\n" +
                                "2.Укажите количество страниц.\r\n", "Несоответствие форме редактирования записи");
            }
            else
            {
                SqlCommand cmd = new SqlCommand($"update books set title = @title, pages = @pages, id_publishing_house = @id_publishing_house where id = @id_book;", database.getConnection());
                cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = textBox_title.Text;
                cmd.Parameters.Add("@pages", SqlDbType.Int).Value = Int32.Parse(textBox_pages.Text);
                cmd.Parameters.Add("@id_publishing_house", SqlDbType.Int).Value = comboBox_publishing_houses.SelectedValue;
                cmd.Parameters.Add("@id_book", SqlDbType.Int).Value = id_book;

                database.openConnection();

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Книга '" + textBox_title.Text + "' успешно обновлена.", "Редактирование книги...");

                    database.closeConnection();

                }
                else
                {
                    MessageBox.Show("Ошибка при редактировании данных.");
                }
            }
        }
    }
}
