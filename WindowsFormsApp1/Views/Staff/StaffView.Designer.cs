namespace WindowsFormsApp1.Views.Staff
{
    partial class StaffView
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
            this.lblStaffViewHeader = new System.Windows.Forms.Label();
            this.btnStaffViewSave = new System.Windows.Forms.Button();
            this.dgvStaffView = new System.Windows.Forms.DataGridView();
            this.btnStaffViewBack = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaffView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStaffViewHeader
            // 
            this.lblStaffViewHeader.AutoSize = true;
            this.lblStaffViewHeader.Font = new System.Drawing.Font("Haettenschweiler", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffViewHeader.Location = new System.Drawing.Point(807, 26);
            this.lblStaffViewHeader.Name = "lblStaffViewHeader";
            this.lblStaffViewHeader.Size = new System.Drawing.Size(368, 67);
            this.lblStaffViewHeader.TabIndex = 19;
            this.lblStaffViewHeader.Text = "Tranquillity Staff";
            // 
            // btnStaffViewSave
            // 
            this.btnStaffViewSave.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.btnStaffViewSave.Location = new System.Drawing.Point(859, 800);
            this.btnStaffViewSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStaffViewSave.Name = "btnStaffViewSave";
            this.btnStaffViewSave.Size = new System.Drawing.Size(337, 165);
            this.btnStaffViewSave.TabIndex = 16;
            this.btnStaffViewSave.Text = "Save";
            this.btnStaffViewSave.Click += new System.EventHandler(this.btnStaffViewSave_Click);
            // 
            // dgvStaffView
            // 
            this.dgvStaffView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStaffView.Location = new System.Drawing.Point(3, 2);
            this.dgvStaffView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvStaffView.Name = "dgvStaffView";
            this.dgvStaffView.RowHeadersWidth = 51;
            this.dgvStaffView.RowTemplate.Height = 24;
            this.dgvStaffView.Size = new System.Drawing.Size(2009, 674);
            this.dgvStaffView.TabIndex = 18;
            this.dgvStaffView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaffView_CellClick);
            this.dgvStaffView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaffView_CellContentClick);
            // 
            // btnStaffViewBack
            // 
            this.btnStaffViewBack.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.btnStaffViewBack.Location = new System.Drawing.Point(15, 795);
            this.btnStaffViewBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStaffViewBack.Name = "btnStaffViewBack";
            this.btnStaffViewBack.Size = new System.Drawing.Size(409, 170);
            this.btnStaffViewBack.TabIndex = 17;
            this.btnStaffViewBack.Text = "Back to Dashboard";
            this.btnStaffViewBack.UseVisualStyleBackColor = true;
            this.btnStaffViewBack.Click += new System.EventHandler(this.btnStaffViewBack_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvStaffView);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.panel1.Location = new System.Drawing.Point(15, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2015, 678);
            this.panel1.TabIndex = 20;
            // 
            // StaffView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2041, 978);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblStaffViewHeader);
            this.Controls.Add(this.btnStaffViewSave);
            this.Controls.Add(this.btnStaffViewBack);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StaffView";
            this.Text = "StaffView";
            this.Load += new System.EventHandler(this.StaffView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaffView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStaffViewHeader;
        private System.Windows.Forms.Button btnStaffViewSave;
        private System.Windows.Forms.DataGridView dgvStaffView;
        private System.Windows.Forms.Button btnStaffViewBack;
        private System.Windows.Forms.Panel panel1;
    }
}