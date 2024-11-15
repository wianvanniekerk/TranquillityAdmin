using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Data.Clients;
using WindowsFormsApp1.FormFuntionality;
using WindowsFormsApp1.Views.Clients.View;
using WindowsFormsApp1.Views.Clients;
using WindowsFormsApp1.Views.Orders;
using WindowsFormsApp1.Data.Appointments;
using System.IO;

namespace WindowsFormsApp1.Views.Appointments
{
    public partial class AppointmentClientHistory : Form
    {
        private int appointmentId;
        private int clientId;
        private DataHandlerAppointmentClientHistory handler = new DataHandlerAppointmentClientHistory();
        private DataTable appointmentClientHistoryGeneralDataTable;
        private DataTable appointmentClientHistoryMedicalDataTable;
        private DataTable appointmentClientHistoryMedicationDataTable;
        private BindingSource appointmentClientHistoryGeneralBindingSource = new BindingSource();
        private BindingSource appointmentClientHistoryMedicalBindingSource = new BindingSource();
        private BindingSource appointmentClientHistoryMedicationBindingSource = new BindingSource();

        private AppointmentsView parentForm;

        private DateTimePicker dateTimePicker = new DateTimePicker();

        public AppointmentClientHistory(int _appointmentID, int _clientID, AppointmentsView parent)
        {
            InitializeComponent();
            appointmentId = _appointmentID;
            clientId = _clientID;
            this.WindowState = FormWindowState.Maximized;
            this.parentForm = parent;
        }

        private void LoadAppointmentClientGeneralData()
        {
            appointmentClientHistoryGeneralDataTable = handler.GetClientAppointments(appointmentId);
            appointmentClientHistoryGeneralBindingSource.DataSource = appointmentClientHistoryGeneralDataTable;
            dgvAppointmentClientHistoryGeneral.DataSource = appointmentClientHistoryGeneralBindingSource;
            dgvAppointmentClientHistoryGeneral.Dock = DockStyle.Fill;
            SetupHistoryDataGeneralGridView();
        }

        private void SetupHistoryDataGeneralGridView()
        {
            dgvAppointmentClientHistoryGeneral.AllowUserToAddRows = true;
            dgvAppointmentClientHistoryGeneral.AllowUserToDeleteRows = false;
            dgvAppointmentClientHistoryGeneral.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dgvAppointmentClientHistoryGeneral.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvAppointmentClientHistoryGeneral.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvAppointmentClientHistoryGeneral.RowTemplate.Height = 60;
            dgvAppointmentClientHistoryGeneral.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            string[] columnsToHide = { "AppointmentClientHistoryID", "AppointmentID", "ClientID", "HormonalImbalance", "Pregnant", "Breastfeeding", "Smoker", "SkinCancer", "IPL_Laser_2Weeks", "SkinResurfacing_ChemicalPeels_2Weeks", "BotoxFillers_2Weeks", "WaxingElectrolysis_3Days", "MedicalConditions_Surgery_PastYear", "TretinoinMedication", "AccutanesMedication", "CortisoneMedication", "ThyroidMedication", "BloodPressureMedication", "HormonalContraceptives", "OtherMedication", "Allergies", "CreatedAt" };
            foreach (string columnName in columnsToHide)
            {
                if (dgvAppointmentClientHistoryGeneral.Columns[columnName] != null)
                {
                    dgvAppointmentClientHistoryGeneral.Columns[columnName].Visible = false;
                }
            }
        }

        private void LoadAppointmentClientMedicalData()
        {
            appointmentClientHistoryMedicalDataTable = handler.GetClientAppointments(appointmentId);
            appointmentClientHistoryMedicalBindingSource.DataSource = appointmentClientHistoryMedicalDataTable;
            dgvAppointmentClientHistoryMedical.DataSource = appointmentClientHistoryMedicalBindingSource;
            dgvAppointmentClientHistoryMedical.Dock = DockStyle.Fill;
            SetupHistoryDataMedicalGridView();
        }

        private void SetupHistoryDataMedicalGridView()
        {
            dgvAppointmentClientHistoryMedical.AllowUserToAddRows = true;
            dgvAppointmentClientHistoryMedical.AllowUserToDeleteRows = false;
            dgvAppointmentClientHistoryMedical.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dgvAppointmentClientHistoryMedical.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvAppointmentClientHistoryMedical.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvAppointmentClientHistoryMedical.RowTemplate.Height = 60;
            dgvAppointmentClientHistoryMedical.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            string[] columnsToHide = { "AppointmentClientHistoryID", "AppointmentID", "ClientID", "CurrentRange", "MedicalConditions_Surgery_PastYear", "TretinoinMedication", "AccutanesMedication", "CortisoneMedication", "ThyroidMedication", "BloodPressureMedication", "HormonalContraceptives", "OtherMedication", "Allergies", "CreatedAt" };
            foreach (string columnName in columnsToHide)
            {
                if (dgvAppointmentClientHistoryMedical.Columns[columnName] != null)
                {
                    dgvAppointmentClientHistoryMedical.Columns[columnName].Visible = false;
                }
            }
        }

        private void LoadAppointmentClientMedicationData()
        {
            appointmentClientHistoryMedicationDataTable = handler.GetClientAppointments(appointmentId);
            appointmentClientHistoryMedicationBindingSource.DataSource = appointmentClientHistoryMedicationDataTable;
            dgvAppointmentClientHistoryMedication.DataSource = appointmentClientHistoryMedicationBindingSource;
            dgvAppointmentClientHistoryMedication.Dock = DockStyle.Fill;
            SetupHistoryDataMedicationGridView();
        }

        private void SetupHistoryDataMedicationGridView()
        {
            dgvAppointmentClientHistoryMedication.AllowUserToAddRows = true;
            dgvAppointmentClientHistoryMedication.AllowUserToDeleteRows = false;
            dgvAppointmentClientHistoryMedication.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dgvAppointmentClientHistoryMedication.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvAppointmentClientHistoryMedication.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvAppointmentClientHistoryMedication.RowTemplate.Height = 60;
            dgvAppointmentClientHistoryMedication.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            string[] columnsToHide = {"AppointmentClientHistoryID", "AppointmentID", "ClientID", "CurrentRange", "HormonalImbalance", "Pregnant", "Breastfeeding", "Smoker", "SkinCancer", "IPL_Laser_2Weeks", "SkinResurfacing_ChemicalPeels_2Weeks", "BotoxFillers_2Weeks", "WaxingElectrolysis_3Days", "CreatedAt" };
            foreach (string columnName in columnsToHide)
            {
                if (dgvAppointmentClientHistoryMedication.Columns[columnName] != null)
                {
                    dgvAppointmentClientHistoryMedication.Columns[columnName].Visible = false;
                }
            }
        }

        private void SetupInitialTreatmentDataGridView()
        {
            dgvInitialTreatment.AutoGenerateColumns = false;
            dgvInitialTreatment.AllowUserToAddRows = false;
            dgvInitialTreatment.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dgvInitialTreatment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvInitialTreatment.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvInitialTreatment.RowTemplate.Height = 60;
            dgvInitialTreatment.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgvInitialTreatment.Columns.Add("Attribute", "Attribute");
            dgvInitialTreatment.Columns.Add("SmartMicropeel", "Smart Micropeel");
            dgvInitialTreatment.Columns.Add("ActiveRejuvenation", "Introductory Active Rejuvenation Treatment (3-8 min)");
            dgvInitialTreatment.Columns.Add("ThermalDetox", "Thermal Detox Peel");
            dgvInitialTreatment.Columns.Add("TherapeuticTreatment", "Therapeutic Treatment");
            dgvInitialTreatment.Columns.Add("DeepCleanse", "Deep Cleanse Treatment");

            dgvInitialTreatment.Rows.Add("Date", "", "", "", "", "");
            dgvInitialTreatment.Rows.Add("Super Fluid/s", "", "", "", "", "");
            dgvInitialTreatment.Rows.Add("Nimue-TDS™", "", "", "", "", "");
            dgvInitialTreatment.Rows.Add("Mask", "", "", "", "", "");

            dateTimePicker.Visible = false;
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "yyyy-MM-dd";
            dateTimePicker.ValueChanged += new EventHandler(dateTimePicker_ValueChanged);
            this.Controls.Add(dateTimePicker);

            dgvInitialTreatment.CellEnter += new DataGridViewCellEventHandler(dgvInitialTreatment_CellEnter);

            LoadInitialTreatment(appointmentId);
        }

        private void LoadInitialTreatment(int _appointmentId)
        {
            try
            {
                InitialTreatmentData data = handler.FetchInitalTreatment(_appointmentId);

                if (data == null)
                {
                    return;
                }

                // Load date values into row 0 (Date row)
                dgvInitialTreatment.Rows[0].Cells[1].Value = data.DateSmartMicroPeel.ToShortDateString();
                dgvInitialTreatment.Rows[0].Cells[2].Value = data.DateActiveRejuvenation.ToShortDateString();
                dgvInitialTreatment.Rows[0].Cells[3].Value = data.DateThermalDetox.ToShortDateString();
                dgvInitialTreatment.Rows[0].Cells[4].Value = data.DateTherapeuticTreatment.ToShortDateString();
                dgvInitialTreatment.Rows[0].Cells[5].Value = data.DateDeepCleanse.ToShortDateString();

                // Load SuperFluids values into row 1 (Super Fluid/s row)
                dgvInitialTreatment.Rows[1].Cells[1].Value = data.SuperFluidsSmartMicroPeel;
                dgvInitialTreatment.Rows[1].Cells[2].Value = data.SuperFluidsActiveRejuvenation;
                dgvInitialTreatment.Rows[1].Cells[3].Value = data.SuperFluidsThermalDetox;
                dgvInitialTreatment.Rows[1].Cells[4].Value = data.SuperFluidsTherapeuticTreatment;
                dgvInitialTreatment.Rows[1].Cells[5].Value = data.SuperFluidsDeepCleanse;

                // Load Nimue-TDS™ values into row 2 (Nimue-TDS™ row)
                dgvInitialTreatment.Rows[2].Cells[1].Value = data.NimueTDSSmartMicroPeel;
                dgvInitialTreatment.Rows[2].Cells[2].Value = data.NimueTDSActiveRejuvenation;
                dgvInitialTreatment.Rows[2].Cells[3].Value = data.NimueTDSThermalDetox;
                dgvInitialTreatment.Rows[2].Cells[4].Value = data.NimueTDSTherapeuticTreatment;
                dgvInitialTreatment.Rows[2].Cells[5].Value = data.NimueTDSDeepCleanse;

                // Load Mask values into row 3 (Mask row)
                dgvInitialTreatment.Rows[3].Cells[1].Value = data.MaskSmartMicroPeel;
                dgvInitialTreatment.Rows[3].Cells[2].Value = data.MaskActiveRejuvenation;
                dgvInitialTreatment.Rows[3].Cells[3].Value = data.MaskThermalDetox;
                dgvInitialTreatment.Rows[3].Cells[4].Value = data.MaskTherapeuticTreatment;
                dgvInitialTreatment.Rows[3].Cells[5].Value = data.MaskDeepCleanse;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading initial treatment data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void SaveInitalTreatment()
        {
            try
            {
                InitialTreatmentData data = new InitialTreatmentData
                {
                    // Save Date values from row 0
                    DateSmartMicroPeel = DateTime.Parse(dgvInitialTreatment.Rows[0].Cells[1].Value?.ToString() ?? DateTime.Now.ToShortDateString()),
                    DateActiveRejuvenation = DateTime.Parse(dgvInitialTreatment.Rows[0].Cells[2].Value?.ToString() ?? DateTime.Now.ToShortDateString()),
                    DateThermalDetox = DateTime.Parse(dgvInitialTreatment.Rows[0].Cells[3].Value?.ToString() ?? DateTime.Now.ToShortDateString()),
                    DateTherapeuticTreatment = DateTime.Parse(dgvInitialTreatment.Rows[0].Cells[4].Value?.ToString() ?? DateTime.Now.ToShortDateString()),
                    DateDeepCleanse = DateTime.Parse(dgvInitialTreatment.Rows[0].Cells[5].Value?.ToString() ?? DateTime.Now.ToShortDateString()),

                    // Save Super Fluids values from row 1
                    SuperFluidsSmartMicroPeel = dgvInitialTreatment.Rows[1].Cells[1].Value?.ToString() ?? "",
                    SuperFluidsActiveRejuvenation = dgvInitialTreatment.Rows[1].Cells[2].Value?.ToString() ?? "",
                    SuperFluidsThermalDetox = dgvInitialTreatment.Rows[1].Cells[3].Value?.ToString() ?? "",
                    SuperFluidsTherapeuticTreatment = dgvInitialTreatment.Rows[1].Cells[4].Value?.ToString() ?? "",
                    SuperFluidsDeepCleanse = dgvInitialTreatment.Rows[1].Cells[5].Value?.ToString() ?? "",

                    // Save Nimue-TDS™ values from row 2
                    NimueTDSSmartMicroPeel = dgvInitialTreatment.Rows[2].Cells[1].Value?.ToString() ?? "",
                    NimueTDSActiveRejuvenation = dgvInitialTreatment.Rows[2].Cells[2].Value?.ToString() ?? "",
                    NimueTDSThermalDetox = dgvInitialTreatment.Rows[2].Cells[3].Value?.ToString() ?? "",
                    NimueTDSTherapeuticTreatment = dgvInitialTreatment.Rows[2].Cells[4].Value?.ToString() ?? "",
                    NimueTDSDeepCleanse = dgvInitialTreatment.Rows[2].Cells[5].Value?.ToString() ?? "",

                    // Save Mask values from row 3
                    MaskSmartMicroPeel = dgvInitialTreatment.Rows[3].Cells[1].Value?.ToString() ?? "",
                    MaskActiveRejuvenation = dgvInitialTreatment.Rows[3].Cells[2].Value?.ToString() ?? "",
                    MaskThermalDetox = dgvInitialTreatment.Rows[3].Cells[3].Value?.ToString() ?? "",
                    MaskTherapeuticTreatment = dgvInitialTreatment.Rows[3].Cells[4].Value?.ToString() ?? "",
                    MaskDeepCleanse = dgvInitialTreatment.Rows[3].Cells[5].Value?.ToString() ?? ""
                };

                handler.UpdateInitialTreatment(handler.GetClientID(appointmentId), appointmentId, data);
                MessageBox.Show("Initial treatment data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ensure Date columns are filled in before you save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving initial treatment data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }










        private void SetupFollowUpTreatmentDataGridView()
        {
            dgvFollowUpTreatment.AutoGenerateColumns = false;
            dgvFollowUpTreatment.AllowUserToAddRows = false;
            dgvFollowUpTreatment.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dgvFollowUpTreatment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvFollowUpTreatment.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvFollowUpTreatment.RowTemplate.Height = 60;
            dgvFollowUpTreatment.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Add columns for each attribute
            dgvFollowUpTreatment.Columns.Add("Attribute", "Attribute");
            dgvFollowUpTreatment.Columns.Add("ActiveRejuvenation", "Active Rejuvenation Treatment");
            dgvFollowUpTreatment.Columns.Add("Glycolic", "35% Glycolic Treatment");
            dgvFollowUpTreatment.Columns.Add("TCA", "7.5% TCA Treatment (non-EU countries)");
            dgvFollowUpTreatment.Columns.Add("NimueSRC_ED", "Nimue-SRC™ ED Treatment");
            dgvFollowUpTreatment.Columns.Add("NimueSRC_HP", "Nimue-SRC™ HP Treatment");
            dgvFollowUpTreatment.Columns.Add("NimueSRC_P", "Nimue-SRC™ P Treatment");
            dgvFollowUpTreatment.Columns.Add("SmartResurfacer", "Smart Resurfacer");
            dgvFollowUpTreatment.Columns.Add("MicroNeedling", "Micro-needling Treatment");

            // Add rows for different categories
            dgvFollowUpTreatment.Rows.Add("Date", "", "", "", "", "", "", "", "");
            dgvFollowUpTreatment.Rows.Add("Layers/Min", "", "", "", "", "", "", "", "");
            dgvFollowUpTreatment.Rows.Add("Super Fluid/s", "", "", "", "", "", "", "", "");
            dgvFollowUpTreatment.Rows.Add("Nimue-TDS™", "", "", "", "", "", "", "", "");
            dgvFollowUpTreatment.Rows.Add("Mask", "", "", "", "", "", "", "", "");

            dateTimePicker.Visible = false;
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "yyyy-MM-dd";
            dateTimePicker.ValueChanged += new EventHandler(dateTimePicker_ValueChanged);
            this.Controls.Add(dateTimePicker);

            dgvFollowUpTreatment.CellEnter += new DataGridViewCellEventHandler(dgvFollowUpTreatment_CellEnter);

            LoadFollowUpTreatment(appointmentId);
        }

        private void LoadFollowUpTreatment(int _appointmentId)
        {
            try
            {
                FollowUpTreatmentData data = handler.FetchFollowUpTreatment(_appointmentId);

                if (data == null)
                {
                    return;
                }

                // Set Dates
                dgvFollowUpTreatment.Rows[0].Cells[1].Value = data.DateActiveRejuvanation.Date.ToShortDateString();
                dgvFollowUpTreatment.Rows[0].Cells[2].Value = data.DateGlycolic.Date.ToShortDateString();
                dgvFollowUpTreatment.Rows[0].Cells[3].Value = data.DateTCA.Date.ToShortDateString();
                dgvFollowUpTreatment.Rows[0].Cells[4].Value = data.DateNimueSRC_ED.Date.ToShortDateString();
                dgvFollowUpTreatment.Rows[0].Cells[5].Value = data.DateNimueSRC_HP.Date.ToShortDateString();
                dgvFollowUpTreatment.Rows[0].Cells[6].Value = data.DateNimueSRC_P.Date.ToShortDateString();
                dgvFollowUpTreatment.Rows[0].Cells[7].Value = data.DateSmartResurfacer.Date.ToShortDateString();
                dgvFollowUpTreatment.Rows[0].Cells[8].Value = data.DateMicroNeedling.Date.ToShortDateString();

                // Set Layers/Min
                dgvFollowUpTreatment.Rows[1].Cells[1].Value = data.LayersMinActiveRejuvanation;
                dgvFollowUpTreatment.Rows[1].Cells[2].Value = data.LayersMinGlycolic;
                dgvFollowUpTreatment.Rows[1].Cells[3].Value = data.LayersMinTCA;
                dgvFollowUpTreatment.Rows[1].Cells[4].Value = data.LayersMinNimueSRC_ED;
                dgvFollowUpTreatment.Rows[1].Cells[5].Value = data.LayersMinNimueSRC_HP;
                dgvFollowUpTreatment.Rows[1].Cells[6].Value = data.LayersMinNimueSRC_P;
                dgvFollowUpTreatment.Rows[1].Cells[7].Value = data.LayersMinSmartResurfacer;
                dgvFollowUpTreatment.Rows[1].Cells[8].Value = data.LayersMinMicroNeedling;

                // Set Super Fluids
                dgvFollowUpTreatment.Rows[2].Cells[1].Value = data.SuperFluidsActiveRejuvanation;
                dgvFollowUpTreatment.Rows[2].Cells[2].Value = data.SuperFluidsGlycolic;
                dgvFollowUpTreatment.Rows[2].Cells[3].Value = data.SuperFluidsTCA;
                dgvFollowUpTreatment.Rows[2].Cells[4].Value = data.SuperFluidsNimueSRC_ED;
                dgvFollowUpTreatment.Rows[2].Cells[5].Value = data.SuperFluidsNimueSRC_HP;
                dgvFollowUpTreatment.Rows[2].Cells[6].Value = data.SuperFluidsNimueSRC_P;
                dgvFollowUpTreatment.Rows[2].Cells[7].Value = data.SuperFluidsSmartResurfacer;
                dgvFollowUpTreatment.Rows[2].Cells[8].Value = data.SuperFluidsMicroNeedling;

                // Set Nimue-TDS
                dgvFollowUpTreatment.Rows[3].Cells[1].Value = data.NimueTDSActiveRejuvanation;
                dgvFollowUpTreatment.Rows[3].Cells[2].Value = data.NimueTDSGlycolic;
                dgvFollowUpTreatment.Rows[3].Cells[3].Value = data.NimueTDSTCA;
                dgvFollowUpTreatment.Rows[3].Cells[4].Value = data.NimueTDSNimueSRC_ED;
                dgvFollowUpTreatment.Rows[3].Cells[5].Value = data.NimueTDSNimueSRC_HP;
                dgvFollowUpTreatment.Rows[3].Cells[6].Value = data.NimueTDSNimueSRC_P;
                dgvFollowUpTreatment.Rows[3].Cells[7].Value = data.NimueTDSSmartResurfacer;
                dgvFollowUpTreatment.Rows[3].Cells[8].Value = data.NimueTDSMicroNeedling;

                // Set Mask
                dgvFollowUpTreatment.Rows[4].Cells[1].Value = data.MaskActiveRejuvanation;
                dgvFollowUpTreatment.Rows[4].Cells[2].Value = data.MaskGlycolic;
                dgvFollowUpTreatment.Rows[4].Cells[3].Value = data.MaskTCA;
                dgvFollowUpTreatment.Rows[4].Cells[4].Value = data.MaskNimueSRC_ED;
                dgvFollowUpTreatment.Rows[4].Cells[5].Value = data.MaskNimueSRC_HP;
                dgvFollowUpTreatment.Rows[4].Cells[6].Value = data.MaskNimueSRC_P;
                dgvFollowUpTreatment.Rows[4].Cells[7].Value = data.MaskSmartResurfacer;
                dgvFollowUpTreatment.Rows[4].Cells[8].Value = data.MaskMicroNeedling;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading follow-up treatment data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveFollowUpTreatment()
        {
            try
            {
                FollowUpTreatmentData data = new FollowUpTreatmentData
                {
                    // Set Dates
                    DateActiveRejuvanation = DateTime.Parse(dgvFollowUpTreatment.Rows[0].Cells[1].Value?.ToString() ?? DateTime.Now.ToShortDateString()),
                    DateGlycolic = DateTime.Parse(dgvFollowUpTreatment.Rows[0].Cells[2].Value?.ToString() ?? DateTime.Now.ToShortDateString()),
                    DateTCA = DateTime.Parse(dgvFollowUpTreatment.Rows[0].Cells[3].Value?.ToString() ?? DateTime.Now.ToShortDateString()),
                    DateNimueSRC_ED = DateTime.Parse(dgvFollowUpTreatment.Rows[0].Cells[4].Value?.ToString() ?? DateTime.Now.ToShortDateString()),
                    DateNimueSRC_HP = DateTime.Parse(dgvFollowUpTreatment.Rows[0].Cells[5].Value?.ToString() ?? DateTime.Now.ToShortDateString()),
                    DateNimueSRC_P = DateTime.Parse(dgvFollowUpTreatment.Rows[0].Cells[6].Value?.ToString() ?? DateTime.Now.ToShortDateString()),
                    DateSmartResurfacer = DateTime.Parse(dgvFollowUpTreatment.Rows[0].Cells[7].Value?.ToString() ?? DateTime.Now.ToShortDateString()),
                    DateMicroNeedling = DateTime.Parse(dgvFollowUpTreatment.Rows[0].Cells[8].Value?.ToString() ?? DateTime.Now.ToShortDateString()),

                    // Set Layers/Min
                    LayersMinActiveRejuvanation = int.Parse(dgvFollowUpTreatment.Rows[1].Cells[1].Value?.ToString() ?? "0"),
                    LayersMinGlycolic = int.Parse(dgvFollowUpTreatment.Rows[1].Cells[2].Value?.ToString() ?? "0"),
                    LayersMinTCA = int.Parse(dgvFollowUpTreatment.Rows[1].Cells[3].Value?.ToString() ?? "0"),
                    LayersMinNimueSRC_ED = int.Parse(dgvFollowUpTreatment.Rows[1].Cells[4].Value?.ToString() ?? "0"),
                    LayersMinNimueSRC_HP = int.Parse(dgvFollowUpTreatment.Rows[1].Cells[5].Value?.ToString() ?? "0"),
                    LayersMinNimueSRC_P = int.Parse(dgvFollowUpTreatment.Rows[1].Cells[6].Value?.ToString() ?? "0"),
                    LayersMinSmartResurfacer = int.Parse(dgvFollowUpTreatment.Rows[1].Cells[7].Value?.ToString() ?? "0"),
                    LayersMinMicroNeedling = int.Parse(dgvFollowUpTreatment.Rows[1].Cells[8].Value?.ToString() ?? "0"),

                    // Set Super Fluids
                    SuperFluidsActiveRejuvanation = dgvFollowUpTreatment.Rows[2].Cells[1].Value?.ToString(),
                    SuperFluidsGlycolic = dgvFollowUpTreatment.Rows[2].Cells[2].Value?.ToString(),
                    SuperFluidsTCA = dgvFollowUpTreatment.Rows[2].Cells[3].Value?.ToString(),
                    SuperFluidsNimueSRC_ED = dgvFollowUpTreatment.Rows[2].Cells[4].Value?.ToString(),
                    SuperFluidsNimueSRC_HP = dgvFollowUpTreatment.Rows[2].Cells[5].Value?.ToString(),
                    SuperFluidsNimueSRC_P = dgvFollowUpTreatment.Rows[2].Cells[6].Value?.ToString(),
                    SuperFluidsSmartResurfacer = dgvFollowUpTreatment.Rows[2].Cells[7].Value?.ToString(),
                    SuperFluidsMicroNeedling = dgvFollowUpTreatment.Rows[2].Cells[8].Value?.ToString(),

                    // Set Nimue-TDS
                    NimueTDSActiveRejuvanation = dgvFollowUpTreatment.Rows[3].Cells[1].Value?.ToString(),
                    NimueTDSGlycolic = dgvFollowUpTreatment.Rows[3].Cells[2].Value?.ToString(),
                    NimueTDSTCA = dgvFollowUpTreatment.Rows[3].Cells[3].Value?.ToString(),
                    NimueTDSNimueSRC_ED = dgvFollowUpTreatment.Rows[3].Cells[4].Value?.ToString(),
                    NimueTDSNimueSRC_HP = dgvFollowUpTreatment.Rows[3].Cells[5].Value?.ToString(),
                    NimueTDSNimueSRC_P = dgvFollowUpTreatment.Rows[3].Cells[6].Value?.ToString(),
                    NimueTDSSmartResurfacer = dgvFollowUpTreatment.Rows[3].Cells[7].Value?.ToString(),
                    NimueTDSMicroNeedling = dgvFollowUpTreatment.Rows[3].Cells[8].Value?.ToString(),

                    // Set Mask
                    MaskActiveRejuvanation = dgvFollowUpTreatment.Rows[4].Cells[1].Value?.ToString(),
                    MaskGlycolic = dgvFollowUpTreatment.Rows[4].Cells[2].Value?.ToString(),
                    MaskTCA = dgvFollowUpTreatment.Rows[4].Cells[3].Value?.ToString(),
                    MaskNimueSRC_ED = dgvFollowUpTreatment.Rows[4].Cells[4].Value?.ToString(),
                    MaskNimueSRC_HP = dgvFollowUpTreatment.Rows[4].Cells[5].Value?.ToString(),
                    MaskNimueSRC_P = dgvFollowUpTreatment.Rows[4].Cells[6].Value?.ToString(),
                    MaskSmartResurfacer = dgvFollowUpTreatment.Rows[4].Cells[7].Value?.ToString(),
                    MaskMicroNeedling = dgvFollowUpTreatment.Rows[4].Cells[8].Value?.ToString()
                };


                handler.UpdateFollowUpTreatment(handler.GetClientID(appointmentId), appointmentId, data);
                MessageBox.Show("Follow-up treatment data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ensure Dates are filled in and that Layers/Min row uses numbers only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving follow-up treatment data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

















        private void AppointmentClientHistory_Load(object sender, EventArgs e)
        {
            LoadAppointmentClientGeneralData();
            LoadAppointmentClientMedicalData();
            LoadAppointmentClientMedicationData();
            SetupInitialTreatmentDataGridView();
            SetupFollowUpTreatmentDataGridView();
        }

        private void btnAppointmentsViewBack_Click(object sender, EventArgs e)
        {
            parentForm.RefreshAndShow();
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                parentForm.RefreshAndShow();
            }
        }

        private void btnAppointmentClientHistorySave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable appointmentClientHistoryGeneralChanges = ((DataTable)appointmentClientHistoryGeneralBindingSource.DataSource).GetChanges();
                DataTable appointmentClientHistoryMedicalChanges = ((DataTable)appointmentClientHistoryMedicalBindingSource.DataSource).GetChanges();
                DataTable appointmentClientHistoryMedicationChanges = ((DataTable)appointmentClientHistoryMedicationBindingSource.DataSource).GetChanges();

                if (appointmentClientHistoryGeneralChanges != null)
                {
                    handler.UpdateAppointmentClientHistory(appointmentClientHistoryGeneralChanges, appointmentId, clientId);
                    MessageBox.Show("Client's history details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAppointmentClientGeneralData();
                }

                if (appointmentClientHistoryMedicalChanges != null)
                {
                    handler.UpdateAppointmentClientHistory(appointmentClientHistoryMedicalChanges, appointmentId, clientId);
                    MessageBox.Show("Client's history details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAppointmentClientMedicalData();
                }

                if (appointmentClientHistoryMedicationChanges != null)
                {
                    handler.UpdateAppointmentClientHistory(appointmentClientHistoryMedicationChanges, appointmentId, clientId);
                    MessageBox.Show("Client's history details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAppointmentClientMedicationData();
                }
            }
            catch (DBConcurrencyException)
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving changes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClientsPrimaryBack_Click(object sender, EventArgs e)
        {
            ClientsPrimary clientsPrimary = new ClientsPrimary(handler.GetClientID(appointmentId), new ClientsView());
            clientsPrimary.Show();
            this.Hide();
        }

        private void dgvInitialTreatment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvInitialTreatment_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0 && e.ColumnIndex > 0 && e.ColumnIndex <= 1)
            {
                Rectangle cellRectangle = dgvInitialTreatment.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                Point cellLocation = dgvInitialTreatment.PointToScreen(new Point(cellRectangle.X, cellRectangle.Y));
                Point formLocation = this.PointToClient(cellLocation);

                dateTimePicker.Size = new Size(cellRectangle.Width, cellRectangle.Height);
                dateTimePicker.Location = new Point(formLocation.X, formLocation.Y);
                dateTimePicker.Visible = true;

                dateTimePicker.BringToFront();

                if (DateTime.TryParse(dgvInitialTreatment.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out DateTime dateValue))
                {
                    dateTimePicker.Value = dateValue;
                }
                else
                {
                    dateTimePicker.Value = DateTime.Now;
                }

                dateTimePicker.Focus();
            }
            else
            {
                dateTimePicker.Visible = false;
                dgvInitialTreatment.Rows[0].Cells[2].ReadOnly = true;
                dgvInitialTreatment.Rows[0].Cells[3].ReadOnly = true;
                dgvInitialTreatment.Rows[0].Cells[4].ReadOnly = true;
                dgvInitialTreatment.Rows[0].Cells[5].ReadOnly = true;

                dgvInitialTreatment.Rows[0].Cells[2].Value = dgvInitialTreatment.Rows[0].Cells[1].Value;
                dgvInitialTreatment.Rows[0].Cells[3].Value = dgvInitialTreatment.Rows[0].Cells[1].Value;
                dgvInitialTreatment.Rows[0].Cells[4].Value = dgvInitialTreatment.Rows[0].Cells[1].Value;
                dgvInitialTreatment.Rows[0].Cells[5].Value = dgvInitialTreatment.Rows[0].Cells[1].Value;
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (dgvInitialTreatment.CurrentCell != null && dgvInitialTreatment.CurrentCell.RowIndex == 0)
            {
                dgvInitialTreatment.CurrentCell.Value = dateTimePicker.Value.ToString("yyyy-MM-dd");
            }

            if (dgvFollowUpTreatment.CurrentCell != null && dgvFollowUpTreatment.CurrentCell.RowIndex == 0)
            {
                dgvFollowUpTreatment.CurrentCell.Value = dateTimePicker.Value.ToString("yyyy-MM-dd");
            }
        }

        private void dgvFollowUpTreatment_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0 && e.ColumnIndex > 0 && e.ColumnIndex <= 1)
            {
                Rectangle cellRectangle = dgvFollowUpTreatment.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                Point cellLocation = dgvFollowUpTreatment.PointToScreen(new Point(cellRectangle.X, cellRectangle.Y));
                Point formLocation = this.PointToClient(cellLocation);

                dateTimePicker.Size = new Size(cellRectangle.Width, cellRectangle.Height);
                dateTimePicker.Location = new Point(formLocation.X, formLocation.Y);
                dateTimePicker.Visible = true;

                dateTimePicker.BringToFront();

                if (DateTime.TryParse(dgvFollowUpTreatment.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out DateTime dateValue))
                {
                    dateTimePicker.Value = dateValue;
                }
                else
                {
                    dateTimePicker.Value = DateTime.Now;
                }

                dateTimePicker.Focus();
            }
            else
            {
                dateTimePicker.Visible = false;
                dgvFollowUpTreatment.Rows[0].Cells[2].ReadOnly = true;
                dgvFollowUpTreatment.Rows[0].Cells[3].ReadOnly = true;
                dgvFollowUpTreatment.Rows[0].Cells[4].ReadOnly = true;
                dgvFollowUpTreatment.Rows[0].Cells[5].ReadOnly = true;
                dgvFollowUpTreatment.Rows[0].Cells[6].ReadOnly = true;
                dgvFollowUpTreatment.Rows[0].Cells[7].ReadOnly = true;
                dgvFollowUpTreatment.Rows[0].Cells[8].ReadOnly = true;

                dgvFollowUpTreatment.Rows[0].Cells[2].Value = dgvFollowUpTreatment.Rows[0].Cells[1].Value;
                dgvFollowUpTreatment.Rows[0].Cells[3].Value = dgvFollowUpTreatment.Rows[0].Cells[1].Value;
                dgvFollowUpTreatment.Rows[0].Cells[4].Value = dgvFollowUpTreatment.Rows[0].Cells[1].Value;
                dgvFollowUpTreatment.Rows[0].Cells[5].Value = dgvFollowUpTreatment.Rows[0].Cells[1].Value;
                dgvFollowUpTreatment.Rows[0].Cells[6].Value = dgvFollowUpTreatment.Rows[0].Cells[1].Value;
                dgvFollowUpTreatment.Rows[0].Cells[7].Value = dgvFollowUpTreatment.Rows[0].Cells[1].Value;
                dgvFollowUpTreatment.Rows[0].Cells[8].Value = dgvFollowUpTreatment.Rows[0].Cells[1].Value;
            }
        }

        private void btnAppointmentClientHistoryInitialSave_Click(object sender, EventArgs e)
        {
            SaveInitalTreatment();
        }

        private void btnAppointmentClientHistoryFollowUpSaveClick(object sender, EventArgs e)
        {
            SaveFollowUpTreatment();
        }
    }
}
