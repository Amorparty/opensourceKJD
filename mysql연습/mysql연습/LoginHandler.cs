using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace mysql연습
{
    class LoginHandler
    {
        private String connectingString = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

        private MySqlConnection conn;
        private MySqlCommand comm;
        private MySqlDataReader myReader;

        public bool LoginCheck(string id, string password)
        {
            try
            {
                using (conn = new MySqlConnection(connectingString))
                {
                    conn.Open();
                    using (comm = new MySqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = "SELECT * FROM login WHERE user_id = @id AND user_password = @password";
                        comm.Parameters.AddWithValue("@id", id);
                        comm.Parameters.AddWithValue("@password", password);
                        using (myReader = comm.ExecuteReader())
                        {
                            if (myReader.HasRows)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        public string GetUserName(string id)
        {
            try
            {
                using (conn = new MySqlConnection(connectingString))
                {
                    conn.Open();
                    using (comm = new MySqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = "SELECT user_name AS 'name' FROM login WHERE user_id = @id";
                        comm.Parameters.AddWithValue("@id", id);
                        using (myReader = comm.ExecuteReader())
                        {
                            if (myReader.Read())
                            {
                                return myReader["name"].ToString();
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

    }
}
