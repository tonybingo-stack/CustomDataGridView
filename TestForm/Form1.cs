using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestForm
{
    public partial class Form1 : Form
    {
        List<Control> shadowControls = new List<Control>();
        Bitmap shadowBmp = null;
        Color shadowColor;
        int shadowThickness;
        public Form1()
        {
            InitializeComponent();
            shadowControls.Add(userDgv);
            shadowThickness = 60;

            shadowColor = Color.FromArgb(0, 0, 0);
            this.Refresh();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (shadowBmp == null || shadowBmp.Size != this.Size)
            {
                shadowBmp?.Dispose();
                shadowBmp = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppArgb);
            }
            foreach (Control control in shadowControls)
            {
                using (GraphicsPath gp = new GraphicsPath())
                {
                    gp.AddRectangle(new Rectangle(control.Location.X, control.Location.Y, control.Size.Width, control.Size.Height));
                    DrawShadowSmooth(gp, 100, shadowThickness, shadowBmp, shadowColor);
                }
                e.Graphics.DrawImage(shadowBmp, new Point(0, 0));
            }
        }
        private static void DrawShadowSmooth(GraphicsPath gp, int intensity, int radius, Bitmap dest, Color c)
        {
            using (Graphics g = Graphics.FromImage(dest))
            {
                g.Clear(Color.Transparent);
                g.CompositingMode = CompositingMode.SourceCopy;
                double alpha = 0;
                double astep = 0;
                double astepstep = (double)intensity / radius / (radius / 2D);
                for (int thickness = radius; thickness > 0; thickness--)
                {
                    using (Pen p = new Pen(Color.FromArgb((int)alpha, (int)c.R, (int)c.G, (int)c.B), thickness))
                    {
                        p.LineJoin = LineJoin.Round;
                        g.DrawPath(p, gp);
                    }
                    alpha += astep;
                    astep += astepstep;
                }
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            this.userDgv.AddNewRow("ID1", "Name1", "ComboBox", "");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.userDgv.AddNewRow("ID2", "Name2", "DateTimePicker", "");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(this.userDgv.RowControlSaveDataByIndex(0));
            //this.userDgv.RowControlLoadDataByIndex(1, "true:testID:testName:DateTimePicker");
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.userDgv.SetBorderColor(colorDialog1.Color);
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ch = sender as CheckBox;
            this.userDgv.EnableSelectOnlyOneRow(ch.Checked);
        }

        private void UserDgv_Load(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.userDgv.SetBorderThickness(Int32.Parse(this.text_b.Text));
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.shadowColor = colorDialog1.Color;
                this.Invalidate();
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            this.shadowThickness = Int32.Parse(this.text_shadowThick.Text);
            Invalidate();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            this.userDgv.SetBorderRadius(Int32.Parse(this.text_bdradius.Text));
        }
    }
}
