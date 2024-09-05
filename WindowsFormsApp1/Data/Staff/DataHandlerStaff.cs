using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1.Data.Staff
{
    internal class DataHandlerStaff
    {
        private string connect = $"Server={EnvConfig.server}; Database={EnvConfig.database}; User ID={EnvConfig.userId}; Password={EnvConfig.password};";

        public DataTable FetchStaff()
        {
            string query = "SELECT * FROM Staff";
            return ExecuteQuery(query);
        }

        public void UpdateStaff(DataTable changes)
        {
            foreach (DataRow row in changes.Rows)
            {
                if (row.RowState == DataRowState.Added)
                {
                    row["CreatedAt"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }

            using (MySqlConnection connection = new MySqlConnection(connect))
            {
                connection.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM Staff", connection))
                {
                    using (MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter))
                    {
                        adapter.UpdateCommand = builder.GetUpdateCommand();
                        adapter.InsertCommand = builder.GetInsertCommand();
                        adapter.DeleteCommand = builder.GetDeleteCommand();

                        adapter.Update(changes);
                    }
                }
            }
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
