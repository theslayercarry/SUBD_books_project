using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBD_books_project
{
    internal class Database
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-AO7O24K;Initial Catalog=db_books_conandoyle;Integrated Security=True");

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed) //Открываем соединение
                connection.Open();
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open) //Закрываем соединение
                connection.Close();
        }

        public SqlConnection getConnection()
        {
            return connection;
        }
    }
}
