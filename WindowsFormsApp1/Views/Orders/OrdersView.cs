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
using WindowsFormsApp1.FormFuntionality;
using WindowsFormsApp1.Views.Clients;

namespace WindowsFormsApp1.Views.Orders
{
    public partial class OrdersView : Form
    {
        DataHandlerOrders handler = new DataHandlerOrders();
        private DataTable ordersDataTable;

        public OrdersView()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnOrdersViewSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable changes = ((DataTable)dgvOrdersView.DataSource).GetChanges();
                if (changes != null)
                {
                    handler.UpdateOrders(changes);
                    MessageBox.Show("Changes saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshOrdersView();
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

        private void OrdersView_Load(object sender, EventArgs e)
        {
            RefreshOrdersView();
        }

        private void RefreshOrdersView()
        {
            ordersDataTable = handler.FetchOrders();
            dgvOrdersView.DataSource = ordersDataTable;
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dgvOrdersView.AllowUserToAddRows = true;
            dgvOrdersView.AllowUserToDeleteRows = false;
            dgvOrdersView.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvOrdersView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvOrdersView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvOrdersView.RowTemplate.Height = 60;
            dgvOrdersView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            string[] columnsToHide = { "OrderID", "CreatedAt" };
            foreach (string columnName in columnsToHide)
            {
                if (dgvOrdersView.Columns[columnName] != null)
                {
                    dgvOrdersView.Columns[columnName].Visible = false;
                }
            }

            DataTable clients = handler.FetchClients();

            DataGridViewComboBoxColumn clientComboBoxColumn = new DataGridViewComboBoxColumn();
            clientComboBoxColumn.Name = "ClientID";
            clientComboBoxColumn.HeaderText = "Client";
            clientComboBoxColumn.DataSource = clients;
            clientComboBoxColumn.DisplayMember = "ClientName";
            clientComboBoxColumn.ValueMember = "ClientID";
            clientComboBoxColumn.DataPropertyName = "ClientID";

            DataGridViewDateTimePickerColumn dateColumn = new DataGridViewDateTimePickerColumn(includeTime: false);
            dateColumn.Name = "OrderDate";
            dateColumn.HeaderText = "OrderDate";
            dateColumn.DataPropertyName = "OrderDate";

            DataTable product = handler.FetchProduct();

            DataGridViewComboBoxColumn producComboBoxColumn = new DataGridViewComboBoxColumn();
            producComboBoxColumn.Name = "ProductID";
            producComboBoxColumn.HeaderText = "Product";
            producComboBoxColumn.DataSource = product;
            producComboBoxColumn.DisplayMember = "ProductName";
            producComboBoxColumn.ValueMember = "ProductID";
            producComboBoxColumn.DataPropertyName = "ProductID";

            if (dgvOrdersView.Columns["ClientID"] != null)
            {
                int clientIndex = dgvOrdersView.Columns["ClientID"].Index;
                dgvOrdersView.Columns.RemoveAt(clientIndex);
                dgvOrdersView.Columns.Insert(clientIndex, clientComboBoxColumn);
            }

            if (dgvOrdersView.Columns["OrderDate"] != null)
            {
                int orderDateIndex = dgvOrdersView.Columns["OrderDate"].Index;
                dgvOrdersView.Columns.RemoveAt(orderDateIndex);
                dgvOrdersView.Columns.Insert(orderDateIndex, dateColumn);
            }

            if (dgvOrdersView.Columns["Status"] != null)
            {
                DataGridViewComboBoxColumn statusComboBoxColumn = new DataGridViewComboBoxColumn();
                statusComboBoxColumn.Name = "Status";
                statusComboBoxColumn.HeaderText = "Status";
                statusComboBoxColumn.DataSource = new string[] { "Pending", "Completed" };
                statusComboBoxColumn.DataPropertyName = "Status";

                int statusIndex = dgvOrdersView.Columns["Status"].Index;
                dgvOrdersView.Columns.RemoveAt(statusIndex);
                dgvOrdersView.Columns.Insert(statusIndex, statusComboBoxColumn);
            }

            if (dgvOrdersView.Columns["ProductID"] != null)
            {
                int productIndex = dgvOrdersView.Columns["ProductID"].Index;
                dgvOrdersView.Columns.RemoveAt(productIndex);
                dgvOrdersView.Columns.Insert(productIndex, producComboBoxColumn);
            }
        }

        private void btnOrdersViewBack_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void dgvOrdersView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvOrdersView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
