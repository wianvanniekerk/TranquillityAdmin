using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1.Data.Communication
{
    internal class DataHandlerEmail
    {
        private string connect = $"Server={EnvConfig.server}; Database={EnvConfig.database}; User ID={EnvConfig.userId}; Password={EnvConfig.password};";

        public DataTable FetchClients()
        {
            string query = "SELECT * FROM Client";
            return ExecuteQuery(query);
        }

        public DataTable FetchStaff()
        {
            string query = "SELECT * FROM Staff";
            return ExecuteQuery(query);
        }

        public string GetStaffName(string email)
        {
            string query = "SELECT FirstName, LastName FROM Staff WHERE Email = @Email";
            DataTable dt = ExecuteQuery(query, new MySqlParameter("@Email", email));
            if (dt.Rows.Count > 0)
            {
                string firstName = dt.Rows[0]["FirstName"].ToString();
                string lastName = dt.Rows[0]["LastName"].ToString();
                return $"{firstName} {lastName}";
            }

            return string.Empty;
        }

        public string GetStaffRole(string email)
        {
            string query = "SELECT Role FROM Staff WHERE Email = @Email";
            DataTable dt = ExecuteQuery(query, new MySqlParameter("@Email", email));
            if (dt.Rows.Count > 0)
            {
                string role = dt.Rows[0]["Role"].ToString();
                return $"{role}";
            }

            return string.Empty;
        }

        public string GetStaffPhoneNumber(string email)
        {
            string query = "SELECT PhoneNumber FROM Staff WHERE Email = @Email";
            DataTable dt = ExecuteQuery(query, new MySqlParameter("@Email", email));
            if (dt.Rows.Count > 0)
            {
                string phoneNumber = dt.Rows[0]["PhoneNumber"].ToString();
                return $"{phoneNumber}";
            }

            return string.Empty;
        }

        private DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            using (MySqlConnection connection = new MySqlConnection(connect))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
