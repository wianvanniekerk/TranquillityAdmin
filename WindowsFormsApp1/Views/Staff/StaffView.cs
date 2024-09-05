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
using WindowsFormsApp1.Data.Orders;
using WindowsFormsApp1.Data.Staff;
using WindowsFormsApp1.Views.Clients;

namespace WindowsFormsApp1.Views.Staff
{
    public partial class StaffView : Form
    {
        DataHandlerStaff handler = new DataHandlerStaff();
        private DataTable staffDataTable;

        public StaffView()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void RefreshStaffView()
        {
            staffDataTable = handler.FetchStaff();
            dgvStaffView.DataSource = staffDataTable;
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dgvStaffView.AllowUserToAddRows = true;
            dgvStaffView.AllowUserToDeleteRows = false;
            dgvStaffView.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvStaffView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvStaffView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvStaffView.RowTemplate.Height = 60;
            dgvStaffView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            string[] columnsToHide = { "StaffID", "CreatedAt" };
            foreach (string columnName in columnsToHide)
            {
                if (dgvStaffView.Columns[columnName] != null)
                {
                    dgvStaffView.Columns[columnName].Visible = false;
                }
            }

            if (dgvStaffView.Columns["IsActive"] != null)
            {
                dgvStaffView.Columns.Remove("IsActive");
            }

            DataGridViewCheckBoxColumn chkIsActive = new DataGridViewCheckBoxColumn
            {
                Name = "IsActive",
                HeaderText = "Active",
                DataPropertyName = "IsActive",
                TrueValue = true,
                FalseValue = false
            };
            dgvStaffView.Columns.Add(chkIsActive);

            foreach (DataGridViewColumn column in dgvStaffView.Columns)
            {
                if (column.ValueType == typeof(DateTime))
                {
                    column.DefaultCellStyle.Format = "yyyy-MM-dd";
                }
            }
        }

        private void dgvStaffView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnStaffViewSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable changes = ((DataTable)dgvStaffView.DataSource).GetChanges();
                if (changes != null)
                {
                    handler.UpdateStaff(changes);
                    MessageBox.Show("Changes saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshStaffView();
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

        private void btnStaffViewBack_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void dgvStaffView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void StaffView_Load(object sender, EventArgs e)
        {
            RefreshStaffView();
        }
    }
}
