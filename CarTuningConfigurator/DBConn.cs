using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CarTuningConfigurator
{
    public class DBConn
    {
        public MySqlConnection GetDefaultConnection()
        {
            string connectionString = $"server=10.195.252.88;user id=root;password=CasparBlond1200?;database=ctc;";
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
            } catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return conn;
        }

    }
}
