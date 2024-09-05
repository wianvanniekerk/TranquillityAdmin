using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WindowsFormsApp1.Data.Clients;
using WindowsFormsApp1.Views;
using WindowsFormsApp1.Data.Appointments;

namespace WindowsFormsApp1.Communication.Email
{
    public partial class Notifications : Form
    {
        DataHandlerClients handlerClients = new DataHandlerClients();
        DataHandlerClientsPrimary handlerClientsPrimary = new DataHandlerClientsPrimary();
        DataHandlerAppointmentClientHistory handlerAppointmentClientHistory = new DataHandlerAppointmentClientHistory();
        private const string toDoListFilePath = "ToDoList.txt";
        private const string notificationsFilePath = "NotificationsCheckedStates.txt";


        public Notifications()
        {
            InitializeComponent();
            LoadToDoList();
            LoadNotificationsCheckedStates();
            this.WindowState = FormWindowState.Maximized;

            chkListNotifications.ItemCheck += ChkListNotifications_ItemCheck;
        }

        private void ChkListNotifications_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            BeginInvoke(new Action(() => SaveNotificationsCheckedStates()));
        }

        private void btnAddToList_Click(object sender, EventArgs e)
        {
            string newItem = txtAddToList.Text.Trim();

            if (!string.IsNullOrEmpty(newItem))
            {
                chkListToDo.Items.Add(newItem);
                txtAddToList.Clear();
                SaveToDoList();
            }
            else
            {
                MessageBox.Show("Please enter a valid item.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private List<string> ProcessEstimatedFinishDate()
        {
            return handlerClientsPrimary.GetEstimatedFinishDates();
        }

        private List<string> ProcessBirthday()
        {
            return handlerClients.GetBirthday();
        }

        private List<string> ProcessAppointmentClientHistorySubmission()
        {
            return handlerAppointmentClientHistory.GetAppointmentClientHistorySubmission();
        }

        private void btnNotificationsBack_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void deleteRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (chkListToDo.SelectedIndex >= 0)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete this item?",
                                                    "Confirm Delete",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        chkListToDo.Items.RemoveAt(chkListToDo.SelectedIndex);
                        SaveToDoList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting item: {ex.Message}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an item to delete.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (chkListNotifications.SelectedIndex >= 0)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete this item?",
                                                    "Confirm Delete",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        chkListNotifications.Items.RemoveAt(chkListNotifications.SelectedIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting item: {ex.Message}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an item to delete.", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveToDoList()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(toDoListFilePath))
                {
                    foreach (var item in chkListToDo.Items)
                    {
                        writer.WriteLine(item.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving To-Do list: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadToDoList()
        {
            try
            {
                if (File.Exists(toDoListFilePath))
                {
                    using (StreamReader reader = new StreamReader(toDoListFilePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            chkListToDo.Items.Add(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading To-Do list: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveNotificationsCheckedStates()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(notificationsFilePath))
                {
                    for (int i = 0; i < chkListNotifications.Items.Count; i++)
                    {
                        writer.WriteLine($"{chkListNotifications.Items[i]}|{chkListNotifications.GetItemChecked(i)}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving notifications: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNotificationsCheckedStates()
        {
            try
            {
                Dictionary<string, bool> savedNotifications = new Dictionary<string, bool>();
                if (File.Exists(notificationsFilePath))
                {
                    using (StreamReader reader = new StreamReader(notificationsFilePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split('|');
                            if (parts.Length == 2)
                            {
                                savedNotifications[parts[0]] = bool.Parse(parts[1]);
                            }
                        }
                    }
                }

                List<string> newNotifications = new List<string>();
                newNotifications.AddRange(ProcessBirthday());
                newNotifications.AddRange(ProcessEstimatedFinishDate());
                newNotifications.AddRange(ProcessAppointmentClientHistorySubmission());

                foreach (var notification in savedNotifications)
                {
                    chkListNotifications.Items.Add(notification.Key, notification.Value);
                }

                foreach (var notification in newNotifications)
                {
                    if (!string.IsNullOrEmpty(notification) && !savedNotifications.ContainsKey(notification))
                    {
                        chkListNotifications.Items.Add(notification, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading notifications: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Notifications_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveNotificationsCheckedStates();
        }
    }
}
