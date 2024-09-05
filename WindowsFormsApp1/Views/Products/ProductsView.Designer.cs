namespace WindowsFormsApp1.Views.Products
{
    partial class ProductsView
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
            this.lblProductsViewHeader = new System.Windows.Forms.Label();
            this.btnProductsViewSave = new System.Windows.Forms.Button();
            this.dgvProductsView = new System.Windows.Forms.DataGridView();
            this.btnProductsViewBack = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductsView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProductsViewHeader
            // 
            this.lblProductsViewHeader.AutoSize = true;
            this.lblProductsViewHeader.Font = new System.Drawing.Font("Haettenschweiler", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductsViewHeader.Location = new System.Drawing.Point(788, 11);
            this.lblProductsViewHeader.Name = "lblProductsViewHeader";
            this.lblProductsViewHeader.Size = new System.Drawing.Size(446, 67);
            this.lblProductsViewHeader.TabIndex = 19;
            this.lblProductsViewHeader.Text = "Tranquillity Products";
            // 
            // btnProductsViewSave
            // 
            this.btnProductsViewSave.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.btnProductsViewSave.Location = new System.Drawing.Point(908, 791);
            this.btnProductsViewSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProductsViewSave.Name = "btnProductsViewSave";
            this.btnProductsViewSave.Size = new System.Drawing.Size(351, 174);
            this.btnProductsViewSave.TabIndex = 16;
            this.btnProductsViewSave.Text = "Save";
            this.btnProductsViewSave.Click += new System.EventHandler(this.btnProductsViewSave_Click);
            // 
            // dgvProductsView
            // 
            this.dgvProductsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductsView.Location = new System.Drawing.Point(5, 2);
            this.dgvProductsView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvProductsView.Name = "dgvProductsView";
            this.dgvProductsView.RowHeadersWidth = 51;
            this.dgvProductsView.RowTemplate.Height = 24;
            this.dgvProductsView.Size = new System.Drawing.Size(2009, 674);
            this.dgvProductsView.TabIndex = 18;
            this.dgvProductsView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProductsView_CellFormatting);
            this.dgvProductsView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvProductsView_CellPainting);
            // 
            // btnProductsViewBack
            // 
            this.btnProductsViewBack.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.btnProductsViewBack.Location = new System.Drawing.Point(15, 791);
            this.btnProductsViewBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProductsViewBack.Name = "btnProductsViewBack";
            this.btnProductsViewBack.Size = new System.Drawing.Size(368, 174);
            this.btnProductsViewBack.TabIndex = 17;
            this.btnProductsViewBack.Text = "Back to Dashboard";
            this.btnProductsViewBack.UseVisualStyleBackColor = true;
            this.btnProductsViewBack.Click += new System.EventHandler(this.btnProductsViewBack_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvProductsView);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.panel1.Location = new System.Drawing.Point(12, 101);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2017, 685);
            this.panel1.TabIndex = 20;
            // 
            // ProductsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2041, 978);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblProductsViewHeader);
            this.Controls.Add(this.btnProductsViewSave);
            this.Controls.Add(this.btnProductsViewBack);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProductsView";
            this.Text = "ProductsView";
            this.Load += new System.EventHandler(this.ProductsView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductsView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProductsViewHeader;
        private System.Windows.Forms.Button btnProductsViewSave;
        private System.Windows.Forms.DataGridView dgvProductsView;
        private System.Windows.Forms.Button btnProductsViewBack;
        private System.Windows.Forms.Panel panel1;
    }
}