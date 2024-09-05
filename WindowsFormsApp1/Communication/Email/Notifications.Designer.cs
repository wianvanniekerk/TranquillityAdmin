namespace WindowsFormsApp1.Communication.Email
{
    partial class Notifications
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.chkListNotifications = new System.Windows.Forms.CheckedListBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.txtAddToList = new System.Windows.Forms.TextBox();
            this.chkListToDo = new System.Windows.Forms.CheckedListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblClientsPrimaryClientName = new System.Windows.Forms.Label();
            this.lblCLientsPrimaryHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNotificationsBack = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkListNotifications
            // 
            this.chkListNotifications.ContextMenuStrip = this.contextMenuStrip2;
            this.chkListNotifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkListNotifications.FormattingEnabled = true;
            this.chkListNotifications.Location = new System.Drawing.Point(794, 168);
            this.chkListNotifications.Margin = new System.Windows.Forms.Padding(2);
            this.chkListNotifications.Name = "chkListNotifications";
            this.chkListNotifications.Size = new System.Drawing.Size(697, 466);
            this.chkListNotifications.TabIndex = 1;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(174, 28);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(173, 24);
            this.toolStripMenuItem1.Text = "Delete Record";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // btnAddToList
            // 
            this.btnAddToList.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.btnAddToList.Location = new System.Drawing.Point(497, 131);
            this.btnAddToList.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(160, 37);
            this.btnAddToList.TabIndex = 2;
            this.btnAddToList.Text = "Add to List";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // txtAddToList
            // 
            this.txtAddToList.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.txtAddToList.Location = new System.Drawing.Point(129, 132);
            this.txtAddToList.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddToList.Name = "txtAddToList";
            this.txtAddToList.Size = new System.Drawing.Size(364, 39);
            this.txtAddToList.TabIndex = 3;
            // 
            // chkListToDo
            // 
            this.chkListToDo.ContextMenuStrip = this.contextMenuStrip1;
            this.chkListToDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chkListToDo.FormattingEnabled = true;
            this.chkListToDo.Location = new System.Drawing.Point(129, 168);
            this.chkListToDo.Margin = new System.Windows.Forms.Padding(2);
            this.chkListToDo.Name = "chkListToDo";
            this.chkListToDo.Size = new System.Drawing.Size(528, 466);
            this.chkListToDo.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteRecordToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(174, 28);
            // 
            // deleteRecordToolStripMenuItem
            // 
            this.deleteRecordToolStripMenuItem.Name = "deleteRecordToolStripMenuItem";
            this.deleteRecordToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.deleteRecordToolStripMenuItem.Text = "Delete Record";
            this.deleteRecordToolStripMenuItem.Click += new System.EventHandler(this.deleteRecordToolStripMenuItem_Click);
            // 
            // lblClientsPrimaryClientName
            // 
            this.lblClientsPrimaryClientName.AutoSize = true;
            this.lblClientsPrimaryClientName.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.lblClientsPrimaryClientName.Location = new System.Drawing.Point(124, 98);
            this.lblClientsPrimaryClientName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClientsPrimaryClientName.Name = "lblClientsPrimaryClientName";
            this.lblClientsPrimaryClientName.Size = new System.Drawing.Size(121, 32);
            this.lblClientsPrimaryClientName.TabIndex = 16;
            this.lblClientsPrimaryClientName.Text = "To Do List";
            // 
            // lblCLientsPrimaryHeader
            // 
            this.lblCLientsPrimaryHeader.AutoSize = true;
            this.lblCLientsPrimaryHeader.Font = new System.Drawing.Font("Haettenschweiler", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCLientsPrimaryHeader.Location = new System.Drawing.Point(525, 17);
            this.lblCLientsPrimaryHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCLientsPrimaryHeader.Name = "lblCLientsPrimaryHeader";
            this.lblCLientsPrimaryHeader.Size = new System.Drawing.Size(519, 67);
            this.lblCLientsPrimaryHeader.TabIndex = 15;
            this.lblCLientsPrimaryHeader.Text = "Tranquillity Notifications";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14F);
            this.label1.Location = new System.Drawing.Point(790, 131);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 32);
            this.label1.TabIndex = 17;
            this.label1.Text = "System Notifications";
            // 
            // btnNotificationsBack
            // 
            this.btnNotificationsBack.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.btnNotificationsBack.Location = new System.Drawing.Point(129, 666);
            this.btnNotificationsBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnNotificationsBack.Name = "btnNotificationsBack";
            this.btnNotificationsBack.Size = new System.Drawing.Size(291, 115);
            this.btnNotificationsBack.TabIndex = 18;
            this.btnNotificationsBack.Text = "Back to Dashboard";
            this.btnNotificationsBack.UseVisualStyleBackColor = true;
            this.btnNotificationsBack.Click += new System.EventHandler(this.btnNotificationsBack_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 10F);
            this.label2.Location = new System.Drawing.Point(1000, 137);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(343, 22);
            this.label2.TabIndex = 20;
            this.label2.Text = "**Notifications will be deleted after 7 days";
            // 
            // Notifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 862);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNotificationsBack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblClientsPrimaryClientName);
            this.Controls.Add(this.lblCLientsPrimaryHeader);
            this.Controls.Add(this.chkListToDo);
            this.Controls.Add(this.txtAddToList);
            this.Controls.Add(this.btnAddToList);
            this.Controls.Add(this.chkListNotifications);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Notifications";
            this.Text = "Notifications";
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckedListBox chkListNotifications;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.TextBox txtAddToList;
        private System.Windows.Forms.CheckedListBox chkListToDo;
        private System.Windows.Forms.Label lblClientsPrimaryClientName;
        private System.Windows.Forms.Label lblCLientsPrimaryHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNotificationsBack;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteRecordToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}