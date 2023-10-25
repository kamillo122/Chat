using System;
using System.Data.SqlClient;

namespace Chat
{
    internal class Auth
    {
        private string _login = "";
        private string _password = "";
        private static readonly string ConnectionString = "Server=localhost;Database=Chat;Trusted_Connection=True;";
        public void SetCredientals(string username, string password)
        {
            _login = username;
            _password = password;
        }
        public bool CredientalsCheck()
        {
            if (_login == "" || _password == "")
            {
                return false;
            }
            try
            {

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {

                    using (SqlCommand command = new SqlCommand("SELECT * FROM [user]", connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader.GetString(1) == _login && reader.GetString(2) == _password)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return false;
        }
    }
}
