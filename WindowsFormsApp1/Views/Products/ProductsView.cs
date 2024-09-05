using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Data.Orders;
using WindowsFormsApp1.Data.Products;
using WindowsFormsApp1.FormFuntionality;

namespace WindowsFormsApp1.Views.Products
{
    public partial class ProductsView : Form
    {
        DataHandlerProducts handler = new DataHandlerProducts();
        private DataTable productsDataTable;
        private DataTable skinClassificationsDataTable;

        public ProductsView()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            dgvProductsView.CellPainting += new DataGridViewCellPaintingEventHandler(dgvProductsView_CellPainting);
        }

        private void btnProductsViewSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable changes = ((DataTable)dgvProductsView.DataSource).GetChanges();
                if (changes != null)
                {
                    handler.UpdateProducts(changes);

                    foreach (DataRow row in changes.Rows)
                    {
                        int productId = (int)row["ProductID"];
                        string skinClassifications = row["SkinClassifications"].ToString();
                        string[] classifications = skinClassifications.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                        handler.UpdateProductSkinClassifications(productId, classifications);
                    }

                    MessageBox.Show("Changes saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshProductsView();
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

        private void SetupDataGridView()
        {
            dgvProductsView.AllowUserToAddRows = true;
            dgvProductsView.AllowUserToDeleteRows = false;
            dgvProductsView.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvProductsView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvProductsView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvProductsView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            string[] columnsToHide = { "ProductID", "CreatedAt" };
            foreach (string columnName in columnsToHide)
            {
                if (dgvProductsView.Columns[columnName] != null)
                {
                    dgvProductsView.Columns[columnName].Visible = false;
                }
            }

            DataTable categories = handler.FetchCategories();

            DataGridViewComboBoxColumn categoryComboBoxColumn = new DataGridViewComboBoxColumn
            {
                Name = "CategoryID",
                HeaderText = "Category",
                DataSource = categories,
                DisplayMember = "CategoryName",
                ValueMember = "CategoryID",
                DataPropertyName = "CategoryID"
            };


            DataGridViewComboBoxColumn skinClassificationsComboBoxColumn = new DataGridViewComboBoxColumn
            {
                Name = "SkinClassifications",
                HeaderText = "Skin Classifications",
                DataSource = skinClassificationsDataTable,
                DisplayMember = "SkinClassificationName",
                ValueMember = "SkinClassificationName"
            };


            DataGridViewDateTimePickerColumn dateColumn = new DataGridViewDateTimePickerColumn(includeTime: false);
            dateColumn.Name = "ModifiedAt";
            dateColumn.HeaderText = "ModifiedAt";
            dateColumn.DataPropertyName = "ModifiedAt";
            dateColumn.DateFormat = "yyyy-MM-dd HH:mm:ss";

            DataGridViewCheckBoxColumn isActiveCheckBoxColumn = new DataGridViewCheckBoxColumn
            {
                Name = "IsActive",
                HeaderText = "Is Active",
                DataPropertyName = "IsActive",
                TrueValue = true,
                FalseValue = false
            };

            if (dgvProductsView.Columns["CategoryID"] != null)
            {
                int categoryIndex = dgvProductsView.Columns["CategoryID"].Index;
                dgvProductsView.Columns.RemoveAt(categoryIndex);
                dgvProductsView.Columns.Insert(categoryIndex, categoryComboBoxColumn);
            }

            if (dgvProductsView.Columns["ModifiedAt"] != null)
            {
                int modifiedAtIndex = dgvProductsView.Columns["ModifiedAt"].Index;
                dgvProductsView.Columns.RemoveAt(modifiedAtIndex);
                dgvProductsView.Columns.Insert(modifiedAtIndex, dateColumn);
            }

            if (dgvProductsView.Columns["SkinClassifications"] == null)
            {
                dgvProductsView.Columns.Add(skinClassificationsComboBoxColumn);
            }

            if (dgvProductsView.Columns["IsActive"] != null)
            {
                int isActiveIndex = dgvProductsView.Columns["IsActive"].Index;
                dgvProductsView.Columns.RemoveAt(isActiveIndex);
            }

            dgvProductsView.Columns.Add(isActiveCheckBoxColumn);
        }


        private void RefreshProductsView()
        {
            productsDataTable = handler.FetchProducts();
            skinClassificationsDataTable = handler.FetchProductSkinClassifications();

            DataTable mergedDataTable = MergeProductSkinClassifications(productsDataTable, skinClassificationsDataTable);
            dgvProductsView.DataSource = mergedDataTable;
            SetupDataGridView();
        }


        private DataTable MergeProductSkinClassifications(DataTable products, DataTable skinClassifications)
        {
            DataTable result = products.Copy();
            result.Columns.Add("SkinClassifications", typeof(string));

            foreach (DataRow productRow in result.Rows)
            {
                int productId = (int)productRow["ProductID"];
                var classifications = from sc in skinClassifications.AsEnumerable()
                                      where sc.Field<int>("ProductID") == productId
                                      select sc.Field<string>("SkinClassificationName");

                productRow["SkinClassifications"] = string.Join(", ", classifications);
            }

            return result;
        }

        private void btnProductsViewBack_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void ProductsView_Load(object sender, EventArgs e)
        {
            RefreshProductsView();
        }

        private void dgvProductsView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dgvProductsView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dgvProductsView.Columns["SkinClassifications"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.ClipBounds, true);

                string text = e.Value?.ToString();
                if (string.IsNullOrEmpty(text))
                {
                    e.Handled = true;
                    return;
                }

                var classifications = text.Split(new[] { ", " }, StringSplitOptions.None);
                var colorMap = new Dictionary<string, Color>
        {
            { "Environmentally Damaged", Color.Orange },
            { "Hyperpigmented", Color.Blue },
            { "Problematic", Color.Green },
            { "Interactive", Color.BlueViolet }
        };

                var font = e.CellStyle.Font ?? dgvProductsView.Font;
                var bounds = e.CellBounds;
                bounds.Inflate(-2, -2);
                var point = new Point(bounds.X, bounds.Y);

                foreach (var classification in classifications)
                {
                    if (colorMap.TryGetValue(classification, out var color))
                    {
                        TextRenderer.DrawText(e.Graphics, classification, font, point, color, TextFormatFlags.Left);
                        var size = TextRenderer.MeasureText(classification, font);
                        point.Y += size.Height;
                    }
                }

                e.Handled = true;
            }
        }
    }
}
