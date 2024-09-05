using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1.Data.Orders
{
    internal class DataHandlerOrders
    {
        private string connect = $"Server={EnvConfig.server}; Database={EnvConfig.database}; User ID={EnvConfig.userId}; Password={EnvConfig.password};";

        public DataTable FetchOrders()
        {
            string query = "SELECT * FROM `Order`";
            return ExecuteQuery(query);
        }

        public DataTable FetchClients()
        {
            string query = @"
                SELECT ClientID, CONCAT(FirstName, ' ', LastName) as ClientName
                FROM Client";
            return ExecuteQuery(query);
        }

        public DataTable FetchProduct()
        {
            string query = "SELECT ProductID, ProductName FROM Product";
            return ExecuteQuery(query);
        }

        public void DeleteOrder(int orderId)
        {
            string query = "DELETE FROM `Order` WHERE OrderID = @OrderID";
            ExecuteNonQuery(query, new MySqlParameter("@OrderID", orderId));
        }

        public void UpdateOrders(DataTable changes)
        {
            foreach (DataRow row in changes.Rows)
            {
                if (row.RowState == DataRowState.Added)
                {
                    row["CreatedAt"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }

                if (row["ProductID"] != DBNull.Value)
                {
                    int productId = Convert.ToInt32(row["ProductID"]);
                    decimal price = GetProductPrice(productId);
                    row["TotalAmount"] = price;
                }
            }

            using (MySqlConnection connection = new MySqlConnection(connect))
            {
                connection.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `Order`", connection))
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

        private decimal GetProductPrice(int productId)
        {
            string query = "SELECT Price FROM Product WHERE ProductID = @ProductID";
            using (MySqlConnection connection = new MySqlConnection(connect))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", productId);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToDecimal(result) : 0m;
                }
            }
        }

        private void ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            using (MySqlConnection connection = new MySqlConnection(connect))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    connection.Open();
                    command.ExecuteNonQuery();
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
