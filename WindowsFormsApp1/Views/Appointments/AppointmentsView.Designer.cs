﻿namespace WindowsFormsApp1.Views.Appointments
{
    partial class AppointmentsView
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
            this.lblAppointmentsViewHeader = new System.Windows.Forms.Label();
            this.btnAppointmentsViewSave = new System.Windows.Forms.Button();
            this.dgvAppointmentsView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAppointmentsViewBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentsView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAppointmentsViewHeader
            // 
            this.lblAppointmentsViewHeader.AutoSize = true;
            this.lblAppointmentsViewHeader.Font = new System.Drawing.Font("Haettenschweiler", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentsViewHeader.Location = new System.Drawing.Point(608, 11);
            this.lblAppointmentsViewHeader.Name = "lblAppointmentsViewHeader";
            this.lblAppointmentsViewHeader.Size = new System.Drawing.Size(735, 67);
            this.lblAppointmentsViewHeader.TabIndex = 11;
            this.lblAppointmentsViewHeader.Text = "Tranquillity Upcoming Appointments";
            // 
            // btnAppointmentsViewSave
            // 
            this.btnAppointmentsViewSave.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.btnAppointmentsViewSave.Location = new System.Drawing.Point(871, 820);
            this.btnAppointmentsViewSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAppointmentsViewSave.Name = "btnAppointmentsViewSave";
            this.btnAppointmentsViewSave.Size = new System.Drawing.Size(344, 124);
            this.btnAppointmentsViewSave.TabIndex = 6;
            this.btnAppointmentsViewSave.Text = "Save";
            this.btnAppointmentsViewSave.Click += new System.EventHandler(this.btnAppointmentsViewSave_Click);
            // 
            // dgvAppointmentsView
            // 
            this.dgvAppointmentsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointmentsView.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAppointmentsView.Location = new System.Drawing.Point(3, 2);
            this.dgvAppointmentsView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvAppointmentsView.Name = "dgvAppointmentsView";
            this.dgvAppointmentsView.RowHeadersWidth = 51;
            this.dgvAppointmentsView.RowTemplate.Height = 24;
            this.dgvAppointmentsView.Size = new System.Drawing.Size(2000, 550);
            this.dgvAppointmentsView.TabIndex = 8;
            this.dgvAppointmentsView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvAppointmentsView_CellBeginEdit);
            this.dgvAppointmentsView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppointmentsView_CellContentClick);
            this.dgvAppointmentsView.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppointmentsView_RowValidated);
            this.dgvAppointmentsView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvAppointmentsView_RowValidating);
            this.dgvAppointmentsView.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvAppointmentsView_UserAddedRow);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvAppointmentsView);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.panel1.Location = new System.Drawing.Point(12, 132);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2019, 571);
            this.panel1.TabIndex = 12;
            // 
            // btnAppointmentsViewBack
            // 
            this.btnAppointmentsViewBack.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.btnAppointmentsViewBack.Location = new System.Drawing.Point(28, 820);
            this.btnAppointmentsViewBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAppointmentsViewBack.Name = "btnAppointmentsViewBack";
            this.btnAppointmentsViewBack.Size = new System.Drawing.Size(404, 124);
            this.btnAppointmentsViewBack.TabIndex = 7;
            this.btnAppointmentsViewBack.Text = "Back to Dashboard";
            this.btnAppointmentsViewBack.UseVisualStyleBackColor = true;
            this.btnAppointmentsViewBack.Click += new System.EventHandler(this.btnAppointmentsViewBack_Click);
            // 
            // AppointmentsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 978);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblAppointmentsViewHeader);
            this.Controls.Add(this.btnAppointmentsViewSave);
            this.Controls.Add(this.btnAppointmentsViewBack);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AppointmentsView";
            this.Text = "Appointments";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppointmentsView_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AppointmentsView_FormClosed);
            this.Load += new System.EventHandler(this.AppointmentsView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentsView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAppointmentsViewHeader;
        private System.Windows.Forms.Button btnAppointmentsViewSave;
        private System.Windows.Forms.DataGridView dgvAppointmentsView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAppointmentsViewBack;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteRecordToolStripMenuItem;
    }
}