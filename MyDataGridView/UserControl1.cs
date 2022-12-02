using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MyDataGridView
{
    public partial class UserControl1 : UserControl
    {
        private bool selectOnlyOneRow;

        public UserControl1()
        {
            InitializeComponent();
            selectOnlyOneRow = false;

            MyDataGridView.RowHeadersVisible = false;
            MyDataGridView.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView_EditingControlShowing);
        }
        // Style method for border
        public void SetBorderRadius(int radius)
        {
            this.radius = radius;
            this.RecreateRegion();
        }
        public void SetBorderThickness(int borderThickness)
        {
            this.Padding = new System.Windows.Forms.Padding(borderThickness);
        }
        public void SetBorderColor(Color color)
        {
            this.BackColor = color;
        }
        public void EnableSelectOnlyOneRow(bool flag)
        {
            selectOnlyOneRow = flag;
            this.myCheckBoxColumn.EnableHeaderCheckBox(flag);
        }
        private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        { 
            ComboBox combo = e.Control as ComboBox;
            
            if (combo != null)
            {
                combo.SelectedIndexChanged -= new EventHandler(ActionColumnSelected);
                combo.SelectedIndexChanged += new EventHandler(ActionColumnSelected);
            }
        }

        private void ActionColumnSelected(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            string item = cb.Text;
            int rowIndex = MyDataGridView.CurrentCell.RowIndex;
            
            if(MyDataGridView.Rows[rowIndex].Cells[3].GetType() == typeof(MyDataGridView.CalendarCell))
            {
                if(cb.SelectedIndex == 1)
                {
                    MyDataGridView.Rows[rowIndex].Cells[3].Value = DateTime.Now.AddDays(0);
                }
                else if(cb.SelectedIndex == 2)
                {
                    MyDataGridView.Rows[rowIndex].Cells[3].Value = DateTime.Now.AddDays(7);
                }
                else
                {

                }
                
            }
            else if(MyDataGridView.Rows[rowIndex].Cells[3].GetType() == typeof(DataGridViewComboBoxCell))
            {
                if (cb.SelectedIndex == 1)
                {
                    MyDataGridView.Rows[rowIndex].Cells[3].Value = "Yes";
                }
                else if (cb.SelectedIndex == 2)
                {
                    MyDataGridView.Rows[rowIndex].Cells[3].Value = "No";
                }
                else
                {

                }
            }
            cb.SelectedIndex = 0;
        }

        public List<DataGridViewCell> GetAllControls()
        {
            List<DataGridViewCell> res = new List<DataGridViewCell>();
            foreach(DataGridViewRow row in this.MyDataGridView.Rows)
            {
                res.Add(row.Cells[3]);
            }
            return res;
        }
        public DataGridViewCell GetControlById(string id)
        {
            int rowindex = GetIndexByID(id);
            return GetControlByIndex(rowindex);
        }
        public DataGridViewCell GetControlByIndex(int index)
        {
            //mydatagridview.rows[id].
            return this.MyDataGridView.Rows[index].Cells[3];
        }
        public List<DataGridViewCell> GetCheckedControl()
        {
            List<DataGridViewCell> result = new List<DataGridViewCell>();
            foreach (DataGridViewRow row in this.MyDataGridView.Rows)
            {
                if ((bool)row.Cells[0].Value) result.Add(row.Cells[3]);
            }
            return result;
        }
        public int GetIndexByID(String ID)
        {
            int rowIndex = -1;
            foreach(DataGridViewRow row in MyDataGridView.Rows)
            {
                if (row.Cells[1].Value.ToString() != ID)
                {
                    continue;
                }
                rowIndex = row.Index;
                break;
            }
            return rowIndex;
        }
        public string RowControlSaveDataById(string ID)
        {
            int rowIndex = GetIndexByID(ID);
            return RowControlSaveDataByIndex(rowIndex);
        }
        public string RowControlSaveDataByIndex(int index)
        {
            string result;
            DataGridViewRow row = this.MyDataGridView.Rows[index];
            result = row.Cells[0].Value.ToString() + ":" + row.Cells[1].Value.ToString() + ":" + row.Cells[2].Value.ToString() +
                ":" + row.Cells[3].GetType().ToString();
            return result;
        }
        public void RowControlLoadDataById(string ID, string data)
        {
            int rowIndex = GetIndexByID(ID);
            RowControlLoadDataByIndex(rowIndex, data);
        }
        public void RowControlLoadDataByIndex(int rowIndex, string data)
        {
            string[] res = data.Split(':');

            DataGridViewRow rw = new DataGridViewRow();
            this.MyDataGridView.Rows.RemoveAt(rowIndex);
            this.MyDataGridView.Rows.Insert(rowIndex, rw);

            DataGridViewRow row = this.MyDataGridView.Rows[rowIndex];
            row.Cells[0].Value = res[0];
            row.Cells[1].Value = res[1];
            row.Cells[2].Value = res[2];
            row.Cells[3].Value = DateTime.Now;

            if (res[3] == "ComboBox")
            {
                DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell();
                comboBoxCell.Items.AddRange(new string[] { "Yes", "No" });
                this.MyDataGridView[3, rowIndex] = comboBoxCell;
                this.MyDataGridView[3, rowIndex].Value = "";

                DataGridViewComboBoxCell ActionCell = new DataGridViewComboBoxCell();
                ActionCell.Items.AddRange(new string[] { "Select an action", "Yes", "No" });
                this.MyDataGridView[4, rowIndex] = ActionCell;
                this.MyDataGridView[4, rowIndex].Value = "Select an action";
            }
            else if (res[3] == "DateTimePicker")
            {
                DataGridViewComboBoxCell ActionCell = new DataGridViewComboBoxCell();
                ActionCell.Items.AddRange(new string[] { "Select an action", "Today", "Today+7d" });
                this.MyDataGridView[4, rowIndex] = ActionCell;
                this.MyDataGridView[4, rowIndex].Value = "Select an action";
            }
            else
            {
                MessageBox.Show("Unsupported control!");
            }
        }
        public int AddNewRow(string ID, string Name, String mpcControlType, String mpcControlSetting)
        {
            int rowIndex = this.MyDataGridView.RowCount;

            if (mpcControlType == "ComboBox")
            {
                this.MyDataGridView.Rows.Add(false, ID, Name);

                DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell();
                comboBoxCell.Items.AddRange(new string[] { "Yes","No" });
                this.MyDataGridView[3, rowIndex] = comboBoxCell;
                this.MyDataGridView[3, rowIndex].Value = "";

                DataGridViewComboBoxCell ActionCell = new DataGridViewComboBoxCell();
                ActionCell.Items.AddRange(new string[] { "Select an action", "Yes", "No" });
                this.MyDataGridView[4, rowIndex] = ActionCell;
                this.MyDataGridView[4, rowIndex].Value = "Select an action";
            }
            else if(mpcControlType == "DateTimePicker")
            {
                this.MyDataGridView.Rows.Add(false, ID, Name, DateTime.Now);

                DataGridViewComboBoxCell ActionCell = new DataGridViewComboBoxCell();
                ActionCell.Items.AddRange(new string[] { "Select an action", "Today", "Today+7d" });
                this.MyDataGridView[4, rowIndex] = ActionCell;
                this.MyDataGridView[4, rowIndex].Value = "Select an action";
            }

            return rowIndex;
        }
        private void MyDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != 0) return;

            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)MyDataGridView.Rows[MyDataGridView.CurrentRow.Index].Cells[0];

            if (ch1.Value == null) ch1.Value = false;

            if (selectOnlyOneRow)
            {
                foreach (DataGridViewRow row in MyDataGridView.Rows)
                {
                    row.Cells[0].Value = false;
                }
            }

            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;
                    break;
                case "False":
                    ch1.Value = true;
                    break;
            }
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
    }

    // First Column
    #region GridViewCheckBoxColumn

    [System.Drawing.ToolboxBitmap(typeof(System.Windows.Forms.DataGridViewCheckBoxColumn))]
    public class MyCheckBoxColumn : DataGridViewCheckBoxColumn
    {
        private bool enableOnlyOneRow;
        #region Constructor
        public MyCheckBoxColumn()
        {
            DatagridViewCheckBoxHeaderCell datagridViewCheckBoxHeaderCell = new DatagridViewCheckBoxHeaderCell();

            this.HeaderCell = datagridViewCheckBoxHeaderCell;
            this.Width = 50;
            enableOnlyOneRow = false;

            //this.DataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grvList_CellFormatting);
            datagridViewCheckBoxHeaderCell.OnCheckBoxClicked += new CheckBoxClickedHandler(datagridViewCheckBoxHeaderCell_OnCheckBoxClicked);

        }

        #endregion

        #region Methods
        public void EnableHeaderCheckBox(bool flag)
        {
            enableOnlyOneRow = flag;
        }
        void datagridViewCheckBoxHeaderCell_OnCheckBoxClicked(int columnIndex, bool state)
        {
            DataGridView.RefreshEdit();
            // Select or Disselect all checkbox
            if (!enableOnlyOneRow)
            {
                foreach (DataGridViewRow row in DataGridView.Rows)
                {
                    row.Cells[0].Value = state;
                }
            }

            DataGridView.RefreshEdit();
        }

        #endregion
    }
    #endregion

    #region DatagridViewCheckBoxHeaderCell
    public delegate void CheckBoxClickedHandler(int columnIndex, bool state);
    public class DataGridViewCheckBoxHeaderCellEventArgs : EventArgs
    {
        bool _bChecked;
        public DataGridViewCheckBoxHeaderCellEventArgs(int columnIndex, bool bChecked)
        {
            _bChecked = bChecked;
        }
        public bool Checked
        {
            get { return _bChecked; }
        }
    }
    class DatagridViewCheckBoxHeaderCell : DataGridViewColumnHeaderCell
    {
        Point checkBoxLocation;
        Size checkBoxSize;
        bool _checked = false;
        Point _cellLocation = new Point();
        System.Windows.Forms.VisualStyles.CheckBoxState _cbState =
        System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal;
        public event CheckBoxClickedHandler OnCheckBoxClicked;

        public DatagridViewCheckBoxHeaderCell()
        {
        }

        protected override void Paint(System.Drawing.Graphics graphics,
        System.Drawing.Rectangle clipBounds,
        System.Drawing.Rectangle cellBounds,
        int rowIndex,
        DataGridViewElementStates dataGridViewElementState,
        object value,
        object formattedValue,
        string errorText,
        DataGridViewCellStyle cellStyle,
        DataGridViewAdvancedBorderStyle advancedBorderStyle,
        DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex,
            dataGridViewElementState, value,
            formattedValue, errorText, cellStyle,
            advancedBorderStyle, paintParts);
            Point p = new Point();
            Size s = CheckBoxRenderer.GetGlyphSize(graphics,
            System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            p.X = cellBounds.Location.X +
            (cellBounds.Width / 2) - (s.Width / 2);
            p.Y = cellBounds.Location.Y +
            (cellBounds.Height / 2) - (s.Height / 2);
            _cellLocation = cellBounds.Location;
            checkBoxLocation = p;
            checkBoxSize = s;
            if (_checked)
                _cbState = System.Windows.Forms.VisualStyles.
                CheckBoxState.CheckedNormal;
            else
                _cbState = System.Windows.Forms.VisualStyles.
                CheckBoxState.UncheckedNormal;
            CheckBoxRenderer.DrawCheckBox
            (graphics, checkBoxLocation, _cbState);
        }

        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            Point p = new Point(e.X + _cellLocation.X, e.Y + _cellLocation.Y);
            if (p.X >= checkBoxLocation.X && p.X <=
            checkBoxLocation.X + checkBoxSize.Width
            && p.Y >= checkBoxLocation.Y && p.Y <=
            checkBoxLocation.Y + checkBoxSize.Height)
            {
                _checked = !_checked;
                if (OnCheckBoxClicked != null)
                {
                    OnCheckBoxClicked(e.ColumnIndex, _checked);
                    this.DataGridView.InvalidateCell(this);
                }
            }
            base.OnMouseClick(e);
        }

    }
    #endregion
    #region ColumnSelection
    class DataGridViewColumnSelector
    {
        // the DataGridView to which the DataGridViewColumnSelector is attached
        private DataGridView mDataGridView = null;
        // a CheckedListBox containing the column header text and checkboxes
        private CheckedListBox mCheckedListBox;
        // a ToolStripDropDown object used to show the popup
        private ToolStripDropDown mPopup;

        /// <summary>
        /// The max height of the popup
        /// </summary>
        public int MaxHeight = 300;
        /// <summary>
        /// The width of the popup
        /// </summary>
        public int Width = 200;

        /// <summary>
        /// Gets or sets the DataGridView to which the DataGridViewColumnSelector is attached
        /// </summary>
        public DataGridView DataGridView
        {
            get { return mDataGridView; }
            set
            {
                // If any, remove handler from current DataGridView 
                if (mDataGridView != null) mDataGridView.CellMouseClick -= new DataGridViewCellMouseEventHandler(mDataGridView_CellMouseClick);
                // Set the new DataGridView
                mDataGridView = value;
                // Attach CellMouseClick handler to DataGridView
                if (mDataGridView != null) mDataGridView.CellMouseClick += new DataGridViewCellMouseEventHandler(mDataGridView_CellMouseClick);
            }
        }

        // When user right-clicks the cell origin, it clears and fill the CheckedListBox with
        // columns header text. Then it shows the popup. 
        // In this way the CheckedListBox items are always refreshed to reflect changes occurred in 
        // DataGridView columns (column additions or name changes and so on).
        void mDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                mCheckedListBox.Items.Clear();
                foreach (DataGridViewColumn c in mDataGridView.Columns)
                {
                    mCheckedListBox.Items.Add(c.HeaderText, c.Visible);
                }
                int PreferredHeight = (mCheckedListBox.Items.Count * 16) + 7;
                mCheckedListBox.Height = (PreferredHeight < MaxHeight) ? PreferredHeight : MaxHeight;
                mCheckedListBox.Width = this.Width;
                mPopup.Show(mDataGridView.PointToScreen(new Point(e.X, e.Y)));
            }
        }

        // The constructor creates an instance of CheckedListBox and ToolStripDropDown.
        // the CheckedListBox is hosted by ToolStripControlHost, which in turn is
        // added to ToolStripDropDown.
        public DataGridViewColumnSelector()
        {
            mCheckedListBox = new CheckedListBox();
            mCheckedListBox.CheckOnClick = true;
            mCheckedListBox.ItemCheck += new ItemCheckEventHandler(mCheckedListBox_ItemCheck);

            ToolStripControlHost mControlHost = new ToolStripControlHost(mCheckedListBox);
            mControlHost.Padding = Padding.Empty;
            mControlHost.Margin = Padding.Empty;
            mControlHost.AutoSize = false;

            mPopup = new ToolStripDropDown();
            mPopup.Padding = Padding.Empty;
            mPopup.Items.Add(mControlHost);
        }

        public DataGridViewColumnSelector(DataGridView dgv)
            : this()
        {
            this.DataGridView = dgv;
        }

        // When user checks / unchecks a checkbox, the related column visibility is 
        // switched.
        void mCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            mDataGridView.Columns[e.Index].Visible = (e.NewValue == CheckState.Checked);
        }
    }
    #endregion


    // Custom column
    public class CalendarColumn : DataGridViewColumn
    {
        public CalendarColumn() : base(new CalendarCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a CalendarCell.
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
                {
                    throw new InvalidCastException("Must be a CalendarCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    public class CalendarCell : DataGridViewTextBoxCell
    {

        public CalendarCell()
            : base()
        {
            // Use the short date format.
            this.Style.Format = "d";
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            CalendarEditingControl ctl =
                DataGridView.EditingControl as CalendarEditingControl;
            // Use the default row value when Value property is null.
            if (this.Value == null)
            {
                ctl.Value = (DateTime)this.DefaultNewRowValue;
            }
            else
            {
                ctl.Value = (DateTime)this.Value;
            }
        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing control that CalendarCell uses.
                return typeof(CalendarEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that CalendarCell contains.

                return typeof(DateTime);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Use the current date and time as the default value.
                return DateTime.Now;
            }
        }
    }

    class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int rowIndex;

        public CalendarEditingControl()
        {
            this.Format = DateTimePickerFormat.Short;
        }

        // Implements the IDataGridViewEditingControl.EditingControlFormattedValue
        // property.
        public object EditingControlFormattedValue
        {
            get
            {
                return this.Value.ToShortDateString();
            }
            set
            {
                if (value is String)
                {
                    try
                    {
                        // This will throw an exception of the string is
                        // null, empty, or not in the format of a date.
                        this.Value = DateTime.Parse((String)value);
                    }
                    catch
                    {
                        // In the case of an exception, just use the
                        // default value so we're not left with a null
                        // value.
                        this.Value = DateTime.Now;
                    }
                }
            }
        }

        // Implements the
        // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
        public object GetEditingControlFormattedValue(
            DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        // Implements the
        // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
        public void ApplyCellStyleToEditingControl(
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
            this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

        // Implements the IDataGridViewEditingControl.EditingControlRowIndex
        // property.
        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey
        // method.
        public bool EditingControlWantsInputKey(
            Keys key, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed.
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

        // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit
        // method.
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // No preparation needs to be done.
        }

        // Implements the IDataGridViewEditingControl
        // .RepositionEditingControlOnValueChange property.
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlDataGridView property.
        public DataGridView EditingControlDataGridView
        {
            get
            {
                return dataGridView;
            }
            set
            {
                dataGridView = value;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingControlValueChanged property.
        public bool EditingControlValueChanged
        {
            get
            {
                return valueChanged;
            }
            set
            {
                valueChanged = value;
            }
        }

        // Implements the IDataGridViewEditingControl
        // .EditingPanelCursor property.
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        protected override void OnValueChanged(EventArgs eventargs)
        {
            // Notify the DataGridView that the contents of the cell
            // have changed.
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }
    }
}
