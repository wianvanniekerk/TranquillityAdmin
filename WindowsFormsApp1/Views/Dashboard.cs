using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Communication.Email;
using WindowsFormsApp1.Views.Appointments;
using WindowsFormsApp1.Views.Clients;
using WindowsFormsApp1.Views.Clients.View;
using WindowsFormsApp1.Views.Orders;
using WindowsFormsApp1.Views.Products;
using WindowsFormsApp1.Views.Staff;

namespace WindowsFormsApp1.Views
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnDashboardClients_Click(object sender, EventArgs e)
        {
            ClientsView clientsView = new ClientsView();
            clientsView.Show();
            this.Hide();
        }

        private void btnDashboardAppointments_Click(object sender, EventArgs e)
        {
            AppointmentsView appointmentsView = new AppointmentsView();
            appointmentsView.Show();
            this.Hide();
        }

        private void btnDashboardOrders_Click(object sender, EventArgs e)
        {
            OrdersView ordersView = new OrdersView();
            ordersView.Show();
            this.Hide();
        }

        private void btnDashboardStaff_Click(object sender, EventArgs e)
        {
            StaffView staffView = new StaffView();
            staffView.Show();
            this.Hide();
        }

        private void btnDashboardProducts_Click(object sender, EventArgs e)
        {
            ProductsView productsView = new ProductsView();
            productsView.Show();
            this.Hide();
        }

        private void btnDashboardCommunication_Click(object sender, EventArgs e)
        {
            CommunicationEmail communicationEmail = new CommunicationEmail();
            communicationEmail.Show();
            this.Hide();
        }

        private void btnDashboardNotifications_Click(object sender, EventArgs e)
        {
            Notifications notifications = new Notifications();
            notifications.Show();
            this.Hide();
        }

        private void btnDashboardSearchClients_Click(object sender, EventArgs e)
        {

        }
    }
}
