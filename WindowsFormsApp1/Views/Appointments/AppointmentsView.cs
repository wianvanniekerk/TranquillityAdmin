using MimeKit;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Data.Appointments;
using WindowsFormsApp1.FormFuntionality;
using WindowsFormsApp1.Views.Clients;
using WindowsFormsApp1.Communication.Email;

namespace WindowsFormsApp1.Views.Appointments
{
    public partial class AppointmentsView : Form
    {
        DataHandlerAppointments handler = new DataHandlerAppointments();
        private DataTable appointmentsDataTable;
        private bool isClosing = false;

        public AppointmentsView()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            dgvAppointmentsView.RowValidated += new DataGridViewCellEventHandler(dgvAppointmentsView_RowValidated);
            dgvAppointmentsView.UserAddedRow += new DataGridViewRowEventHandler(dgvAppointmentsView_UserAddedRow);
            this.FormClosed += new FormClosedEventHandler(AppointmentsView_FormClosed);
            dgvAppointmentsView.CellContentClick += dgvAppointmentsView_CellContentClick;
            this.FormClosing += AppointmentsView_FormClosing;
        }

        private void btnAppointmentsViewBack_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void btnAppointmentsViewSave_Click(object sender, EventArgs e)
        {
            try
            {
                dgvAppointmentsView.EndEdit();
                DataTable changes = ((DataTable)dgvAppointmentsView.DataSource).GetChanges();
                if (changes != null)
                {
                    foreach (DataRow row in changes.Rows)
                    {
                        if (row.RowState != DataRowState.Deleted)
                        {
                            if (row["ClientID"] == DBNull.Value || row["StaffID"] == DBNull.Value || row["AppointmentDate"] == DBNull.Value)
                            {
                                MessageBox.Show("Please ensure all appointments have a Client, Staff member and an Appointment Date filled in before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            if (row["IsNewClient"] == DBNull.Value)
                            {
                                row["IsNewClient"] = 0;
                            }
                        }
                    }

                    DataHandlerAppointments handler = new DataHandlerAppointments();
                    handler.AppointmentInserted += NewClientDetails.OnAppointmentInserted;

                    DataTable newRows = changes.GetChanges(DataRowState.Added);
                    if (newRows != null)
                    {
                        handler.UpdateAppointments(newRows);
                    }

                    DataTable modifiedRows = changes.GetChanges(DataRowState.Modified);
                    if (modifiedRows != null)
                    {
                        handler.UpdateAppointments(modifiedRows);
                    }

                    MessageBox.Show("Changes saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshAppointmentsView();
                }
                else
                {
                    MessageBox.Show("No changes to save.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving changes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAppointmentsView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvAppointmentsView.Columns["HistoryButton"].Index)
            {
                object cellValue = dgvAppointmentsView.Rows[e.RowIndex].Cells["AppointmentID"].Value;
                object cellValueClient = dgvAppointmentsView.Rows[e.RowIndex].Cells["ClientID"].Value;
                if (cellValue != null && cellValue != DBNull.Value)
                {
                    int appointmentId = Convert.ToInt32(cellValue);
                    int clientId = Convert.ToInt32(cellValueClient);
                    OpenAppointmentClientHistory(appointmentId, clientId);
                }
            }
        }

        private void AppointmentsView_Load(object sender, EventArgs e)
        {
            RefreshAppointmentsView();
        }

        private void RefreshAppointmentsView()
        {
            handler.UpdateAppointmentStatuses();
            appointmentsDataTable = handler.FetchAppointments();
            dgvAppointmentsView.DataSource = null;
            dgvAppointmentsView.Columns.Clear();
            dgvAppointmentsView.DataSource = appointmentsDataTable;
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dgvAppointmentsView.AllowUserToAddRows = true;
            dgvAppointmentsView.AllowUserToDeleteRows = false;
            dgvAppointmentsView.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvAppointmentsView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvAppointmentsView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvAppointmentsView.RowTemplate.Height = 60;
            dgvAppointmentsView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgvAppointmentsView.CellBeginEdit += dgvAppointmentsView_CellBeginEdit;
            dgvAppointmentsView.RowValidating += dgvAppointmentsView_RowValidating;


            string[] columnsToHide = { "AppointmentID", "CreatedAt" };
            foreach (string columnName in columnsToHide)
            {
                if (dgvAppointmentsView.Columns[columnName] != null)
                {
                    dgvAppointmentsView.Columns[columnName].Visible = false;
                }
            }

            DataTable clients = handler.FetchClients();
            DataTable staff = handler.FetchStaff();

            DataGridViewComboBoxColumn clientComboBoxColumn = new DataGridViewComboBoxColumn
            {
                Name = "ClientID",
                HeaderText = "Client",
                DataSource = clients,
                DisplayMember = "ClientName",
                ValueMember = "ClientID",
                DataPropertyName = "ClientID"
            };

            DataGridViewComboBoxColumn staffComboBoxColumn = new DataGridViewComboBoxColumn
            {
                Name = "StaffID",
                HeaderText = "Staff",
                DataSource = staff,
                DisplayMember = "StaffName",
                ValueMember = "StaffID",
                DataPropertyName = "StaffID"
            };

            DataGridViewDateTimePickerColumn dateColumn = new DataGridViewDateTimePickerColumn(true)
            {
                Name = "AppointmentDate",
                HeaderText = "Appointment Date",
                DataPropertyName = "AppointmentDate",
                DateFormat = "yyyy-MM-dd HH:mm:ss"
            };

            DataGridViewCheckBoxColumn reminderSentCheckBox = new DataGridViewCheckBoxColumn
            {
                Name = "ReminderSent",
                HeaderText = "Reminder Sent",
                DataPropertyName = "ReminderSent",
                TrueValue = true,
                FalseValue = false
            };

            DataGridViewCheckBoxColumn isNewClientCheckBox = new DataGridViewCheckBoxColumn
            {
                Name = "IsNewClient",
                HeaderText = "Is New Client",
                DataPropertyName = "IsNewClient",
                TrueValue = 1,
                FalseValue = 0,
                DefaultCellStyle = new DataGridViewCellStyle { NullValue = false }
            };


            if (dgvAppointmentsView.Columns["HistoryButton"] == null)
            {
                DataGridViewButtonColumn historyButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "HistoryButton",
                    HeaderText = "Client History",
                    Text = "View More Details",
                    UseColumnTextForButtonValue = true,
                };
                historyButtonColumn.DefaultCellStyle.BackColor = Color.Blue;
                dgvAppointmentsView.Columns.Add(historyButtonColumn);
            }


            if (dgvAppointmentsView.Columns["ClientID"] != null)
            {
                int clientIndex = dgvAppointmentsView.Columns["ClientID"].Index;
                dgvAppointmentsView.Columns.RemoveAt(clientIndex);
                dgvAppointmentsView.Columns.Insert(clientIndex, clientComboBoxColumn);
            }

            if (dgvAppointmentsView.Columns["StaffID"] != null)
            {
                int staffIndex = dgvAppointmentsView.Columns["StaffID"].Index;
                dgvAppointmentsView.Columns.RemoveAt(staffIndex);
                dgvAppointmentsView.Columns.Insert(staffIndex, staffComboBoxColumn);
            }

            if (dgvAppointmentsView.Columns["AppointmentType"] != null)
            {
                DataGridViewComboBoxColumn appointmentTypeComboBoxColumn = new DataGridViewComboBoxColumn
                {
                    Name = "AppointmentType",
                    HeaderText = "Appointment Type",
                    DataSource = new string[] { "Follow-up", "Skin Analysis", "Treatments" },
                    DataPropertyName = "AppointmentType"
                };

                int appointmentTypeIndex = dgvAppointmentsView.Columns["AppointmentType"].Index;
                dgvAppointmentsView.Columns.RemoveAt(appointmentTypeIndex);
                dgvAppointmentsView.Columns.Insert(appointmentTypeIndex, appointmentTypeComboBoxColumn);
            }

            if (dgvAppointmentsView.Columns["AppointmentDate"] != null)
            {
                int appointmentDateIndex = dgvAppointmentsView.Columns["AppointmentDate"].Index;
                dgvAppointmentsView.Columns.RemoveAt(appointmentDateIndex);
                dgvAppointmentsView.Columns.Insert(appointmentDateIndex, dateColumn);
            }

            if (dgvAppointmentsView.Columns["Status"] != null)
            {
                DataGridViewComboBoxColumn statusComboBoxColumn = new DataGridViewComboBoxColumn
                {
                    Name = "Status",
                    HeaderText = "Status",
                    DataSource = new string[] { "Scheduled", "Completed" },
                    DataPropertyName = "Status"
                };

                int statusIndex = dgvAppointmentsView.Columns["Status"].Index;
                dgvAppointmentsView.Columns.RemoveAt(statusIndex);
                dgvAppointmentsView.Columns.Insert(statusIndex, statusComboBoxColumn);
            }

            if (dgvAppointmentsView.Columns["IsNewClient"] != null)
            {
                int isNewClientIndex = dgvAppointmentsView.Columns["IsNewClient"].Index;
                dgvAppointmentsView.Columns.RemoveAt(isNewClientIndex);
                dgvAppointmentsView.Columns.Insert(isNewClientIndex, isNewClientCheckBox);
            }
            else
            {
                dgvAppointmentsView.Columns.Add(isNewClientCheckBox);
            }

            if (dgvAppointmentsView.Columns["ReminderSent"] != null)
            {
                int reminderSentIndex = dgvAppointmentsView.Columns["ReminderSent"].Index;
                dgvAppointmentsView.Columns.RemoveAt(reminderSentIndex);
            }
            dgvAppointmentsView.Columns.Add(reminderSentCheckBox);
        }

        private void OpenAppointmentClientHistory(int appointmentId, int clientId)
        {
            AppointmentClientHistory appointmentClientHistoryForm = new AppointmentClientHistory(appointmentId, clientId, this);
            this.Hide();
            appointmentClientHistoryForm.Show();
        }

        public void RefreshAndShow()
        {
            RefreshAppointmentsView();
            try
            {
                this.Show();
            }
            catch (Exception)
            {

            }
        }

        private void dgvAppointmentsView_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void AppointmentsView_FormClosed(object sender, FormClosedEventArgs e)
        {
            NewClientDetails.isEmailSent = false;
        }

        private void dgvAppointmentsView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
        }

        private void dgvAppointmentsView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isClosing) return;

            if (e.RowIndex == dgvAppointmentsView.NewRowIndex - 1)
            {
                DataGridViewRow row = dgvAppointmentsView.Rows[e.RowIndex];

                if (row.Cells["ClientID"].Value == null ||
                    row.Cells["StaffID"].Value == null ||
                    row.Cells["AppointmentDate"].Value == null)
                {
                    e.Cancel = true;
                    MessageBox.Show("Client, Staff, and Appointment Date are required fields.",
                                    "Validation Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void deleteRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointmentsView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvAppointmentsView.SelectedRows[0];
                int columnIndex = selectedRow.Cells["AppointmentID"].ColumnIndex;
                int appointmentId = (int)selectedRow.Cells[columnIndex].Value;

                var confirmResult = MessageBox.Show("Are you sure you want to delete this appointment? This will also delete all related records.",
                                                    "Confirm Delete",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        handler.DeleteAppointment(appointmentId);
                        MessageBox.Show("Appointment and related records deleted successfully.", "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RefreshAppointmentsView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting appointment: {ex.Message}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvAppointmentsView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex == dgvAppointmentsView.NewRowIndex)
            {
                var unsavedRows = dgvAppointmentsView.Rows.Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow && r.Cells[0].Value == null)
                    .ToList();

                if (unsavedRows.Any())
                {
                    e.Cancel = true;
                    MessageBox.Show("Please save the current new record before adding another one.",
                                    "Validation Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
        }

        private void AppointmentsView_FormClosing(object sender, FormClosingEventArgs e)
        {
            isClosing = true;
        }
    }
}
