using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace WindowsFormsApp1.Data.Clients
{
    internal class DataHandlerClientsPrimary
    {
        private string connect = $"Server={EnvConfig.server}; Database={EnvConfig.database}; User ID={EnvConfig.userId}; Password={EnvConfig.password};";

        public List<string> imagePaths = new List<string>();
        public int currentImageIndex = -1;

        public void LoadImagesForClient(int clientId)
        {
            imagePaths.Clear();
            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string query = "SELECT ImagePath FROM ClientImages WHERE ClientId = @ClientId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientId", clientId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            imagePaths.Add(reader.GetString("ImagePath"));
                        }
                    }
                }
            }
            currentImageIndex = imagePaths.Count > 0 ? 0 : -1;
        }

        public void SaveImagePathToDatabase(string imagePath, int clientId)
        {
            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string query = "INSERT INTO ClientImages (ClientId, ImagePath) VALUES (@ClientId, @ImagePath)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientId", clientId);
                    command.Parameters.AddWithValue("@ImagePath", imagePath);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteImageFromDatabase(string imagePath, int clientId)
        {
            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string query = "DELETE FROM ClientImages WHERE ClientId = @ClientId AND ImagePath = @ImagePath";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientId", clientId);
                    command.Parameters.AddWithValue("@ImagePath", imagePath);
                    command.ExecuteNonQuery();
                }
            }
        }

        public string GetClientName(int clientId)
        {
            string query = "SELECT FirstName, LastName FROM Client WHERE ClientID = @ClientID";
            DataTable dt = ExecuteQuery(query, new MySqlParameter("@ClientID", clientId));
            if (dt.Rows.Count > 0)
            {
                string firstName = dt.Rows[0]["FirstName"].ToString();
                string lastName = dt.Rows[0]["LastName"].ToString();
                return $"{firstName} {lastName}";
            }

            return string.Empty;
        }

        public List<string> GetEstimatedFinishDates()
        {
            string query = "SELECT p.ProductName, c.FirstName, c.LastName, pu.EstimatedFinishDate FROM " +
                           "ProductUsage pu JOIN Product p ON p.ProductID = pu.ProductID " +
                           "JOIN Client c ON pu.ClientID = c.ClientID";
            DataTable dt = ExecuteQuery(query);

            List<string> notifications = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                string productName = row["ProductName"].ToString();
                string firstName = row["FirstName"].ToString();
                string lastName = row["LastName"].ToString();
                DateTime estimatedFinishDate = Convert.ToDateTime(row["EstimatedFinishDate"]);

                if ((estimatedFinishDate.Date > DateTime.Now.Date) && (estimatedFinishDate.Date <= DateTime.Now.AddDays(7)))
                {
                    string notification = $"{firstName} {lastName} estimated to finish {productName} on {estimatedFinishDate.ToShortDateString()}";
                    notifications.Add(notification);
                }
            }

            return notifications;
        }


        public int GetAppointmentID(int clientId)
        {
            string query = "SELECT AppointmentID FROM Appointment WHERE ClientID = @ClientID ORDER BY AppointmentDate DESC LIMIT 1;";
            DataTable dt = ExecuteQuery(query, new MySqlParameter("@ClientID", clientId));
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["AppointmentID"]);
            }

            return -1;
        }


        public DataTable FetchClients()
        {
            string query = @"SELECT * FROM Client";
            return ExecuteQuery(query);
        }

        public DataTable FetchStaff()
        {
            string query = "SELECT StaffID, CONCAT(FirstName, ' ', LastName) as StaffName FROM Staff";
            return ExecuteQuery(query);
        }

        public DataTable FetchProduct()
        {
            string query = "SELECT ProductID, ProductName FROM Product";
            return ExecuteQuery(query);
        }

        public DataTable FetchProductUsage()
        {
            string query = "SELECT ProductID, ProductName FROM Product";
            return ExecuteQuery(query);
        }

        public void UpdateClient(DataTable changes)
        {
            using (MySqlConnection connection = new MySqlConnection(connect))
            {
                connection.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM Client", connection))
                {
                    using (MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter))
                    {
                        adapter.UpdateCommand = builder.GetUpdateCommand();
                        adapter.InsertCommand = builder.GetInsertCommand();
                        adapter.DeleteCommand = builder.GetDeleteCommand();

                        adapter.AcceptChangesDuringUpdate = false;

                        foreach (DataRow row in changes.Rows)
                        {
                            if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                            {
                                row["RegistrationDate"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                        }

                        adapter.Update(changes);
                        changes.AcceptChanges();
                    }
                }
            }
        }

        public void UpdateAppointments(DataTable changes, int clientID)
        {
            using (MySqlConnection connection = new MySqlConnection(connect))
            {
                connection.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM Appointment", connection))
                {
                    using (MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter))
                    {
                        adapter.UpdateCommand = builder.GetUpdateCommand();
                        adapter.InsertCommand = builder.GetInsertCommand();
                        adapter.DeleteCommand = builder.GetDeleteCommand();

                        adapter.AcceptChangesDuringUpdate = false;

                        foreach (DataRow row in changes.Rows)
                        {
                            if (row.RowState != DataRowState.Deleted)
                            {
                                row["ClientID"] = clientID;
                                row["CreatedAt"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                        }

                        changes.Columns["AppointmentID"].ReadOnly = true;

                        adapter.Update(changes);
                        changes.AcceptChanges();
                    }
                }
            }
        }

        public void UpdateOrders(DataTable changes, int clientID)
        {
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
                        adapter.AcceptChangesDuringUpdate = false;

                        foreach (DataRow row in changes.Rows)
                        {
                            if (row.RowState != DataRowState.Deleted)
                            {
                                row["ClientID"] = clientID;
                                row["CreatedAt"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                                if (row["ProductID"] != DBNull.Value)
                                {
                                    int productId = Convert.ToInt32(row["ProductID"]);
                                    decimal price = GetProductPrice(connection, productId);
                                    row["TotalAmount"] = price;
                                }
                            }
                        }

                        changes.Columns["OrderID"].ReadOnly = true;
                        adapter.Update(changes);
                        changes.AcceptChanges();
                    }
                }
            }
        }

        public void UpdateProductUsage(DataTable changes, int clientID)
        {
            using (MySqlConnection connection = new MySqlConnection(connect))
            {
                connection.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM ProductUsage", connection))
                {
                    using (MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter))
                    {
                        adapter.UpdateCommand = builder.GetUpdateCommand();
                        adapter.InsertCommand = builder.GetInsertCommand();
                        adapter.DeleteCommand = builder.GetDeleteCommand();

                        foreach (DataRow row in changes.Rows)
                        {
                            row["ClientID"] = clientID;
                            row["CreatedAt"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        }

                        changes.Columns["ProductUsageID"].ReadOnly = true;

                        adapter.Update(changes);
                    }
                }
            }
        }

        public void UpdateAppointmentStatuses()
        {
            string query = @"
                UPDATE Appointment 
                SET Status = 
                    CASE 
                        WHEN AppointmentDate < NOW() THEN 'Completed'
                        WHEN AppointmentDate >= NOW() THEN 'Scheduled'
                    END
                WHERE Status IN ('Scheduled', 'Completed')";
            ExecuteNonQuery(query);
        }

        private decimal GetProductPrice(MySqlConnection connection, int productId)
        {
            string query = "SELECT Price FROM Product WHERE ProductID = @ProductID";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProductID", productId);
                object result = command.ExecuteScalar();
                return result != null ? Convert.ToDecimal(result) : 0m;
            }
        }

        public DataTable GetClientDetails(int clientId)
        {
            string query = "SELECT * FROM Client WHERE ClientID = @ClientID";
            return ExecuteQuery(query, new MySqlParameter("@ClientID", clientId));
        }

        public DataTable GetClientAppointments(int clientId)
        {
            string query = "SELECT * FROM Appointment WHERE ClientID = @ClientID";
            return ExecuteQuery(query, new MySqlParameter("@ClientID", clientId));
        }

        public DataTable GetClientOrders(int clientId)
        {
            string query = "SELECT * FROM `Order` WHERE ClientID = @ClientID";
            return ExecuteQuery(query, new MySqlParameter("@ClientID", clientId));
        }

        public DataTable GetProductUsage(int clientId)
        {
            string query = "SELECT * FROM ProductUsage WHERE ClientID = @ClientID";
            return ExecuteQuery(query, new MySqlParameter("@ClientID", clientId));
        }

        public void DeleteAppointment(int appointmentId)
        {
            string query = "DELETE FROM Appointment WHERE AppointmentID = @AppointmentID";
            ExecuteNonQuery(query, new MySqlParameter("@AppointmentID", appointmentId));
        }

        public void DeleteOrder(int orderId)
        {
            string query = "DELETE FROM `Order` WHERE OrderID = @OrderID";
            ExecuteNonQuery(query, new MySqlParameter("@OrderID", orderId));
        }

        public void DeleteProductUsage(int productUsageId)
        {
            string query = "DELETE FROM ProductUsage WHERE ProductUsageID = @ProductUsageID";
            ExecuteNonQuery(query, new MySqlParameter("@ProductUsageID", productUsageId));
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
