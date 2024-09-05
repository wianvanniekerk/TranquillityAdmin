using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Data.Appointments
{
    public class InitialTreatmentData
    {
        public DateTime DateSmartMicroPeel { get; set; }
        public DateTime DateActiveRejuvenation { get; set; }
        public DateTime DateThermalDetox { get; set; }
        public DateTime DateTherapeuticTreatment { get; set; }
        public DateTime DateDeepCleanse { get; set; }

        public string SuperFluidsSmartMicroPeel { get; set; }
        public string SuperFluidsActiveRejuvenation { get; set; }
        public string SuperFluidsThermalDetox { get; set; }
        public string SuperFluidsTherapeuticTreatment { get; set; }
        public string SuperFluidsDeepCleanse { get; set; }

        public string NimueTDSSmartMicroPeel { get; set; }
        public string NimueTDSActiveRejuvenation { get; set; }
        public string NimueTDSThermalDetox { get; set; }
        public string NimueTDSTherapeuticTreatment { get; set; }
        public string NimueTDSDeepCleanse { get; set; }

        public string MaskSmartMicroPeel { get; set; }
        public string MaskActiveRejuvenation { get; set; }
        public string MaskThermalDetox { get; set; }
        public string MaskTherapeuticTreatment { get; set; }
        public string MaskDeepCleanse { get; set; }
    }

    public class FollowUpTreatmentData
    {
        public DateTime DateActiveRejuvanation { get; set; }
        public DateTime DateGlycolic { get; set; }
        public DateTime DateTCA { get; set; }
        public DateTime DateNimueSRC_ED { get; set; }
        public DateTime DateNimueSRC_HP { get; set; }
        public DateTime DateNimueSRC_P { get; set; }
        public DateTime DateSmartResurfacer { get; set; }
        public DateTime DateMicroNeedling { get; set; }

        public int LayersMinActiveRejuvanation { get; set; }
        public int LayersMinGlycolic { get; set; }
        public int LayersMinTCA { get; set; }
        public int LayersMinNimueSRC_ED { get; set; }
        public int LayersMinNimueSRC_HP { get; set; }
        public int LayersMinNimueSRC_P { get; set; }
        public int LayersMinSmartResurfacer { get; set; }
        public int LayersMinMicroNeedling { get; set; }

        public string SuperFluidsActiveRejuvanation { get; set; }
        public string SuperFluidsGlycolic { get; set; }
        public string SuperFluidsTCA { get; set; }
        public string SuperFluidsNimueSRC_ED { get; set; }
        public string SuperFluidsNimueSRC_HP { get; set; }
        public string SuperFluidsNimueSRC_P { get; set; }
        public string SuperFluidsSmartResurfacer { get; set; }
        public string SuperFluidsMicroNeedling { get; set; }

        public string NimueTDSActiveRejuvanation { get; set; }
        public string NimueTDSGlycolic { get; set; }
        public string NimueTDSTCA { get; set; }
        public string NimueTDSNimueSRC_ED { get; set; }
        public string NimueTDSNimueSRC_HP { get; set; }
        public string NimueTDSNimueSRC_P { get; set; }
        public string NimueTDSSmartResurfacer { get; set; }
        public string NimueTDSMicroNeedling { get; set; }

        public string MaskActiveRejuvanation { get; set; }
        public string MaskGlycolic { get; set; }
        public string MaskTCA { get; set; }
        public string MaskNimueSRC_ED { get; set; }
        public string MaskNimueSRC_HP { get; set; }
        public string MaskNimueSRC_P { get; set; }
        public string MaskSmartResurfacer { get; set; }
        public string MaskMicroNeedling { get; set; }
    }


    internal class DataHandlerAppointmentClientHistory
    {        
        private string connect = $"Server={EnvConfig.server}; Database={EnvConfig.database}; User ID={EnvConfig.userId}; Password={EnvConfig.password};";

        public int GetClientID(int appointmentId)
        {
            string query = "SELECT ClientID FROM Appointment WHERE AppointmentID = @AppointmentID;";
            DataTable dt = ExecuteQuery(query, new MySqlParameter("@AppointmentID", appointmentId));

            if (dt.Rows.Count > 0)
            {
                int clientID = Convert.ToInt32(dt.Rows[0]["ClientID"]);
                return clientID;
            }

            return -1;
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

        public List<string> GetAppointmentClientHistorySubmission()
        {
            string query = "SELECT c.FirstName, c.LastName, a.AppointmentDate, ach.CreatedAt FROM " +
                           "AppointmentClientHistory ach " +
                           "JOIN Client c ON ach.ClientID = c.ClientID " +
                           "JOIN Appointment a ON ach.AppointmentID = a.AppointmentID " +
                           "ORDER BY ach.CreatedAt DESC";
            DataTable dt = ExecuteQuery(query);

            List<string> notifications = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                string firstName = row["FirstName"].ToString();
                string lastName = row["LastName"].ToString();
                DateTime appointmentDate = Convert.ToDateTime(row["AppointmentDate"].ToString());
                DateTime createdAt = Convert.ToDateTime(row["CreatedAt"].ToString());

                if ((DateTime.Now.Date >= createdAt.Date) && (createdAt.Date >= DateTime.Now.AddDays(-7)))
                {
                    string notification = $"{firstName} {lastName} recently submitted medical history form for the appointment on {appointmentDate}";
                    notifications.Add(notification);
                }                
            }

            return notifications;
        }

        public InitialTreatmentData FetchInitalTreatment(int appointmentId)
        {
            using (MySqlConnection connection = new MySqlConnection(connect))
            {
                connection.Open();
                string query = @"SELECT DateSmartMicroPeel, DateActiveRejuvenation, DateThermalDetox, DateTherapeuticTreatment, DateDeepCleanse,
                            SuperFluidsSmartMicroPeel, SuperFluidsActiveRejuvenation, SuperFluidsThermalDetox, SuperFluidsTherapeuticTreatment, SuperFluidsDeepCleanse,
                            NimueTDSSmartMicroPeel, NimueTDSActiveRejuvenation, NimueTDSThermalDetox, NimueTDSTherapeuticTreatment, NimueTDSDeepCleanse,
                            MaskSmartMicroPeel, MaskActiveRejuvenation, MaskThermalDetox, MaskTherapeuticTreatment, MaskDeepCleanse
                     FROM InitialTreatment
                     WHERE AppointmentID = @AppointmentID
                     ORDER BY TreatmentID DESC";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AppointmentID", appointmentId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new InitialTreatmentData
                            {
                                DateSmartMicroPeel = reader.GetDateTime("DateSmartMicroPeel"),
                                DateActiveRejuvenation = reader.GetDateTime("DateActiveRejuvenation"),
                                DateThermalDetox = reader.GetDateTime("DateThermalDetox"),
                                DateTherapeuticTreatment = reader.GetDateTime("DateTherapeuticTreatment"),
                                DateDeepCleanse = reader.GetDateTime("DateDeepCleanse"),

                                SuperFluidsSmartMicroPeel = reader.GetString("SuperFluidsSmartMicroPeel"),
                                SuperFluidsActiveRejuvenation = reader.GetString("SuperFluidsActiveRejuvenation"),
                                SuperFluidsThermalDetox = reader.GetString("SuperFluidsThermalDetox"),
                                SuperFluidsTherapeuticTreatment = reader.GetString("SuperFluidsTherapeuticTreatment"),
                                SuperFluidsDeepCleanse = reader.GetString("SuperFluidsDeepCleanse"),

                                NimueTDSSmartMicroPeel = reader.GetString("NimueTDSSmartMicroPeel"),
                                NimueTDSActiveRejuvenation = reader.GetString("NimueTDSActiveRejuvenation"),
                                NimueTDSThermalDetox = reader.GetString("NimueTDSThermalDetox"),
                                NimueTDSTherapeuticTreatment = reader.GetString("NimueTDSTherapeuticTreatment"),
                                NimueTDSDeepCleanse = reader.GetString("NimueTDSDeepCleanse"),

                                MaskSmartMicroPeel = reader.GetString("MaskSmartMicroPeel"),
                                MaskActiveRejuvenation = reader.GetString("MaskActiveRejuvenation"),
                                MaskThermalDetox = reader.GetString("MaskThermalDetox"),
                                MaskTherapeuticTreatment = reader.GetString("MaskTherapeuticTreatment"),
                                MaskDeepCleanse = reader.GetString("MaskDeepCleanse"),
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public FollowUpTreatmentData FetchFollowUpTreatment(int appointmentId)
        {
            using (MySqlConnection connection = new MySqlConnection(connect))
            {
                connection.Open();
                string query = @"SELECT DateActiveRejuvanation, DateGlycolic, DateTCA, DateNimueSRC_ED, DateNimueSRC_HP, DateNimueSRC_P, DateSmartResurfacer, DateMicroNeedling,
                                LayersMinActiveRejuvanation, LayersMinGlycolic, LayersMinTCA, LayersMinNimueSRC_ED, LayersMinNimueSRC_HP, LayersMinNimueSRC_P, LayersMinSmartResurfacer, LayersMinMicroNeedling,
                                SuperFluidsActiveRejuvanation, SuperFluidsGlycolic, SuperFluidsTCA, SuperFluidsNimueSRC_ED, SuperFluidsNimueSRC_HP, SuperFluidsNimueSRC_P, SuperFluidsSmartResurfacer, SuperFluidsMicroNeedling,
                                NimueTDSActiveRejuvanation, NimueTDSGlycolic, NimueTDSTCA, NimueTDSNimueSRC_ED, NimueTDSNimueSRC_HP, NimueTDSNimueSRC_P, NimueTDSSmartResurfacer, NimueTDSMicroNeedling,
                                MaskActiveRejuvanation, MaskGlycolic, MaskTCA, MaskNimueSRC_ED, MaskNimueSRC_HP, MaskNimueSRC_P, MaskSmartResurfacer, MaskMicroNeedling
                         FROM FollowUpTreatment
                         WHERE AppointmentID = @AppointmentID";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AppointmentID", appointmentId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new FollowUpTreatmentData
                            {
                                DateActiveRejuvanation = reader.GetDateTime("DateActiveRejuvanation"),
                                DateGlycolic = reader.GetDateTime("DateGlycolic"),
                                DateTCA = reader.GetDateTime("DateTCA"),
                                DateNimueSRC_ED = reader.GetDateTime("DateNimueSRC_ED"),
                                DateNimueSRC_HP = reader.GetDateTime("DateNimueSRC_HP"),
                                DateNimueSRC_P = reader.GetDateTime("DateNimueSRC_P"),
                                DateSmartResurfacer = reader.GetDateTime("DateSmartResurfacer"),
                                DateMicroNeedling = reader.GetDateTime("DateMicroNeedling"),

                                LayersMinActiveRejuvanation = reader.GetInt32("LayersMinActiveRejuvanation"),
                                LayersMinGlycolic = reader.GetInt32("LayersMinGlycolic"),
                                LayersMinTCA = reader.GetInt32("LayersMinTCA"),
                                LayersMinNimueSRC_ED = reader.GetInt32("LayersMinNimueSRC_ED"),
                                LayersMinNimueSRC_HP = reader.GetInt32("LayersMinNimueSRC_HP"),
                                LayersMinNimueSRC_P = reader.GetInt32("LayersMinNimueSRC_P"),
                                LayersMinSmartResurfacer = reader.GetInt32("LayersMinSmartResurfacer"),
                                LayersMinMicroNeedling = reader.GetInt32("LayersMinMicroNeedling"),

                                SuperFluidsActiveRejuvanation = reader.GetString("SuperFluidsActiveRejuvanation"),
                                SuperFluidsGlycolic = reader.GetString("SuperFluidsGlycolic"),
                                SuperFluidsTCA = reader.GetString("SuperFluidsTCA"),
                                SuperFluidsNimueSRC_ED = reader.GetString("SuperFluidsNimueSRC_ED"),
                                SuperFluidsNimueSRC_HP = reader.GetString("SuperFluidsNimueSRC_HP"),
                                SuperFluidsNimueSRC_P = reader.GetString("SuperFluidsNimueSRC_P"),
                                SuperFluidsSmartResurfacer = reader.GetString("SuperFluidsSmartResurfacer"),
                                SuperFluidsMicroNeedling = reader.GetString("SuperFluidsMicroNeedling"),

                                NimueTDSActiveRejuvanation = reader.GetString("NimueTDSActiveRejuvanation"),
                                NimueTDSGlycolic = reader.GetString("NimueTDSGlycolic"),
                                NimueTDSTCA = reader.GetString("NimueTDSTCA"),
                                NimueTDSNimueSRC_ED = reader.GetString("NimueTDSNimueSRC_ED"),
                                NimueTDSNimueSRC_HP = reader.GetString("NimueTDSNimueSRC_HP"),
                                NimueTDSNimueSRC_P = reader.GetString("NimueTDSNimueSRC_P"),
                                NimueTDSSmartResurfacer = reader.GetString("NimueTDSSmartResurfacer"),
                                NimueTDSMicroNeedling = reader.GetString("NimueTDSMicroNeedling"),

                                MaskActiveRejuvanation = reader.GetString("MaskActiveRejuvanation"),
                                MaskGlycolic = reader.GetString("MaskGlycolic"),
                                MaskTCA = reader.GetString("MaskTCA"),
                                MaskNimueSRC_ED = reader.GetString("MaskNimueSRC_ED"),
                                MaskNimueSRC_HP = reader.GetString("MaskNimueSRC_HP"),
                                MaskNimueSRC_P = reader.GetString("MaskNimueSRC_P"),
                                MaskSmartResurfacer = reader.GetString("MaskSmartResurfacer"),
                                MaskMicroNeedling = reader.GetString("MaskMicroNeedling"),
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }


        public void UpdateAppointmentClientHistory(DataTable changes, int appointmentID)
        {
            using (MySqlConnection connection = new MySqlConnection(connect))
            {
                connection.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM AppointmentClientHistory", connection))
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
                                row["AppointmentID"] = appointmentID;
                                row["CreatedAt"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                        }

                        changes.Columns["AppointmentClientHistoryID"].ReadOnly = true;

                        adapter.Update(changes);
                        changes.AcceptChanges();
                    }
                }
            }
        }

        public void UpdateInitialTreatment(int clientId, int appointmentId, InitialTreatmentData data)
        {
            using (MySqlConnection connection = new MySqlConnection(connect))
            {
                connection.Open();

                DataTable initialTreatmentTable = new DataTable();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM InitialTreatment WHERE ClientID = @ClientID AND AppointmentID = @AppointmentID", connection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@ClientID", clientId);
                    adapter.SelectCommand.Parameters.AddWithValue("@AppointmentID", appointmentId);

                    adapter.Fill(initialTreatmentTable);

                    DataRow row;
                    if (initialTreatmentTable.Rows.Count > 0)
                    {
                        row = initialTreatmentTable.Rows[0];
                    }
                    else
                    {
                        row = initialTreatmentTable.NewRow();
                        initialTreatmentTable.Rows.Add(row);
                    }

                    row["ClientID"] = clientId;
                    row["AppointmentID"] = appointmentId;

                    row["DateSmartMicroPeel"] = data.DateSmartMicroPeel.ToString("yyyy-MM-dd HH:mm:ss");
                    row["DateActiveRejuvenation"] = data.DateActiveRejuvenation.ToString("yyyy-MM-dd HH:mm:ss");
                    row["DateThermalDetox"] = data.DateThermalDetox.ToString("yyyy-MM-dd HH:mm:ss");
                    row["DateTherapeuticTreatment"] = data.DateTherapeuticTreatment.ToString("yyyy-MM-dd HH:mm:ss");
                    row["DateDeepCleanse"] = data.DateDeepCleanse.ToString("yyyy-MM-dd HH:mm:ss");

                    row["SuperFluidsSmartMicroPeel"] = data.SuperFluidsSmartMicroPeel;
                    row["SuperFluidsActiveRejuvenation"] = data.SuperFluidsActiveRejuvenation;
                    row["SuperFluidsThermalDetox"] = data.SuperFluidsThermalDetox;
                    row["SuperFluidsTherapeuticTreatment"] = data.SuperFluidsTherapeuticTreatment;
                    row["SuperFluidsDeepCleanse"] = data.SuperFluidsDeepCleanse;

                    row["NimueTDSSmartMicroPeel"] = data.NimueTDSSmartMicroPeel;
                    row["NimueTDSActiveRejuvenation"] = data.NimueTDSActiveRejuvenation;
                    row["NimueTDSThermalDetox"] = data.NimueTDSThermalDetox;
                    row["NimueTDSTherapeuticTreatment"] = data.NimueTDSTherapeuticTreatment;
                    row["NimueTDSDeepCleanse"] = data.NimueTDSDeepCleanse;

                    row["MaskSmartMicroPeel"] = data.MaskSmartMicroPeel;
                    row["MaskActiveRejuvenation"] = data.MaskActiveRejuvenation;
                    row["MaskThermalDetox"] = data.MaskThermalDetox;
                    row["MaskTherapeuticTreatment"] = data.MaskTherapeuticTreatment;
                    row["MaskDeepCleanse"] = data.MaskDeepCleanse;

                    using (MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter))
                    {
                        adapter.UpdateCommand = builder.GetUpdateCommand();
                        adapter.InsertCommand = builder.GetInsertCommand();
                        adapter.DeleteCommand = builder.GetDeleteCommand();

                        adapter.Update(initialTreatmentTable);
                    }
                }
            }
        }

        public void UpdateFollowUpTreatment(int clientId, int appointmentId, FollowUpTreatmentData data)
        {
            using (MySqlConnection connection = new MySqlConnection(connect))
            {
                connection.Open();

                DataTable followUpTreatmentTable = new DataTable();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM FollowUpTreatment WHERE ClientID = @ClientID AND AppointmentID = @AppointmentID", connection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@ClientID", clientId);
                    adapter.SelectCommand.Parameters.AddWithValue("@AppointmentID", appointmentId);

                    adapter.Fill(followUpTreatmentTable);

                    DataRow row;
                    if (followUpTreatmentTable.Rows.Count > 0)
                    {
                        row = followUpTreatmentTable.Rows[0];
                    }
                    else
                    {
                        row = followUpTreatmentTable.NewRow();
                        followUpTreatmentTable.Rows.Add(row);
                    }

                    row["ClientID"] = clientId;
                    row["AppointmentID"] = appointmentId;

                    row["DateActiveRejuvanation"] = data.DateActiveRejuvanation.ToString("yyyy-MM-dd");
                    row["DateGlycolic"] = data.DateGlycolic.ToString("yyyy-MM-dd");
                    row["DateTCA"] = data.DateTCA.ToString("yyyy-MM-dd");
                    row["DateNimueSRC_ED"] = data.DateNimueSRC_ED.ToString("yyyy-MM-dd");
                    row["DateNimueSRC_HP"] = data.DateNimueSRC_HP.ToString("yyyy-MM-dd");
                    row["DateNimueSRC_P"] = data.DateNimueSRC_P.ToString("yyyy-MM-dd");
                    row["DateSmartResurfacer"] = data.DateSmartResurfacer.ToString("yyyy-MM-dd");
                    row["DateMicroNeedling"] = data.DateMicroNeedling.ToString("yyyy-MM-dd");

                    row["LayersMinActiveRejuvanation"] = data.LayersMinActiveRejuvanation;
                    row["LayersMinGlycolic"] = data.LayersMinGlycolic;
                    row["LayersMinTCA"] = data.LayersMinTCA;
                    row["LayersMinNimueSRC_ED"] = data.LayersMinNimueSRC_ED;
                    row["LayersMinNimueSRC_HP"] = data.LayersMinNimueSRC_HP;
                    row["LayersMinNimueSRC_P"] = data.LayersMinNimueSRC_P;
                    row["LayersMinSmartResurfacer"] = data.LayersMinSmartResurfacer;
                    row["LayersMinMicroNeedling"] = data.LayersMinMicroNeedling;

                    row["SuperFluidsActiveRejuvanation"] = data.SuperFluidsActiveRejuvanation;
                    row["SuperFluidsGlycolic"] = data.SuperFluidsGlycolic;
                    row["SuperFluidsTCA"] = data.SuperFluidsTCA;
                    row["SuperFluidsNimueSRC_ED"] = data.SuperFluidsNimueSRC_ED;
                    row["SuperFluidsNimueSRC_HP"] = data.SuperFluidsNimueSRC_HP;
                    row["SuperFluidsNimueSRC_P"] = data.SuperFluidsNimueSRC_P;
                    row["SuperFluidsSmartResurfacer"] = data.SuperFluidsSmartResurfacer;
                    row["SuperFluidsMicroNeedling"] = data.SuperFluidsMicroNeedling;

                    row["NimueTDSActiveRejuvanation"] = data.NimueTDSActiveRejuvanation;
                    row["NimueTDSGlycolic"] = data.NimueTDSGlycolic;
                    row["NimueTDSTCA"] = data.NimueTDSTCA;
                    row["NimueTDSNimueSRC_ED"] = data.NimueTDSNimueSRC_ED;
                    row["NimueTDSNimueSRC_HP"] = data.NimueTDSNimueSRC_HP;
                    row["NimueTDSNimueSRC_P"] = data.NimueTDSNimueSRC_P;
                    row["NimueTDSSmartResurfacer"] = data.NimueTDSSmartResurfacer;
                    row["NimueTDSMicroNeedling"] = data.NimueTDSMicroNeedling;

                    row["MaskActiveRejuvanation"] = data.MaskActiveRejuvanation;
                    row["MaskGlycolic"] = data.MaskGlycolic;
                    row["MaskTCA"] = data.MaskTCA;
                    row["MaskNimueSRC_ED"] = data.MaskNimueSRC_ED;
                    row["MaskNimueSRC_HP"] = data.MaskNimueSRC_HP;
                    row["MaskNimueSRC_P"] = data.MaskNimueSRC_P;
                    row["MaskSmartResurfacer"] = data.MaskSmartResurfacer;
                    row["MaskMicroNeedling"] = data.MaskMicroNeedling;

                    using (MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter))
                    {
                        adapter.UpdateCommand = builder.GetUpdateCommand();
                        adapter.InsertCommand = builder.GetInsertCommand();
                        adapter.DeleteCommand = builder.GetDeleteCommand();

                        adapter.Update(followUpTreatmentTable);
                    }
                }
            }
        }


        public DataTable GetClientAppointments(int appointmentId)
        {
            string query = "SELECT * FROM AppointmentClientHistory WHERE AppointmentID = @AppointmentID";
            return ExecuteQuery(query, new MySqlParameter("@AppointmentID", appointmentId));
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
