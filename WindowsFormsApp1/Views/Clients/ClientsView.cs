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
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Data.Clients;
using WindowsFormsApp1.FormFuntionality;
using WindowsFormsApp1.Views.Appointments;

namespace WindowsFormsApp1.Views.Clients.View
{
    public partial class ClientsView : Form
    {
        DataHandlerClients handler = new DataHandlerClients();
        private DataTable clientsDataTable;
        private bool isClosing = false;

        public ClientsView()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            dgvClientsView.CellContentClick += dgvClientsView_CellContentClick;
            this.FormClosing += ClientsView_FormClosing;
        }

        private void ClientsView_Load(object sender, EventArgs e)
        {
            RefreshClientsView();
        }


        private void RefreshClientsView()
        {
            clientsDataTable = handler.FetchClients();
            dgvClientsView.DataSource = null;
            dgvClientsView.Columns.Clear();
            dgvClientsView.DataSource = clientsDataTable;
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dgvClientsView.AllowUserToAddRows = true;
            dgvClientsView.AllowUserToDeleteRows = false;
            dgvClientsView.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvClientsView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientsView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvClientsView.RowTemplate.Height = 60;
            dgvClientsView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgvClientsView.CellBeginEdit += dgvClientsView_CellBeginEdit;
            dgvClientsView.RowValidating += dgvClientsView_RowValidating;

            string[] columnsToHide = { "ClientID", "RegistrationDate", "CreatedAt", "Password" };
            foreach (string columnName in columnsToHide)
            {
                if (dgvClientsView.Columns[columnName] != null)
                {
                    dgvClientsView.Columns[columnName].Visible = false;
                }
            }

            if (dgvClientsView.Columns["DetailsButton"] == null)
            {
                DataGridViewButtonColumn detailsButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "DetailsButton",
                    HeaderText = "Client Details",
                    Text = "View More Details",
                    UseColumnTextForButtonValue = true,
                };
                detailsButtonColumn.DefaultCellStyle.BackColor = Color.Blue;
                dgvClientsView.Columns.Add(detailsButtonColumn);
            }

            if (dgvClientsView.Columns["Email"] != null)
            {
                dgvClientsView.Columns["Email"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvClientsView.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            if (dgvClientsView.Columns["IDNumber"] != null)
            {
                dgvClientsView.Columns["IDNumber"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvClientsView.Columns["IDNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            DataGridViewDateTimePickerColumn dateColumn = new DataGridViewDateTimePickerColumn(includeTime: false);
            dateColumn.Name = "DateOfBirth";
            dateColumn.HeaderText = "DateOfBirth";
            dateColumn.DataPropertyName = "DateOfBirth";

            if (dgvClientsView.Columns["DateOfBirth"] != null)
            {
                int dateOfBirthDateIndex = dgvClientsView.Columns["DateOfBirth"].Index;
                dgvClientsView.Columns.RemoveAt(dateOfBirthDateIndex);
                dgvClientsView.Columns.Insert(dateOfBirthDateIndex, dateColumn);
            }

            AddCheckBoxColumn("IsActive", "Is Active");
            AddCheckBoxColumn("MarketingConsent", "Marketing Consent");
        }

        private void OpenClientDetails(int clientId)
        {
            ClientsPrimary clientDetailsForm = new ClientsPrimary(clientId, this);
            this.Hide();
            clientDetailsForm.Show();
        }

        public void RefreshAndShow()
        {
            RefreshClientsView();
            try
            {
                this.Show();
            } catch (Exception)
            {

            }

        }

        private void AddCheckBoxColumn(string columnName, string headerText)
        {
            if (dgvClientsView.Columns[columnName] != null)
            {
                int columnIndex = dgvClientsView.Columns[columnName].Index;
                dgvClientsView.Columns.RemoveAt(columnIndex);

                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                {
                    Name = columnName,
                    HeaderText = headerText,
                    DataPropertyName = columnName,
                    TrueValue = 1,
                    FalseValue = 0
                };

                dgvClientsView.Columns.Insert(columnIndex, checkBoxColumn);
            }
        }

        private void btnCLientsViewBack_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void btnClientsViewSave_Click(object sender, EventArgs e)
        {
            try
            {
                dgvClientsView.EndEdit();

                DataTable changes = ((DataTable)dgvClientsView.DataSource).GetChanges();
                if (changes != null)
                {
                    handler.UpdateClient(changes);
                    MessageBox.Show("Changes saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshClientsView();
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

        private void deleteRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvClientsView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvClientsView.SelectedRows[0];
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
                        handler.DeleteClient(clientId);
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

        private void dgvClientsView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvClientsView.Columns["DetailsButton"].Index)
            {
                object cellValue = dgvClientsView.Rows[e.RowIndex].Cells["ClientID"].Value;
                if (cellValue != null && cellValue != DBNull.Value)
                {
                    int clientId = Convert.ToInt32(cellValue);
                    OpenClientDetails(clientId);
                }
            }
        }

        private void dgvClientsView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex == dgvClientsView.NewRowIndex)
            {
                var unsavedRows = dgvClientsView.Rows.Cast<DataGridViewRow>()
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

        private void dgvClientsView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (isClosing) return;

            if (e.RowIndex == dgvClientsView.NewRowIndex - 1)
            {
                DataGridViewRow row = dgvClientsView.Rows[e.RowIndex];

                if (row.Cells["RegistrationDate"].Value == null)
                {
                    row.Cells["RegistrationDate"].Value = DateTime.Now;
                }

                if (string.IsNullOrWhiteSpace(row.Cells["FirstName"].Value?.ToString()) ||
                    string.IsNullOrWhiteSpace(row.Cells["LastName"].Value?.ToString()) ||
                    string.IsNullOrWhiteSpace(row.Cells["Email"].Value?.ToString()))
                {
                    e.Cancel = true;
                    MessageBox.Show("First Name, Last Name and Email are required fields.",
                                    "Validation Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void ClientsView_FormClosing(object sender, FormClosingEventArgs e)
        {
            isClosing = true;
        }
    }
}
