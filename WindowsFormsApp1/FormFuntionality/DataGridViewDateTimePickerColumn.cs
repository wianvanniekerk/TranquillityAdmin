using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.FormFuntionality
{
    internal class DataGridViewDateTimePickerColumn : DataGridViewColumn
    {
        public bool IncludeTime { get; set; }
        public string DateFormat { get; set; }

        public DataGridViewDateTimePickerColumn() : base(new DataGridViewDateTimePickerCell())
        {
        }

        public DataGridViewDateTimePickerColumn(bool includeTime = false) : base(new DataGridViewDateTimePickerCell())
        {
            IncludeTime = includeTime;
            DateFormat = includeTime ? "yyyy-MM-dd HH:mm:ss" : "yyyy-MM-dd";
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewDateTimePickerCell)))
                {
                    throw new InvalidCastException("Must be a DataGridViewDateTimePickerCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    public class DataGridViewDateTimePickerCell : DataGridViewTextBoxCell
    {
        public DataGridViewDateTimePickerCell() : base()
        {
            this.Style.Format = "G";
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            DateTimePickerEditingControl ctl = DataGridView.EditingControl as DateTimePickerEditingControl;
            DataGridViewDateTimePickerColumn owningColumn = OwningColumn as DataGridViewDateTimePickerColumn;

            if (owningColumn != null)
            {
                ctl.IncludeTime = owningColumn.IncludeTime;
                ctl.CustomFormat = owningColumn.DateFormat;
            }

            if (this.Value == null || this.Value == DBNull.Value)
            {
                ctl.Value = DateTime.Now;
                ctl.CustomFormat = " ";
            }
            else
            {
                ctl.Value = (DateTime)this.Value;
            }
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            if (value != null && value != DBNull.Value)
            {
                DataGridViewDateTimePickerColumn owningColumn = OwningColumn as DataGridViewDateTimePickerColumn;
                if (owningColumn != null)
                {
                    formattedValue = ((DateTime)value).ToString(owningColumn.DateFormat);
                }
            }
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
        }


        public override Type EditType
        {
            get
            {
                return typeof(DateTimePickerEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(DateTime);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                return DBNull.Value;
            }
        }
    }

    class DateTimePickerEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;
        public bool IncludeTime { get; set; }

        public DateTimePickerEditingControl()
        {
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = " ";
        }

        public object EditingControlFormattedValue
        {
            get
            {
                if (this == null || this.Value == null || this.CustomFormat == null)
                {
                    return DBNull.Value;
                }

                if (this.Value == this.MinDate || string.IsNullOrWhiteSpace(this.CustomFormat))
                {
                    return DBNull.Value;
                }
                else
                {
                    return this.IncludeTime ? this.Value.ToString("yyyy-MM-dd HH:mm:ss") : this.Value.ToString("yyyy-MM-dd");
                }
            }
            set
            {
                if (value is string stringValue)
                {
                    if (DateTime.TryParse(stringValue, out DateTime result))
                    {
                        this.Value = result;
                        this.CustomFormat = this.IncludeTime ? "yyyy-MM-dd HH:mm:ss" : "yyyy-MM-dd";
                    }
                    else
                    {
                        this.Value = DateTime.Now;
                        this.CustomFormat = " ";
                    }
                }
            }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
            this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

        public int EditingControlRowIndex
        {
            get { return rowIndex; }
            set { rowIndex = value; }
        }

        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            if (this.Value == this.MinDate)
            {
                this.Value = DateTime.Now;
                this.CustomFormat = "yyyy/MM/dd";
            }
        }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }

        public DataGridView EditingControlDataGridView
        {
            get { return dataGridView; }
            set { dataGridView = value; }
        }

        public bool EditingControlValueChanged
        {
            get { return valueChanged; }
            set { valueChanged = value; }
        }

        public Cursor EditingPanelCursor
        {
            get { return base.Cursor; }
        }

        protected override void OnValueChanged(EventArgs eventargs)
        {
            this.CustomFormat = this.IncludeTime ? "yyyy-MM-dd HH:mm:ss" : "yyyy-MM-dd";

            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }

    }
}
