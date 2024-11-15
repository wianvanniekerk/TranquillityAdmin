using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Data.Clients;
using WindowsFormsApp1.FormFuntionality;
using WindowsFormsApp1.Views.Appointments;
using WindowsFormsApp1.Views.Clients.View;
using WindowsFormsApp1.Views.Orders;

namespace WindowsFormsApp1.Views.Clients
{
    public partial class ClientsPrimary : Form
    {
        private int clientId;
        private DataHandlerClientsPrimary handler = new DataHandlerClientsPrimary();
        private DataHandlerClients clientHandler = new DataHandlerClients();
        private DataTable clientsDataTable;
        private BindingSource appointmentBindingSource = new BindingSource();
        private BindingSource orderBindingSource = new BindingSource();
        private BindingSource productUsageBindingSource = new BindingSource();

        private ClientsView parentForm;

        public ClientsPrimary(int _clientID, ClientsView parent)
        {
            InitializeComponent();
            clientId = _clientID;
            this.WindowState = FormWindowState.Maximized;
            this.parentForm = parent;
            dgvClientsPrimaryAppointments.CellMouseClick += dgvClientsPrimaryAppointments_CellMouseClick;
            dgvClientsPrimaryOrders.CellMouseClick += dgvClientsPrimaryOrders_CellMouseClick;
            dgvClientsSecondaryProductUsage.CellMouseClick += dgvClientsSecondaryProductUsage_CellMouseClick;
            RefreshClientsView();
            handler.LoadImagesForClient(clientId);
            UpdateImageDisplay();
        }

        private void RefreshClientsView()
        {
            clientsDataTable = handler.GetClientDetails(clientId);
            dgvClientsPrimaryGeneral.DataSource = clientsDataTable;
            SetupGeneralDataGridView();
        }

        private void SetupGeneralDataGridView()
        {
            dgvClientsPrimaryGeneral.AllowUserToAddRows = true;
            dgvClientsPrimaryGeneral.AllowUserToDeleteRows = false;
            dgvClientsPrimaryGeneral.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvClientsPrimaryGeneral.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvClientsPrimaryGeneral.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvClientsPrimaryGeneral.RowTemplate.Height = 60;
            dgvClientsPrimaryGeneral.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            string[] columnsToHide = { "ClientID", "RegistrationDate", "CreatedAt", "Password"};
            foreach (string columnName in columnsToHide)
            {
                if (dgvClientsPrimaryGeneral.Columns[columnName] != null)
                {
                    dgvClientsPrimaryGeneral.Columns[columnName].Visible = false;
                }
            }

            DataGridViewDateTimePickerColumn dateColumn = new DataGridViewDateTimePickerColumn(includeTime: false);
            dateColumn.Name = "DateOfBirth";
            dateColumn.HeaderText = "DateOfBirth";
            dateColumn.DataPropertyName = "DateOfBirth";

            if (dgvClientsPrimaryGeneral.Columns["DateOfBirth"] != null)
            {
                int dateOfBirthDateIndex = dgvClientsPrimaryGeneral.Columns["DateOfBirth"].Index;
                dgvClientsPrimaryGeneral.Columns.RemoveAt(dateOfBirthDateIndex);
                dgvClientsPrimaryGeneral.Columns.Insert(dateOfBirthDateIndex, dateColumn);
            }

            if (dgvClientsPrimaryGeneral.Columns["Email"] != null)
            {
                dgvClientsPrimaryGeneral.Columns["Email"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvClientsPrimaryGeneral.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            if (dgvClientsPrimaryGeneral.Columns["IDNumber"] != null)
            {
                dgvClientsPrimaryGeneral.Columns["IDNumber"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvClientsPrimaryGeneral.Columns["IDNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            AddCheckBoxColumn("IsActive", "Is Active");
            AddCheckBoxColumn("MarketingConsent", "Marketing Consent");
        }

        private void AddCheckBoxColumn(string columnName, string headerText)
        {
            if (dgvClientsPrimaryGeneral.Columns[columnName] != null)
            {
                int columnIndex = dgvClientsPrimaryGeneral.Columns[columnName].Index;
                dgvClientsPrimaryGeneral.Columns.RemoveAt(columnIndex);

                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                {
                    Name = columnName,
                    HeaderText = headerText,
                    DataPropertyName = columnName,
                    TrueValue = 1,
                    FalseValue = 0
                };

                dgvClientsPrimaryGeneral.Columns.Insert(columnIndex, checkBoxColumn);
            }
        }

        private void LoadClientAppointments()
        {
            handler.UpdateAppointmentStatuses();

            DataTable appointmentDataTable = handler.GetClientAppointments(clientId);
            appointmentBindingSource.DataSource = appointmentDataTable;
            dgvClientsPrimaryAppointments.DataSource = appointmentBindingSource;
            SetupAppointmentsDataGridView();
        }

        private void SetupAppointmentsDataGridView()
        {
            dgvClientsPrimaryAppointments.AllowUserToAddRows = true;
            dgvClientsPrimaryAppointments.AllowUserToDeleteRows = true;
            dgvClientsPrimaryAppointments.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvClientsPrimaryAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvClientsPrimaryAppointments.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvClientsPrimaryAppointments.RowTemplate.Height = 60;
            dgvClientsPrimaryAppointments.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            string[] columnsToHide = { "AppointmentID", "ClientID", "CreatedAt" };
            foreach (string columnName in columnsToHide)
            {
                if (dgvClientsPrimaryAppointments.Columns[columnName] != null)
                {
                    dgvClientsPrimaryAppointments.Columns[columnName].Visible = false;
                }
            }

            DataTable staff = handler.FetchStaff();

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

            if (dgvClientsPrimaryAppointments.Columns["AppointmentType"] != null)
            {
                DataGridViewComboBoxColumn appointmentTypeComboBoxColumn = new DataGridViewComboBoxColumn
                {
                    Name = "AppointmentType",
                    HeaderText = "Appointment Type",
                    DataSource = new string[] { "Follow-up", "Skin Analysis", "Treatments" },
                    DataPropertyName = "AppointmentType"
                };

                int appointmentTypeIndex = dgvClientsPrimaryAppointments.Columns["AppointmentType"].Index;
                dgvClientsPrimaryAppointments.Columns.RemoveAt(appointmentTypeIndex);
                dgvClientsPrimaryAppointments.Columns.Insert(appointmentTypeIndex, appointmentTypeComboBoxColumn);
            }

            if (dgvClientsPrimaryAppointments.Columns["Status"] != null)
            {
                DataGridViewComboBoxColumn statusComboBoxColumn = new DataGridViewComboBoxColumn
                {
                    Name = "Status",
                    HeaderText = "Status",
                    DataSource = new string[] { "Scheduled", "Completed" },
                    DataPropertyName = "Status"
                };

                int statusIndex = dgvClientsPrimaryAppointments.Columns["Status"].Index;
                dgvClientsPrimaryAppointments.Columns.RemoveAt(statusIndex);
                dgvClientsPrimaryAppointments.Columns.Insert(statusIndex, statusComboBoxColumn);
            }

            if (dgvClientsPrimaryAppointments.Columns["StaffID"] != null)
            {
                int staffIndex = dgvClientsPrimaryAppointments.Columns["StaffID"].Index;
                dgvClientsPrimaryAppointments.Columns.RemoveAt(staffIndex);
                dgvClientsPrimaryAppointments.Columns.Insert(staffIndex, staffComboBoxColumn);
            }

            if (dgvClientsPrimaryAppointments.Columns["AppointmentDate"] != null)
            {
                int appointmentDateIndex = dgvClientsPrimaryAppointments.Columns["AppointmentDate"].Index;
                dgvClientsPrimaryAppointments.Columns.RemoveAt(appointmentDateIndex);
                dgvClientsPrimaryAppointments.Columns.Insert(appointmentDateIndex, dateColumn);
            }

            if (dgvClientsPrimaryAppointments.Columns["ReminderSent"] != null)
            {
                int reminderSentIndex = dgvClientsPrimaryAppointments.Columns["ReminderSent"].Index;
                dgvClientsPrimaryAppointments.Columns.RemoveAt(reminderSentIndex);
            }
            dgvClientsPrimaryAppointments.Columns.Add(reminderSentCheckBox);
        }


        private void LoadClientOrders()
        {
            DataTable orderDataTable = handler.GetClientOrders(clientId);
            orderBindingSource.DataSource = orderDataTable;
            dgvClientsPrimaryOrders.DataSource = orderBindingSource;
            SetupOrdersDataGridView();
        }

        private void SetupOrdersDataGridView()
        {
            dgvClientsPrimaryOrders.AllowUserToAddRows = true;
            dgvClientsPrimaryOrders.AllowUserToDeleteRows = true;
            dgvClientsPrimaryOrders.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvClientsPrimaryOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvClientsPrimaryOrders.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvClientsPrimaryOrders.RowTemplate.Height = 60;
            dgvClientsPrimaryOrders.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            string[] columnsToHide = { "OrderID", "ClientID", "CreatedAt" };
            foreach (string columnName in columnsToHide)
            {
                if (dgvClientsPrimaryOrders.Columns[columnName] != null)
                {
                    dgvClientsPrimaryOrders.Columns[columnName].Visible = false;
                }
            }

            DataTable product = handler.FetchProduct();

            DataGridViewComboBoxColumn producComboBoxColumn = new DataGridViewComboBoxColumn();
            producComboBoxColumn.Name = "ProductID";
            producComboBoxColumn.HeaderText = "Product";
            producComboBoxColumn.DataSource = product;
            producComboBoxColumn.DisplayMember = "ProductName";
            producComboBoxColumn.ValueMember = "ProductID";
            producComboBoxColumn.DataPropertyName = "ProductID";


            if (dgvClientsPrimaryOrders.Columns["ProductID"] != null)
            {
                int productIndex = dgvClientsPrimaryOrders.Columns["ProductID"].Index;
                dgvClientsPrimaryOrders.Columns.RemoveAt(productIndex);
                dgvClientsPrimaryOrders.Columns.Insert(productIndex, producComboBoxColumn);
            }

            DataGridViewDateTimePickerColumn dateColumn = new DataGridViewDateTimePickerColumn(includeTime: false);
            dateColumn.Name = "OrderDate";
            dateColumn.HeaderText = "OrderDate";
            dateColumn.DataPropertyName = "OrderDate";

            if (dgvClientsPrimaryOrders.Columns["OrderDate"] != null)
            {
                int orderDateIndex = dgvClientsPrimaryOrders.Columns["OrderDate"].Index;
                dgvClientsPrimaryOrders.Columns.RemoveAt(orderDateIndex);
                dgvClientsPrimaryOrders.Columns.Insert(orderDateIndex, dateColumn);
            }

            if (dgvClientsPrimaryOrders.Columns["Status"] != null)
            {
                DataGridViewComboBoxColumn statusComboBoxColumn = new DataGridViewComboBoxColumn();
                statusComboBoxColumn.Name = "Status";
                statusComboBoxColumn.HeaderText = "Status";
                statusComboBoxColumn.DataSource = new string[] { "Pending", "Completed" };
                statusComboBoxColumn.DataPropertyName = "Status";

                int statusIndex = dgvClientsPrimaryOrders.Columns["Status"].Index;
                dgvClientsPrimaryOrders.Columns.RemoveAt(statusIndex);
                dgvClientsPrimaryOrders.Columns.Insert(statusIndex, statusComboBoxColumn);
            }
        }

        private void LoadClientProductUsage()
        {
            DataTable productUsageDataTable = handler.GetProductUsage(clientId);
            productUsageBindingSource.DataSource = productUsageDataTable;
            dgvClientsSecondaryProductUsage.DataSource = productUsageBindingSource;
            SetupProductUsageDataGridView();
        }

        private void SetupProductUsageDataGridView()
        {
            dgvClientsSecondaryProductUsage.AllowUserToAddRows = true;
            dgvClientsSecondaryProductUsage.AllowUserToDeleteRows = true;
            dgvClientsSecondaryProductUsage.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvClientsSecondaryProductUsage.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvClientsSecondaryProductUsage.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvClientsSecondaryProductUsage.RowTemplate.Height = 60;
            dgvClientsSecondaryProductUsage.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            string[] columnsToHide = { "ProductUsageID", "ClientID", "CreatedAt" };
            foreach (string columnName in columnsToHide)
            {
                if (dgvClientsSecondaryProductUsage.Columns[columnName] != null)
                {
                    dgvClientsSecondaryProductUsage.Columns[columnName].Visible = false;
                }
            }

            DataTable productUsage = handler.FetchProductUsage();

            DataGridViewComboBoxColumn productUsageComboBoxColumn = new DataGridViewComboBoxColumn();
            productUsageComboBoxColumn.Name = "ProductID";
            productUsageComboBoxColumn.HeaderText = "Product";
            productUsageComboBoxColumn.DataSource = productUsage;
            productUsageComboBoxColumn.DisplayMember = "ProductName";
            productUsageComboBoxColumn.ValueMember = "ProductID";
            productUsageComboBoxColumn.DataPropertyName = "ProductID";

            DataGridViewDateTimePickerColumn purchaseDateColumn = new DataGridViewDateTimePickerColumn(includeTime: false);
            purchaseDateColumn.Name = "PurchaseDate";
            purchaseDateColumn.HeaderText = "PurchaseDate";
            purchaseDateColumn.DataPropertyName = "PurchaseDate";

            DataGridViewDateTimePickerColumn estimatedFinishDateColumn = new DataGridViewDateTimePickerColumn(includeTime: false);
            estimatedFinishDateColumn.Name = "EstimatedFinishDate";
            estimatedFinishDateColumn.HeaderText = "EstimatedFinishDate";
            estimatedFinishDateColumn.DataPropertyName = "EstimatedFinishDate";

            if (dgvClientsSecondaryProductUsage.Columns["ProductID"] != null)
            {
                int productUsageIndex = dgvClientsSecondaryProductUsage.Columns["ProductID"].Index;
                dgvClientsSecondaryProductUsage.Columns.RemoveAt(productUsageIndex);
                dgvClientsSecondaryProductUsage.Columns.Insert(productUsageIndex, productUsageComboBoxColumn);
            }

            if (dgvClientsSecondaryProductUsage.Columns["PurchaseDate"] != null)
            {
                int purchaseDateIndex = dgvClientsSecondaryProductUsage.Columns["PurchaseDate"].Index;
                dgvClientsSecondaryProductUsage.Columns.RemoveAt(purchaseDateIndex);
                dgvClientsSecondaryProductUsage.Columns.Insert(purchaseDateIndex, purchaseDateColumn);
            }

            if (dgvClientsSecondaryProductUsage.Columns["EstimatedFinishDate"] != null)
            {
                int estimatedFinisheDateIndex = dgvClientsSecondaryProductUsage.Columns["EstimatedFinishDate"].Index;
                dgvClientsSecondaryProductUsage.Columns.RemoveAt(estimatedFinisheDateIndex);
                dgvClientsSecondaryProductUsage.Columns.Insert(estimatedFinisheDateIndex, estimatedFinishDateColumn);
            }
        }

        private void btnClientsDetailSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable generalChanges = ((DataTable)dgvClientsPrimaryGeneral.DataSource).GetChanges();
                DataTable appointmentChanges = ((DataTable)appointmentBindingSource.DataSource).GetChanges();
                DataTable orderChanges = ((DataTable)orderBindingSource.DataSource).GetChanges();
                DataTable productUsageChanges = ((DataTable)productUsageBindingSource.DataSource).GetChanges();



                if (generalChanges != null)
                {
                    handler.UpdateClient(generalChanges);
                    MessageBox.Show("Client general information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshClientsView();
                }

                if (appointmentChanges != null)
                {
                    foreach (DataRow row in appointmentChanges.Rows)
                    {
                        if (row.RowState != DataRowState.Deleted)
                        {
                            if (row["StaffID"] == DBNull.Value || row["AppointmentDate"] == DBNull.Value)
                            {
                                MessageBox.Show("Please ensure all appointments have a Staff member and an Appointment Date filled in before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            if (row["IsNewClient"] == DBNull.Value)
                            {
                                row["IsNewClient"] = 0;
                            }
                        }
                    }
                    handler.UpdateAppointments(appointmentChanges, clientId);
                    MessageBox.Show("Client appointments updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadClientAppointments();
                }

                if (orderChanges != null)
                {
                    foreach (DataRow row in orderChanges.Rows)
                    {
                        if (row.RowState != DataRowState.Deleted)
                        {
                            if (row["OrderDate"] == DBNull.Value)
                            {
                                MessageBox.Show("Please ensure orders have an Order Date filled in before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                    handler.UpdateOrders(orderChanges, clientId);
                    MessageBox.Show("Client orders updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadClientOrders();
                }

                if (productUsageChanges != null)
                {
                    foreach (DataRow row in productUsageChanges.Rows)
                    {
                        if (row.RowState != DataRowState.Deleted)
                        {
                            if (row["PurchaseDate"] == DBNull.Value || row["EstimatedFinishDate"] == DBNull.Value)
                            {
                                MessageBox.Show("Please ensure product usage has a Purchase Date and Estimated Finish Date filled in before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                    handler.UpdateProductUsage(productUsageChanges, clientId);
                    MessageBox.Show("Client product usage updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadClientProductUsage();
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

        private void btnClientsDetailBack_Click(object sender, EventArgs e)
        {
            parentForm.RefreshAndShow();
            this.Hide();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                parentForm.RefreshAndShow();
            }
        }

        private void ClientsPrimary_Load(object sender, EventArgs e)
        {
            lblClientsPrimaryClientName.Text = "Client: " + handler.GetClientName(clientId);
            handler.UpdateAppointmentStatuses();
            LoadClientAppointments();
            LoadClientOrders();
            LoadClientProductUsage();
        }

        private void dgvClientsPrimaryAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deleteRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteRecord(dgvClientsPrimaryAppointments, appointmentBindingSource, "AppointmentID", handler.DeleteAppointment);
        }

        private void deleteRecordToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DeleteRecord(dgvClientsPrimaryOrders, orderBindingSource, "OrderID", handler.DeleteOrder);
        }

        private void dgvClientsPrimaryAppointments_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView_CellMouseClick(sender, e, contextMenuStrip1);
        }

        private void dgvClientsPrimaryOrders_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView_CellMouseClick(sender, e, contextMenuStrip2);
        }

        private void dgvClientsSecondaryProductUsage_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView_CellMouseClick(sender, e, contextMenuStrip5);
        }

        private void DataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e, ContextMenuStrip contextMenu)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex != -1)
            {
                DataGridView dgv = (DataGridView)sender;
                dgv.ClearSelection();
                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

                Rectangle cellRect = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                System.Drawing.Point cellLocation = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;
                contextMenu.Show(dgv, cellLocation);
            }
        }

        private void DeleteRecord(DataGridView dgv, BindingSource bindingSource, string idColumnName, Action<int> deleteAction)
        {
            if (dgv.CurrentCell != null)
            {
                DataGridViewRow clickedRow = dgv.Rows[dgv.CurrentCell.RowIndex];

                if (clickedRow.Cells[idColumnName].Value == DBNull.Value || clickedRow.Cells[idColumnName].Value == null)
                {
                    dgv.Rows.Remove(clickedRow);
                    MessageBox.Show("New record removed.", "Remove Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int recordId = Convert.ToInt32(clickedRow.Cells[idColumnName].Value);

                var confirmResult = MessageBox.Show("Are you sure you want to delete this record?",
                                                    "Confirm Delete",
                                                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        bindingSource.RemoveAt(clickedRow.Index);
                        deleteAction(recordId);

                        bindingSource.ResetBindings(false);

                        MessageBox.Show("Record deleted successfully.", "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting record: {ex.Message}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DeleteRecord(dgvClientsSecondaryProductUsage, productUsageBindingSource, "ProductUsageID", handler.DeleteProductUsage);
        }

        private void dgvClientsSecondaryProductUsage_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void btnClientMedicalHistory_Click(object sender, EventArgs e)
        {
            AppointmentClientHistory appointmentClientHistory = new AppointmentClientHistory(handler.GetAppointmentID(clientId), clientId, new AppointmentsView());
            appointmentClientHistory.Show();
            this.Hide();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvClientsPrimaryGeneral.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvClientsPrimaryGeneral.SelectedRows[0];
                int columnIndex = selectedRow.Cells["ClientID"].ColumnIndex;
                int clientId = (int)selectedRow.Cells[columnIndex].Value;

                var confirmResult = MessageBox.Show("Are you sure you want to delete this client? This will also delete all related records.",
                                                    "Confirm Delete",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        clientHandler.DeleteClient(clientId);
                        MessageBox.Show("Client and related records deleted successfully.", "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RefreshClientsView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting client: {ex.Message}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileName in openFileDialog.FileNames)
                    {
                        try
                        {
                            string cloudinaryUrl = await handler.UploadImageToCloudinary(fileName, clientId);
                            handler.SaveImageUrlToDatabase(cloudinaryUrl, clientId);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error uploading {fileName}: {ex.Message}", "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    handler.LoadImagesForClient(clientId);
                    UpdateImageDisplay();
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (handler.currentImageIndex < handler.imageUrls.Count - 1)
            {
                handler.currentImageIndex++;
                UpdateImageDisplay();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (handler.currentImageIndex >= 0 && handler.currentImageIndex < handler.imageUrls.Count)
            {
                string urlToDelete = handler.imageUrls[handler.currentImageIndex];
                await handler.DeleteImageFromCloudinary(urlToDelete);
                handler.DeleteImageFromDatabase(urlToDelete, clientId);
                handler.LoadImagesForClient(clientId);
                UpdateImageDisplay();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (handler.currentImageIndex > 0)
            {
                handler.currentImageIndex--;
                UpdateImageDisplay();
            }
        }

        private async void UpdateImageDisplay()
        {
            if (handler.currentImageIndex >= 0 && handler.currentImageIndex < handler.imageUrls.Count)
            {
                pictureBox.Image?.Dispose();
                pictureBox.Image = await handler.DownloadImageFromCloudinary(handler.imageUrls[handler.currentImageIndex]);
                lblImageCount.Text = $"Image {handler.currentImageIndex + 1} of {handler.imageUrls.Count}";
            }
            else
            {
                pictureBox.Image = null;
                lblImageCount.Text = "No images";
            }
            btnPrevious.Enabled = handler.currentImageIndex > 0;
            btnNext.Enabled = handler.currentImageIndex < handler.imageUrls.Count - 1;
            btnDelete.Enabled = handler.imageUrls.Count > 0;
        }
    }
}
