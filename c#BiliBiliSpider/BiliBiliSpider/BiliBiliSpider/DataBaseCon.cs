using System;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace BiliBiliSpider
{
    public class Database
    {
        MySqlConnection mycon;
        private String server = "localhost";
        private String database = "BiliBili";
        private String username = "root";
        private String password = "kirito";



        public bool databasecon()
        {
            string constr = "server=" + server
                + ";User Id=" + username
                + ";password=" + password
                + ";Database=" + database;
            try
            {
                mycon = new MySqlConnection(constr);
                mycon.Open();
            }

            catch
            {
                return false;
            }
            return true;
        }
        public MySqlConnection getconn()
        {
            return mycon;
        }

        public void closecon()
        {
            mycon.Close();
        }
    }
}
