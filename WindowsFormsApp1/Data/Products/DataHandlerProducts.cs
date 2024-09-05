using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Data.Products
{
    internal class DataHandlerProducts
    {
        private string connect = $"Server={EnvConfig.server}; Database={EnvConfig.database}; User ID={EnvConfig.userId}; Password={EnvConfig.password};";

        public DataTable FetchProducts()
        {
            string query = "SELECT * FROM Product";
            return ExecuteQuery(query);
        }

        public DataTable FetchCategories()
        {
            string query = @"
                SELECT CategoryID, CategoryName
                FROM Category";
            return ExecuteQuery(query);
        }

        public DataTable FetchSkinClassifications()
        {
            string query = @"
                SELECT SkinClassificationID, SkinClassificationName
                FROM SkinClassification";
            return ExecuteQuery(query);
        }

        public DataTable FetchProductSkinClassifications()
        {
            string query = @"
                SELECT psc.ProductID, sc.SkinClassificationName
                FROM ProductSkinClassification psc
                JOIN SkinClassification sc ON psc.SkinClassificationID = sc.SkinClassificationID";
            return ExecuteQuery(query);
        }

        public void UpdateProducts(DataTable changes)
        {
            foreach (DataRow row in changes.Rows)
            {
                if (row.RowState == DataRowState.Added)
                {
                    row["CreatedAt"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    row["ModifiedAt"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }

            using (MySqlConnection connection = new MySqlConnection(connect))
            {
                connection.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM Product", connection))
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

        public void UpdateProductSkinClassifications(int productId, string[] classifications)
        {
            using (MySqlConnection connection = new MySqlConnection(connect))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM ProductSkinClassification WHERE ProductID = @ProductID";
                using (MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection))
                {
                    deleteCommand.Parameters.AddWithValue("@ProductID", productId);
                    deleteCommand.ExecuteNonQuery();
                }

                string insertQuery = "INSERT INTO ProductSkinClassification (ProductID, SkinClassificationID) VALUES (@ProductID, @SkinClassificationID)";
                foreach (string classification in classifications)
                {
                    int classificationId = GetSkinClassificationIdByName(classification);
                    using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@ProductID", productId);
                        insertCommand.Parameters.AddWithValue("@SkinClassificationID", classificationId);
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        private int GetSkinClassificationIdByName(string classificationName)
        {
            string query = "SELECT SkinClassificationID FROM SkinClassification WHERE SkinClassificationName = @SkinClassificationName";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connect))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SkinClassificationName", classificationName);
                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int classificationId))
                        {
                            return classificationId;
                        }
                        else
                        {
                            throw new Exception("Skin Classification not found or invalid result.");
                        }
                    }
                }
            }
            catch (MySqlException)
            {
                Console.WriteLine("Error: This is not a valid skin classification.");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
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
