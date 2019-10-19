using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace BookStore
{
    /// <summary>
    /// Connection string ile database'e erisim saglanan siniftir.Burada Singleton design pattern kullanilmistir.
    /// </summary>
    class Connection
    {
        private static string connectionString= "Data Source = den1.mssql7.gear.host; Initial Catalog = bookstore4; User Id = bookstore4; Password=123456789*";
        private static Connection connection;
        private static SqlConnection sqlConnection;

        public SqlConnection SqlConnetion
        {
            get { return sqlConnection; }
        }

        private Connection() { }

        public static Connection getInstance() ///Singleton tasarım kalıbı birden fazla conneciton üretmememizi sağlıyor.
        {
           
                if (connection == null)
                connection = new Connection();

                sqlConnection = new SqlConnection(connectionString);
                return connection;
            
          
        }

    }
}

