namespace TestForm
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button4 = new System.Windows.Forms.Button();
            this.text_b = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.text_shadowThick = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.text_bdradius = new System.Windows.Forms.TextBox();
            this.userDgv = new MyDataGridView.UserControl1();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 315);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add ComboBox Row";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(100, 353);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 32);
            this.button2.TabIndex = 2;
            this.button2.Text = "Add DateTime Row";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(318, 308);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(143, 34);
            this.button3.TabIndex = 3;
            this.button3.Text = "SetBorderColor";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(100, 262);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(152, 21);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "SelectOnlyOneRow";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(318, 353);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(217, 32);
            this.button4.TabIndex = 5;
            this.button4.Text = "Set Border thickness";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // text_b
            // 
            this.text_b.Location = new System.Drawing.Point(541, 358);
            this.text_b.Name = "text_b";
            this.text_b.Size = new System.Drawing.Size(100, 22);
            this.text_b.TabIndex = 6;
            this.text_b.Text = "2";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(690, 306);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(143, 36);
            this.button5.TabIndex = 7;
            this.button5.Text = "Set Shadow Color";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // text_shadowThick
            // 
            this.text_shadowThick.Location = new System.Drawing.Point(913, 363);
            this.text_shadowThick.Name = "text_shadowThick";
            this.text_shadowThick.Size = new System.Drawing.Size(100, 22);
            this.text_shadowThick.TabIndex = 9;
            this.text_shadowThick.Text = "60";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(690, 358);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(217, 32);
            this.button6.TabIndex = 8;
            this.button6.Text = "Set Shadow thick";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(318, 407);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(143, 31);
            this.button7.TabIndex = 10;
            this.button7.Text = "Set Border Radius";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Button7_Click);
            // 
            // text_bdradius
            // 
            this.text_bdradius.Location = new System.Drawing.Point(467, 411);
            this.text_bdradius.Name = "text_bdradius";
            this.text_bdradius.Size = new System.Drawing.Size(100, 22);
            this.text_bdradius.TabIndex = 11;
            this.text_bdradius.Text = "5";
            // 
            // userDgv
            // 
            this.userDgv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.userDgv.Location = new System.Drawing.Point(100, 67);
            this.userDgv.Name = "userDgv";
            this.userDgv.Padding = new System.Windows.Forms.Padding(5);
            this.userDgv.Radius = 0;
            this.userDgv.Size = new System.Drawing.Size(865, 159);
            this.userDgv.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 450);
            this.Controls.Add(this.userDgv);
            this.Controls.Add(this.text_bdradius);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.text_shadowThick);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.text_b);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox text_b;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox text_shadowThick;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox text_bdradius;
        private MyDataGridView.UserControl1 userDgv;
    }
}

