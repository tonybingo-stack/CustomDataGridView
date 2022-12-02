using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MyDataGridView
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        /// 

        [DefaultValue(5)]
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private GraphicsPath GetRoundRectagle(Rectangle bounds, int radius)
        {
            float r = radius;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(bounds.Left, bounds.Top, r, r, 180, 90);
            path.AddArc(bounds.Right - r, bounds.Top, r, r, 270, 90);
            path.AddArc(bounds.Right - r, bounds.Bottom - r, r, r, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - r, r, r, 90, 90);
            path.CloseFigure();
            return path;
        }
        public int Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                this.RecreateRegion();
            }
        }
        private void RecreateRegion()
        {
            var bounds = ClientRectangle;
            //Better round rectangle
            this.Region = Region.FromHrgn(CreateRoundRectRgn(bounds.Left, bounds.Top,
                bounds.Right, bounds.Bottom, Radius, radius));
            this.Invalidate();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.RecreateRegion();
        }


        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MyDataGridView = new System.Windows.Forms.DataGridView();
            this.myCheckBoxColumn = new MyDataGridView.MyCheckBoxColumn();
            this.Text_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Text_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userControl = new MyDataGridView.CalendarColumn();
            this.Action = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.myCheckBoxColumn1 = new MyDataGridView.MyCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MyDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MyDataGridView
            // 
            this.MyDataGridView.AllowUserToAddRows = false;
            this.MyDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MyDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.MyDataGridView.ColumnHeadersHeight = 30;
            this.MyDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.myCheckBoxColumn,
            this.Text_Id,
            this.Text_Name,
            this.userControl,
            this.Action});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MyDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.MyDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MyDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.MyDataGridView.Location = new System.Drawing.Point(5, 5);
            this.MyDataGridView.Name = "MyDataGridView";
            this.MyDataGridView.RowHeadersWidth = 51;
            this.MyDataGridView.RowTemplate.Height = 24;
            this.MyDataGridView.Size = new System.Drawing.Size(855, 149);
            this.MyDataGridView.TabIndex = 0;
            this.MyDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MyDataGridView_CellContentClick);
            // 
            // myCheckBoxColumn
            // 
            this.myCheckBoxColumn.HeaderText = "";
            this.myCheckBoxColumn.MinimumWidth = 6;
            this.myCheckBoxColumn.Name = "myCheckBoxColumn";
            // 
            // Text_Id
            // 
            this.Text_Id.HeaderText = "ID";
            this.Text_Id.MinimumWidth = 6;
            this.Text_Id.Name = "Text_Id";
            this.Text_Id.ReadOnly = true;
            // 
            // Text_Name
            // 
            this.Text_Name.HeaderText = "Name";
            this.Text_Name.MinimumWidth = 6;
            this.Text_Name.Name = "Text_Name";
            this.Text_Name.ReadOnly = true;
            // 
            // userControl
            // 
            this.userControl.HeaderText = "Control";
            this.userControl.MinimumWidth = 6;
            this.userControl.Name = "userControl";
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.MinimumWidth = 6;
            this.Action.Name = "Action";
            // 
            // myCheckBoxColumn1
            // 
            this.myCheckBoxColumn1.HeaderText = "";
            this.myCheckBoxColumn1.MinimumWidth = 6;
            this.myCheckBoxColumn1.Name = "myCheckBoxColumn1";
            this.myCheckBoxColumn1.Width = 123;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 123;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 124;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.HeaderText = "Action";
            this.dataGridViewComboBoxColumn1.MinimumWidth = 6;
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Width = 123;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.MyDataGridView);
            this.Name = "UserControl1";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(865, 159);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MyDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView MyDataGridView;
        private MyCheckBoxColumn myCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private MyCheckBoxColumn myCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Text_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Text_Name;
        private CalendarColumn userControl;
        private System.Windows.Forms.DataGridViewComboBoxColumn Action;
        private int radius;
    }
}
