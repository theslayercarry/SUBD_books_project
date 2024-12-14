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
    public partial class Form_INSERT_BOOKS : Form
    {
        Database database = new Database();
        public Form_INSERT_BOOKS()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen; // расположение формы по центру экрана
        }

        private void Form_INSERT_BOOKS_Load(object sender, EventArgs e)
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
        }

        private void button_insert_Click(object sender, EventArgs e) // Обработка события нажатия кнопки - добавление записи в базу данных с условием, что ни одно из полей для ввода != null
        {
            if (textBox_title.Text == "" || textBox_pages.Text == "")
            {
                MessageBox.Show("1.Введите название книги.\r\n" +
                                "2.Укажите количество страниц.\r\n", "Несоответствие форме добавления записи");
            }
            else
            {
                SqlCommand cmd = new SqlCommand($"insert into books (title, pages, id_publishing_house) values (@title, @pages, @id_publishing_house);", database.getConnection());
                cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = textBox_title.Text;
                cmd.Parameters.Add("@pages", SqlDbType.Int).Value = Int32.Parse(textBox_pages.Text);
                cmd.Parameters.Add("@id_publishing_house", SqlDbType.Int).Value = comboBox_publishing_houses.SelectedValue;

                database.openConnection();

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Книга '" + textBox_title.Text + "' успешно добавлена.", "Добавление книги...");

                    database.closeConnection();

                }
                else
                {
                    MessageBox.Show("Произошла ошибка при добавлении книги.", "Ошибка при добавлении...");
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_publishing_houses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
