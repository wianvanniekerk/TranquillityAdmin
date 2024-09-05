using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1.Data.Clients
{
    internal class DataHandlerClients
    {
        private string connect = $"Server={EnvConfig.server}; Database={EnvConfig.database}; User ID={EnvConfig.userId}; Password={EnvConfig.password};";

        public DataTable FetchClients()
        {
            string query = @"SELECT * FROM Client";
            return ExecuteQuery(query);
        }

        public DataTable SearchClient(string partialFirstName)
        {
            string query = @"SELECT * FROM Client WHERE FirstName LIKE @PartialFirstName";
            return ExecuteQuery(query, new MySqlParameter("@PartialFirstName", $"%{partialFirstName}%"));
        }

        public List<string> GetBirthday()
        {
            string query = "SELECT FirstName, LastName, DateOfBirth FROM Client";
            DataTable dt = ExecuteQuery(query);
            List<string> notifications = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                DateTime birthDate = Convert.ToDateTime(row["DateOfBirth"]);
                string firstName = row["FirstName"].ToString();
                string lastName = row["LastName"].ToString();

                DateTime today = DateTime.Now.Date;
                DateTime nextBirthday = new DateTime(today.Year, birthDate.Month, birthDate.Day);

                if (nextBirthday < today)
                    nextBirthday = nextBirthday.AddYears(1);

                int daysUntilBirthday = (nextBirthday - today).Days;

                if (daysUntilBirthday <= 7 && daysUntilBirthday >= 0)
                {
                    string notification = $"{firstName} {lastName}'s birthday is on {nextBirthday:d}";
                    notifications.Add(notification);
                }
            }

            return notifications;
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

                        foreach (DataRow row in changes.Rows)
                        {
                            if (row.RowState == DataRowState.Added)
                            {
                                row["RegistrationDate"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                row["CreatedAt"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                row["MarketingConsent"] = true;
                                row["IsActive"] = true;
                            }

                            if (row["DateOfBirth"] == DBNull.Value || string.IsNullOrEmpty(row["DateOfBirth"].ToString()))
                            {
                                row["DateOfBirth"] = DateTime.Today.ToString("yyyy-MM-dd");
                            }
                            else
                            {
                                DateTime dateOfBirth = Convert.ToDateTime(row["DateOfBirth"]);
                                row["DateOfBirth"] = dateOfBirth.ToString("yyyy-MM-dd");
                            }

                            row["IsActive"] = Convert.ToInt32(row["IsActive"]);
                            row["MarketingConsent"] = Convert.ToInt32(row["MarketingConsent"]);
                        }

                        adapter.Update(changes);
                    }
                }
            }
        }


        public void DeleteClient(int clientId)
        {
            using (MySqlConnection connection = new MySqlConnection(connect))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        DeleteRelatedRecords(clientId, connection, transaction);

                        string query = "DELETE FROM Client WHERE ClientID = @ClientID";
                        ExecuteNonQuery(query, transaction, connection, new MySqlParameter("@ClientID", clientId));

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private void DeleteRelatedRecords(int clientId, MySqlConnection connection, MySqlTransaction transaction)
        {
            ExecuteNonQuery("DELETE FROM AppointmentClientHistory WHERE ClientID = @ClientID", transaction, connection, new MySqlParameter("@ClientID", clientId));

            ExecuteNonQuery("DELETE FROM Appointment WHERE ClientID = @ClientID", transaction, connection, new MySqlParameter("@ClientID", clientId));

            ExecuteNonQuery("DELETE FROM AppointmentTokens WHERE ClientID = @ClientID", transaction, connection, new MySqlParameter("@ClientID", clientId));

            ExecuteNonQuery("DELETE FROM `Order` WHERE ClientID = @ClientID", transaction, connection, new MySqlParameter("@ClientID", clientId));

            ExecuteNonQuery("DELETE FROM InitialTreatment WHERE ClientID = @ClientID", transaction, connection, new MySqlParameter("@ClientID", clientId));

            ExecuteNonQuery("DELETE FROM FollowUpTreatment WHERE ClientID = @ClientID", transaction, connection, new MySqlParameter("@ClientID", clientId));

            ExecuteNonQuery("DELETE FROM Reward WHERE ClientID = @ClientID", transaction, connection, new MySqlParameter("@ClientID", clientId));
        }

        private void ExecuteNonQuery(string query, MySqlTransaction transaction, MySqlConnection connection, params MySqlParameter[] parameters)
        {
            using (MySqlCommand command = new MySqlCommand(query, connection, transaction))
            {
                command.Parameters.AddRange(parameters);
                command.ExecuteNonQuery();
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
