using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1.Data.Clients
{
    internal class DataHandlerClientsPrimary
    {
        private string connect = $"Server={EnvConfig.server}; Database={EnvConfig.database}; User ID={EnvConfig.userId}; Password={EnvConfig.password};";

        private Cloudinary cloudinary;
        public List<string> imageUrls = new List<string>();
        public int currentImageIndex = -1;

        public DataHandlerClientsPrimary()
        {
            Account account = new Account(
                EnvConfig.cloudinaryCloud,
                EnvConfig.cloudinaryKey,
                EnvConfig.cloudinarySecret);
            cloudinary = new Cloudinary(account);
        }

        private string SanitizePublicId(string input)
        {
            string sanitized = Regex.Replace(input, @"[^a-zA-Z0-9_-]", "_");

            if (sanitized.Length > 255)
            {
                sanitized = sanitized.Substring(0, 255);
            }

            return sanitized;
        }

        public void LoadImagesForClient(int clientId)
        {
            imageUrls.Clear();
            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string query = "SELECT ImageUrl FROM ClientImages WHERE ClientId = @ClientId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientId", clientId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            imageUrls.Add(reader.GetString("ImageUrl"));
                        }
                    }
                }
            }
            currentImageIndex = imageUrls.Count > 0 ? 0 : -1;
        }
        public async Task<string> UploadImageToCloudinary(string filePath, int clientId)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"The file at path {filePath} does not exist.");
                }

                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string sanitizedPublicId = SanitizePublicId($"client_{clientId}_{fileName}");

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(filePath),
                    Folder = "Tranquillity/ClientImages",
                    PublicId = sanitizedPublicId,
                };

                var uploadResult = await cloudinary.UploadAsync(uploadParams);

                if (uploadResult.Error != null)
                {
                    throw new Exception($"Cloudinary upload error: {uploadResult.Error.Message}");
                }

                if (string.IsNullOrEmpty(uploadResult.SecureUrl?.ToString()))
                {
                    throw new Exception("Cloudinary upload successful, but SecureUrl is null or empty.");
                }

                return uploadResult.SecureUrl.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading image to Cloudinary: {ex.Message}");
                throw;
            }
        }

        public void SaveImageUrlToDatabase(string imageUrl, int clientId)
        {
            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string query = "INSERT INTO ClientImages (ClientId, ImageUrl) VALUES (@ClientId, @ImageUrl)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientId", clientId);
                    command.Parameters.AddWithValue("@ImageUrl", imageUrl);
                    command.ExecuteNonQuery();
                }
            }
        }

        public async Task DeleteImageFromCloudinary(string imageUrl)
        {
            var publicId = GetPublicIdFromUrl(imageUrl);
            var deleteParams = new DeletionParams(publicId);
            await cloudinary.DestroyAsync(deleteParams);
        }

        public void DeleteImageFromDatabase(string imageUrl, int clientId)
        {
            using (var connection = new MySqlConnection(connect))
            {
                connection.Open();
                string query = "DELETE FROM ClientImages WHERE ClientId = @ClientId AND ImageUrl = @ImageUrl";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientId", clientId);
                    command.Parameters.AddWithValue("@ImageUrl", imageUrl);
                    command.ExecuteNonQuery();
                }
            }
        }

        public async Task<Image> DownloadImageFromCloudinary(string imageUrl)
        {
            using (var webClient = new System.Net.WebClient())
            {
                var imageBytes = await webClient.DownloadDataTaskAsync(imageUrl);
                using (var ms = new MemoryStream(imageBytes))
                {
                    return Image.FromStream(ms);
                }
            }
        }

        private string GetPublicIdFromUrl(string url)
        {
            var uri = new Uri(url);
            var pathSegments = uri.AbsolutePath.Split('/');
            return string.Join("/", pathSegments.Skip(pathSegments.Length - 2));
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
