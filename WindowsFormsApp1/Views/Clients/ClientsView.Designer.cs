namespace WindowsFormsApp1.Views.Clients.View
{
    partial class ClientsView
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
            this.btnClientsViewBack = new System.Windows.Forms.Button();
            this.dgvClientsView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClientsViewSave = new System.Windows.Forms.Button();
            this.lblCLientsViewHeader = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientsView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClientsViewBack
            // 
            this.btnClientsViewBack.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.btnClientsViewBack.Location = new System.Drawing.Point(59, 746);
            this.btnClientsViewBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClientsViewBack.Name = "btnClientsViewBack";
            this.btnClientsViewBack.Size = new System.Drawing.Size(416, 171);
            this.btnClientsViewBack.TabIndex = 0;
            this.btnClientsViewBack.Text = "Back to Dashboard";
            this.btnClientsViewBack.UseVisualStyleBackColor = true;
            this.btnClientsViewBack.Click += new System.EventHandler(this.btnCLientsViewBack_Click);
            // 
            // dgvClientsView
            // 
            this.dgvClientsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientsView.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvClientsView.Location = new System.Drawing.Point(3, 2);
            this.dgvClientsView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvClientsView.Name = "dgvClientsView";
            this.dgvClientsView.RowHeadersWidth = 51;
            this.dgvClientsView.RowTemplate.Height = 24;
            this.dgvClientsView.Size = new System.Drawing.Size(2000, 550);
            this.dgvClientsView.TabIndex = 1;
            this.dgvClientsView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvClientsView_CellBeginEdit);
            this.dgvClientsView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientsView_CellContentClick);
            this.dgvClientsView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvClientsView_RowValidating);
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
            // btnClientsViewSave
            // 
            this.btnClientsViewSave.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.btnClientsViewSave.Location = new System.Drawing.Point(872, 746);
            this.btnClientsViewSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClientsViewSave.Name = "btnClientsViewSave";
            this.btnClientsViewSave.Size = new System.Drawing.Size(419, 171);
            this.btnClientsViewSave.TabIndex = 0;
            this.btnClientsViewSave.Text = "Save";
            this.btnClientsViewSave.Click += new System.EventHandler(this.btnClientsViewSave_Click);
            // 
            // lblCLientsViewHeader
            // 
            this.lblCLientsViewHeader.AutoSize = true;
            this.lblCLientsViewHeader.Font = new System.Drawing.Font("Haettenschweiler", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCLientsViewHeader.Location = new System.Drawing.Point(769, 11);
            this.lblCLientsViewHeader.Name = "lblCLientsViewHeader";
            this.lblCLientsViewHeader.Size = new System.Drawing.Size(399, 67);
            this.lblCLientsViewHeader.TabIndex = 5;
            this.lblCLientsViewHeader.Text = "Tranquillity Clients";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvClientsView);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.panel1.Location = new System.Drawing.Point(12, 158);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2019, 571);
            this.panel1.TabIndex = 6;
            // 
            // ClientsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 978);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblCLientsViewHeader);
            this.Controls.Add(this.btnClientsViewSave);
            this.Controls.Add(this.btnClientsViewBack);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ClientsView";
            this.Text = "ClientsView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientsView_FormClosing);
            this.Load += new System.EventHandler(this.ClientsView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientsView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClientsViewBack;
        private System.Windows.Forms.DataGridView dgvClientsView;
        private System.Windows.Forms.Button btnClientsViewSave;
        private System.Windows.Forms.Label lblCLientsViewHeader;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteRecordToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
    }
}