using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            String[] arr = new String[] { "红", "黄", "蓝" };
            for (int i = 0; i < arr.Length; i++)
            {
                comboBox1.Items.Add(arr[i]);
            }
        }

        private Graphics graphics;
        double th1;
        double th2;
        double per1;
        double per2;
        Pen color;

        Pen colorPen(string str)
        {
            Pen result;
            if (str == "蓝")
                result = Pens.Blue;
            else if (str == "黄")
                result = Pens.Yellow;
            else if (str == "红")
                result = Pens.Red;
            else
                result = Pens.Blue;
            return result;
        }
        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0)
                return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            graphics.DrawLine(color, (int)x0, (int)y0, (int)x1, (int)y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }
        void CheckInput(TextBox tbox, string dft)
        {
            try
            {
                double i = double.Parse(tbox.Text);
                if (i < 0)
                    tbox.Text = dft;
            }
            catch { tbox.Text = dft; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text);
            double len = double.Parse(textBox2.Text);
            per1 = double.Parse(textBox3.Text);
            per2 = double.Parse(textBox4.Text);
            th1 = double.Parse(textBox5.Text) * Math.PI / 180;
            th2 = double.Parse(textBox6.Text) * Math.PI / 180;
            color = colorPen(comboBox1.Text);
            if (graphics == null)
                graphics = this.panel1.CreateGraphics();
            graphics.Clear(Color.White);
            drawCayleyTree(n, 200, 310, len, -Math.PI / 2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int i = int.Parse(textBox1.Text);
                if (i < 0)
                    textBox1.Text = "10";
            }
            catch
            {
                textBox1.Text = "10";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CheckInput(textBox2, "100");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            CheckInput(textBox3, "0.6");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            CheckInput(textBox4, "0.7");
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            CheckInput(textBox5, "30");
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            CheckInput(textBox6, "20");
        }
    }
}
