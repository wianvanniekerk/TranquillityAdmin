namespace WindowsFormsApp1.Views.Orders
{
    partial class OrdersView
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
            this.lblOrdersViewHeader = new System.Windows.Forms.Label();
            this.btnOrdersViewSave = new System.Windows.Forms.Button();
            this.dgvOrdersView = new System.Windows.Forms.DataGridView();
            this.btnOrdersViewBack = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOrdersViewHeader
            // 
            this.lblOrdersViewHeader.AutoSize = true;
            this.lblOrdersViewHeader.Font = new System.Drawing.Font("Haettenschweiler", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdersViewHeader.Location = new System.Drawing.Point(776, 11);
            this.lblOrdersViewHeader.Name = "lblOrdersViewHeader";
            this.lblOrdersViewHeader.Size = new System.Drawing.Size(404, 67);
            this.lblOrdersViewHeader.TabIndex = 15;
            this.lblOrdersViewHeader.Text = "Tranquillity Orders";
            // 
            // btnOrdersViewSave
            // 
            this.btnOrdersViewSave.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.btnOrdersViewSave.Location = new System.Drawing.Point(815, 773);
            this.btnOrdersViewSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrdersViewSave.Name = "btnOrdersViewSave";
            this.btnOrdersViewSave.Size = new System.Drawing.Size(363, 176);
            this.btnOrdersViewSave.TabIndex = 12;
            this.btnOrdersViewSave.Text = "Save";
            this.btnOrdersViewSave.Click += new System.EventHandler(this.btnOrdersViewSave_Click);
            // 
            // dgvOrdersView
            // 
            this.dgvOrdersView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdersView.Location = new System.Drawing.Point(6, 15);
            this.dgvOrdersView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvOrdersView.Name = "dgvOrdersView";
            this.dgvOrdersView.RowHeadersWidth = 51;
            this.dgvOrdersView.RowTemplate.Height = 24;
            this.dgvOrdersView.Size = new System.Drawing.Size(2006, 634);
            this.dgvOrdersView.TabIndex = 14;
            this.dgvOrdersView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdersView_CellClick);
            this.dgvOrdersView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdersView_CellContentClick);
            // 
            // btnOrdersViewBack
            // 
            this.btnOrdersViewBack.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.btnOrdersViewBack.Location = new System.Drawing.Point(15, 773);
            this.btnOrdersViewBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrdersViewBack.Name = "btnOrdersViewBack";
            this.btnOrdersViewBack.Size = new System.Drawing.Size(388, 176);
            this.btnOrdersViewBack.TabIndex = 13;
            this.btnOrdersViewBack.Text = "Back to Dashboard";
            this.btnOrdersViewBack.UseVisualStyleBackColor = true;
            this.btnOrdersViewBack.Click += new System.EventHandler(this.btnOrdersViewBack_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvOrdersView);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.panel1.Location = new System.Drawing.Point(9, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2015, 643);
            this.panel1.TabIndex = 16;
            // 
            // OrdersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1924, 978);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblOrdersViewHeader);
            this.Controls.Add(this.btnOrdersViewSave);
            this.Controls.Add(this.btnOrdersViewBack);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OrdersView";
            this.Text = "OrdersView";
            this.Load += new System.EventHandler(this.OrdersView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOrdersViewHeader;
        private System.Windows.Forms.Button btnOrdersViewSave;
        private System.Windows.Forms.DataGridView dgvOrdersView;
        private System.Windows.Forms.Button btnOrdersViewBack;
        private System.Windows.Forms.Panel panel1;
    }
}