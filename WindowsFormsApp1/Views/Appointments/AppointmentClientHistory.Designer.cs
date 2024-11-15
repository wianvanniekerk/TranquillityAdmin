namespace WindowsFormsApp1.Views.Appointments
{
    partial class AppointmentClientHistory
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
            this.dgvAppointmentClientHistoryGeneral = new System.Windows.Forms.DataGridView();
            this.btnAppointmentsViewBack = new System.Windows.Forms.Button();
            this.btnAppointmentClientHistorySave = new System.Windows.Forms.Button();
            this.tabClients = new System.Windows.Forms.TabControl();
            this.historyGeneral = new System.Windows.Forms.TabPage();
            this.historyMedical = new System.Windows.Forms.TabPage();
            this.dgvAppointmentClientHistoryMedical = new System.Windows.Forms.DataGridView();
            this.historyMedication = new System.Windows.Forms.TabPage();
            this.dgvAppointmentClientHistoryMedication = new System.Windows.Forms.DataGridView();
            this.lblAppointmentClientHistoryHeader = new System.Windows.Forms.Label();
            this.btnClientsPrimaryBack = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabClient = new System.Windows.Forms.TabPage();
            this.tabStaff = new System.Windows.Forms.TabPage();
            this.tabStaff1 = new System.Windows.Forms.TabControl();
            this.historyInitial = new System.Windows.Forms.TabPage();
            this.btnAppointmentClientHistoryInitialSave = new System.Windows.Forms.Button();
            this.dgvInitialTreatment = new System.Windows.Forms.DataGridView();
            this.historyFollowUp = new System.Windows.Forms.TabPage();
            this.btnAppointmentClientHistoryFollowUpSave = new System.Windows.Forms.Button();
            this.dgvFollowUpTreatment = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentClientHistoryGeneral)).BeginInit();
            this.tabClients.SuspendLayout();
            this.historyGeneral.SuspendLayout();
            this.historyMedical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentClientHistoryMedical)).BeginInit();
            this.historyMedication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentClientHistoryMedication)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabClient.SuspendLayout();
            this.tabStaff.SuspendLayout();
            this.tabStaff1.SuspendLayout();
            this.historyInitial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInitialTreatment)).BeginInit();
            this.historyFollowUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFollowUpTreatment)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAppointmentClientHistoryGeneral
            // 
            this.dgvAppointmentClientHistoryGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointmentClientHistoryGeneral.Location = new System.Drawing.Point(7, 62);
            this.dgvAppointmentClientHistoryGeneral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvAppointmentClientHistoryGeneral.Name = "dgvAppointmentClientHistoryGeneral";
            this.dgvAppointmentClientHistoryGeneral.RowHeadersWidth = 51;
            this.dgvAppointmentClientHistoryGeneral.RowTemplate.Height = 24;
            this.dgvAppointmentClientHistoryGeneral.Size = new System.Drawing.Size(1965, 378);
            this.dgvAppointmentClientHistoryGeneral.TabIndex = 8;
            // 
            // btnAppointmentsViewBack
            // 
            this.btnAppointmentsViewBack.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.btnAppointmentsViewBack.Location = new System.Drawing.Point(28, 759);
            this.btnAppointmentsViewBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAppointmentsViewBack.Name = "btnAppointmentsViewBack";
            this.btnAppointmentsViewBack.Size = new System.Drawing.Size(271, 150);
            this.btnAppointmentsViewBack.TabIndex = 13;
            this.btnAppointmentsViewBack.Text = "Back to Appointments";
            this.btnAppointmentsViewBack.UseVisualStyleBackColor = true;
            this.btnAppointmentsViewBack.Click += new System.EventHandler(this.btnAppointmentsViewBack_Click);
            // 
            // btnAppointmentClientHistorySave
            // 
            this.btnAppointmentClientHistorySave.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.btnAppointmentClientHistorySave.Location = new System.Drawing.Point(807, 498);
            this.btnAppointmentClientHistorySave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAppointmentClientHistorySave.Name = "btnAppointmentClientHistorySave";
            this.btnAppointmentClientHistorySave.Size = new System.Drawing.Size(412, 100);
            this.btnAppointmentClientHistorySave.TabIndex = 14;
            this.btnAppointmentClientHistorySave.Text = "Save";
            this.btnAppointmentClientHistorySave.UseVisualStyleBackColor = true;
            this.btnAppointmentClientHistorySave.Click += new System.EventHandler(this.btnAppointmentClientHistorySave_Click);
            // 
            // tabClients
            // 
            this.tabClients.Controls.Add(this.historyGeneral);
            this.tabClients.Controls.Add(this.historyMedical);
            this.tabClients.Controls.Add(this.historyMedication);
            this.tabClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tabClients.Location = new System.Drawing.Point(11, 7);
            this.tabClients.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabClients.Name = "tabClients";
            this.tabClients.SelectedIndex = 0;
            this.tabClients.Size = new System.Drawing.Size(1988, 485);
            this.tabClients.TabIndex = 15;
            // 
            // historyGeneral
            // 
            this.historyGeneral.Controls.Add(this.dgvAppointmentClientHistoryGeneral);
            this.historyGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.historyGeneral.Location = new System.Drawing.Point(4, 31);
            this.historyGeneral.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.historyGeneral.Name = "historyGeneral";
            this.historyGeneral.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.historyGeneral.Size = new System.Drawing.Size(1980, 450);
            this.historyGeneral.TabIndex = 0;
            this.historyGeneral.Text = "General";
            this.historyGeneral.UseVisualStyleBackColor = true;
            // 
            // historyMedical
            // 
            this.historyMedical.Controls.Add(this.dgvAppointmentClientHistoryMedical);
            this.historyMedical.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.historyMedical.Location = new System.Drawing.Point(4, 31);
            this.historyMedical.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.historyMedical.Name = "historyMedical";
            this.historyMedical.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.historyMedical.Size = new System.Drawing.Size(1980, 450);
            this.historyMedical.TabIndex = 1;
            this.historyMedical.Text = "Medical Information";
            this.historyMedical.UseVisualStyleBackColor = true;
            // 
            // dgvAppointmentClientHistoryMedical
            // 
            this.dgvAppointmentClientHistoryMedical.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointmentClientHistoryMedical.Location = new System.Drawing.Point(7, 65);
            this.dgvAppointmentClientHistoryMedical.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvAppointmentClientHistoryMedical.Name = "dgvAppointmentClientHistoryMedical";
            this.dgvAppointmentClientHistoryMedical.RowHeadersWidth = 51;
            this.dgvAppointmentClientHistoryMedical.RowTemplate.Height = 24;
            this.dgvAppointmentClientHistoryMedical.Size = new System.Drawing.Size(1965, 391);
            this.dgvAppointmentClientHistoryMedical.TabIndex = 9;
            // 
            // historyMedication
            // 
            this.historyMedication.Controls.Add(this.dgvAppointmentClientHistoryMedication);
            this.historyMedication.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.historyMedication.Location = new System.Drawing.Point(4, 31);
            this.historyMedication.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.historyMedication.Name = "historyMedication";
            this.historyMedication.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.historyMedication.Size = new System.Drawing.Size(1980, 450);
            this.historyMedication.TabIndex = 2;
            this.historyMedication.Text = "Medication Information";
            this.historyMedication.UseVisualStyleBackColor = true;
            // 
            // dgvAppointmentClientHistoryMedication
            // 
            this.dgvAppointmentClientHistoryMedication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointmentClientHistoryMedication.Location = new System.Drawing.Point(7, 65);
            this.dgvAppointmentClientHistoryMedication.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvAppointmentClientHistoryMedication.Name = "dgvAppointmentClientHistoryMedication";
            this.dgvAppointmentClientHistoryMedication.RowHeadersWidth = 51;
            this.dgvAppointmentClientHistoryMedication.RowTemplate.Height = 24;
            this.dgvAppointmentClientHistoryMedication.Size = new System.Drawing.Size(1965, 391);
            this.dgvAppointmentClientHistoryMedication.TabIndex = 9;
            // 
            // lblAppointmentClientHistoryHeader
            // 
            this.lblAppointmentClientHistoryHeader.AutoSize = true;
            this.lblAppointmentClientHistoryHeader.Font = new System.Drawing.Font("Haettenschweiler", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentClientHistoryHeader.Location = new System.Drawing.Point(775, 11);
            this.lblAppointmentClientHistoryHeader.Name = "lblAppointmentClientHistoryHeader";
            this.lblAppointmentClientHistoryHeader.Size = new System.Drawing.Size(299, 67);
            this.lblAppointmentClientHistoryHeader.TabIndex = 16;
            this.lblAppointmentClientHistoryHeader.Text = "Client History";
            // 
            // btnClientsPrimaryBack
            // 
            this.btnClientsPrimaryBack.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.btnClientsPrimaryBack.Location = new System.Drawing.Point(333, 759);
            this.btnClientsPrimaryBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClientsPrimaryBack.Name = "btnClientsPrimaryBack";
            this.btnClientsPrimaryBack.Size = new System.Drawing.Size(271, 150);
            this.btnClientsPrimaryBack.TabIndex = 17;
            this.btnClientsPrimaryBack.Text = "Back to Client";
            this.btnClientsPrimaryBack.UseVisualStyleBackColor = true;
            this.btnClientsPrimaryBack.Click += new System.EventHandler(this.btnClientsPrimaryBack_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabClient);
            this.tabControl1.Controls.Add(this.tabStaff);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(13, 94);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2015, 660);
            this.tabControl1.TabIndex = 18;
            // 
            // tabClient
            // 
            this.tabClient.Controls.Add(this.tabClients);
            this.tabClient.Controls.Add(this.btnAppointmentClientHistorySave);
            this.tabClient.Location = new System.Drawing.Point(4, 37);
            this.tabClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabClient.Name = "tabClient";
            this.tabClient.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabClient.Size = new System.Drawing.Size(2007, 619);
            this.tabClient.TabIndex = 0;
            this.tabClient.Text = "Completed by Client";
            this.tabClient.UseVisualStyleBackColor = true;
            // 
            // tabStaff
            // 
            this.tabStaff.Controls.Add(this.tabStaff1);
            this.tabStaff.Location = new System.Drawing.Point(4, 37);
            this.tabStaff.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabStaff.Name = "tabStaff";
            this.tabStaff.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabStaff.Size = new System.Drawing.Size(2007, 619);
            this.tabStaff.TabIndex = 1;
            this.tabStaff.Text = "Completed by Staff";
            this.tabStaff.UseVisualStyleBackColor = true;
            // 
            // tabStaff1
            // 
            this.tabStaff1.Controls.Add(this.historyInitial);
            this.tabStaff1.Controls.Add(this.historyFollowUp);
            this.tabStaff1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tabStaff1.Location = new System.Drawing.Point(8, 7);
            this.tabStaff1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabStaff1.Name = "tabStaff1";
            this.tabStaff1.SelectedIndex = 0;
            this.tabStaff1.Size = new System.Drawing.Size(1995, 603);
            this.tabStaff1.TabIndex = 16;
            // 
            // historyInitial
            // 
            this.historyInitial.Controls.Add(this.btnAppointmentClientHistoryInitialSave);
            this.historyInitial.Controls.Add(this.dgvInitialTreatment);
            this.historyInitial.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.historyInitial.Location = new System.Drawing.Point(4, 31);
            this.historyInitial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.historyInitial.Name = "historyInitial";
            this.historyInitial.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.historyInitial.Size = new System.Drawing.Size(1987, 568);
            this.historyInitial.TabIndex = 0;
            this.historyInitial.Text = "Initial Treatment";
            this.historyInitial.UseVisualStyleBackColor = true;
            // 
            // btnAppointmentClientHistoryInitialSave
            // 
            this.btnAppointmentClientHistoryInitialSave.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.btnAppointmentClientHistoryInitialSave.Location = new System.Drawing.Point(699, 433);
            this.btnAppointmentClientHistoryInitialSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAppointmentClientHistoryInitialSave.Name = "btnAppointmentClientHistoryInitialSave";
            this.btnAppointmentClientHistoryInitialSave.Size = new System.Drawing.Size(412, 106);
            this.btnAppointmentClientHistoryInitialSave.TabIndex = 17;
            this.btnAppointmentClientHistoryInitialSave.Text = "Save";
            this.btnAppointmentClientHistoryInitialSave.UseVisualStyleBackColor = true;
            this.btnAppointmentClientHistoryInitialSave.Click += new System.EventHandler(this.btnAppointmentClientHistoryInitialSave_Click);
            // 
            // dgvInitialTreatment
            // 
            this.dgvInitialTreatment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInitialTreatment.Location = new System.Drawing.Point(7, 16);
            this.dgvInitialTreatment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvInitialTreatment.Name = "dgvInitialTreatment";
            this.dgvInitialTreatment.RowHeadersWidth = 51;
            this.dgvInitialTreatment.RowTemplate.Height = 24;
            this.dgvInitialTreatment.Size = new System.Drawing.Size(1973, 395);
            this.dgvInitialTreatment.TabIndex = 8;
            this.dgvInitialTreatment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInitialTreatment_CellContentClick);
            this.dgvInitialTreatment.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInitialTreatment_CellEnter);
            // 
            // historyFollowUp
            // 
            this.historyFollowUp.Controls.Add(this.btnAppointmentClientHistoryFollowUpSave);
            this.historyFollowUp.Controls.Add(this.dgvFollowUpTreatment);
            this.historyFollowUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.historyFollowUp.Location = new System.Drawing.Point(4, 31);
            this.historyFollowUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.historyFollowUp.Name = "historyFollowUp";
            this.historyFollowUp.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.historyFollowUp.Size = new System.Drawing.Size(1987, 568);
            this.historyFollowUp.TabIndex = 1;
            this.historyFollowUp.Text = "Follow-up Treatment";
            this.historyFollowUp.UseVisualStyleBackColor = true;
            // 
            // btnAppointmentClientHistoryFollowUpSave
            // 
            this.btnAppointmentClientHistoryFollowUpSave.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.btnAppointmentClientHistoryFollowUpSave.Location = new System.Drawing.Point(772, 446);
            this.btnAppointmentClientHistoryFollowUpSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAppointmentClientHistoryFollowUpSave.Name = "btnAppointmentClientHistoryFollowUpSave";
            this.btnAppointmentClientHistoryFollowUpSave.Size = new System.Drawing.Size(412, 102);
            this.btnAppointmentClientHistoryFollowUpSave.TabIndex = 18;
            this.btnAppointmentClientHistoryFollowUpSave.Text = "Save";
            this.btnAppointmentClientHistoryFollowUpSave.UseVisualStyleBackColor = true;
            this.btnAppointmentClientHistoryFollowUpSave.Click += new System.EventHandler(this.btnAppointmentClientHistoryFollowUpSaveClick);
            // 
            // dgvFollowUpTreatment
            // 
            this.dgvFollowUpTreatment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFollowUpTreatment.Location = new System.Drawing.Point(7, 6);
            this.dgvFollowUpTreatment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvFollowUpTreatment.Name = "dgvFollowUpTreatment";
            this.dgvFollowUpTreatment.RowHeadersWidth = 51;
            this.dgvFollowUpTreatment.RowTemplate.Height = 24;
            this.dgvFollowUpTreatment.Size = new System.Drawing.Size(1973, 421);
            this.dgvFollowUpTreatment.TabIndex = 9;
            this.dgvFollowUpTreatment.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFollowUpTreatment_CellEnter);
            // 
            // AppointmentClientHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 978);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClientsPrimaryBack);
            this.Controls.Add(this.lblAppointmentClientHistoryHeader);
            this.Controls.Add(this.btnAppointmentsViewBack);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AppointmentClientHistory";
            this.Text = "AppointmentClientHistory";
            this.Load += new System.EventHandler(this.AppointmentClientHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentClientHistoryGeneral)).EndInit();
            this.tabClients.ResumeLayout(false);
            this.historyGeneral.ResumeLayout(false);
            this.historyMedical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentClientHistoryMedical)).EndInit();
            this.historyMedication.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentClientHistoryMedication)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabClient.ResumeLayout(false);
            this.tabStaff.ResumeLayout(false);
            this.tabStaff1.ResumeLayout(false);
            this.historyInitial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInitialTreatment)).EndInit();
            this.historyFollowUp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFollowUpTreatment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAppointmentClientHistoryGeneral;
        private System.Windows.Forms.Button btnAppointmentsViewBack;
        private System.Windows.Forms.Button btnAppointmentClientHistorySave;
        private System.Windows.Forms.TabControl tabClients;
        private System.Windows.Forms.TabPage historyGeneral;
        private System.Windows.Forms.TabPage historyMedical;
        private System.Windows.Forms.Label lblAppointmentClientHistoryHeader;
        private System.Windows.Forms.TabPage historyMedication;
        private System.Windows.Forms.DataGridView dgvAppointmentClientHistoryMedical;
        private System.Windows.Forms.DataGridView dgvAppointmentClientHistoryMedication;
        private System.Windows.Forms.Button btnClientsPrimaryBack;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabClient;
        private System.Windows.Forms.TabPage tabStaff;
        private System.Windows.Forms.TabControl tabStaff1;
        private System.Windows.Forms.TabPage historyInitial;
        private System.Windows.Forms.DataGridView dgvInitialTreatment;
        private System.Windows.Forms.TabPage historyFollowUp;
        private System.Windows.Forms.DataGridView dgvFollowUpTreatment;
        private System.Windows.Forms.Button btnAppointmentClientHistoryInitialSave;
        private System.Windows.Forms.Button btnAppointmentClientHistoryFollowUpSave;
    }
}