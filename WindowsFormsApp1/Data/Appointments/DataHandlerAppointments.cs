using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Data.Appointments
{
    internal class DataHandlerAppointments
    {
        private string connect = $"Server={EnvConfig.server}; Database={EnvConfig.database}; User ID={EnvConfig.userId}; Password={EnvConfig.password};";
        public delegate void AppointmentInsertedEventHandler(object sender, AppointmentInsertedEventArgs e);
        public event AppointmentInsertedEventHandler AppointmentInserted;

        public DataTable FetchAppointments()
        {
            string query = "SELECT * FROM Appointment";
            return ExecuteQuery(query);
        }

        public DataTable FetchClients()
        {
            string query = @"
                SELECT ClientID, CONCAT(FirstName, ' ', LastName) as ClientName
                FROM Client";
            return ExecuteQuery(query);
        }

        public DataTable FetchStaff()
        {
            string query = "SELECT StaffID, CONCAT(FirstName, ' ', LastName) as StaffName FROM Staff";
            return ExecuteQuery(query);
        }

        public void UpdateAppointments(DataTable changes)
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

                        adapter.RowUpdated += new MySqlRowUpdatedEventHandler(OnRowUpdated);

                        adapter.Update(changes);
                    }
                }
            }
        }

        private void OnRowUpdated(object sender, MySqlRowUpdatedEventArgs e)
        {
            if (e.StatementType == StatementType.Insert)
            {
                int newAppointmentID = Convert.ToInt32(e.Command.LastInsertedId);

                AppointmentInserted?.Invoke(this, new AppointmentInsertedEventArgs(e.Row, newAppointmentID));
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
            ExecuteNonQueryInitial(query);
        }

        public void DeleteAppointment(int appointmentId)
        {
            using (MySqlConnection connection = new MySqlConnection(connect))
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        DeleteRelatedRecords(appointmentId, connection, transaction);

                        string query = "DELETE FROM Appointment WHERE AppointmentID = @AppointmentID";
                        ExecuteNonQueryDelete(query, transaction, connection, new MySqlParameter("@AppointmentID", appointmentId));

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

        private void DeleteRelatedRecords(int appointmentId, MySqlConnection connection, MySqlTransaction transaction)
        {
            ExecuteNonQueryDelete("DELETE FROM AppointmentClientHistory WHERE AppointmentID = @AppointmentID", transaction, connection, new MySqlParameter("@AppointmentID", appointmentId));
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

        private void ExecuteNonQueryInitial(string query, params MySqlParameter[] parameters)
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


        private void ExecuteNonQueryDelete(string query, MySqlTransaction transaction, MySqlConnection connection, params MySqlParameter[] parameters)
        {
            using (MySqlCommand command = new MySqlCommand(query, connection, transaction))
            {
                command.Parameters.AddRange(parameters);
                command.ExecuteNonQuery();
            }
        }

    }
    public class AppointmentInsertedEventArgs : EventArgs
    {
        public DataRow Row { get; }
        public int AppointmentID { get; }

        public AppointmentInsertedEventArgs(DataRow row, int appointmentID)
        {
            Row = row;
            AppointmentID = appointmentID;
        }
    }
}
