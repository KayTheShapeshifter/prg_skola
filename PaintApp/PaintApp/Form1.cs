using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintApp
{
    public partial class Form1 : Form
    {
        
        public Point prevPoint;
        public bool mouseDown = false;
        int size = 1;
        Graphics g;
        int brushType = 1;
        static int red = 0;
        static int green = 0;
        static int blue = 0;
        Pen pen;
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            InitPen();
            MessageBox.Show("Vítej u mého velice jednoduchého a pozdě odevzdaného programu Paint. Štětce změníš kliknutím na různé 'brush' tlačítka. Tloušťku změníš bílým sliderem . Barvu změníš barevnými RGB slidery.");
        }
        public void InitPen()
        {
            //SolidBrush brush = new SolidBrush(Color.FromArgb(1, 200, green, blue));
            Color color = Color.FromArgb(255, red, green, blue);
            pen = new Pen(color);
            pen.Width = size;
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            if (brushType == 2)
            {
                prevPoint = e.Location;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = e.Location;
            switch (brushType)
            {
                case 1:
                    if (mouseDown)
                    {
                        g.DrawLine(pen, prevPoint, point);
                    }
                    prevPoint = e.Location;
                    break;
                case 2:
                    if (mouseDown)
                    {
                        g.DrawLine(pen, prevPoint, point);
                    }
                    break;
                default:
                    break;
            }

        }

        private void changeBrush1_Click(object sender, EventArgs e)
        {
            brushType = 1;
        }

        private void changeBrush2_Click(object sender, EventArgs e)
        {
            brushType = 2;
        }

        private void sliderRed_Scroll(object sender, EventArgs e)
        {
            red = sliderRed.Value;
            labelRed.Text = red.ToString();
            InitPen();
        }

        private void sliderGreen_Scroll(object sender, EventArgs e)
        {
            green = sliderGreen.Value;
            labelGreen.Text = green.ToString();
            InitPen();
        }

        private void sliderBlue_Scroll(object sender, EventArgs e)
        {
            blue = sliderBlue.Value;
            labelBlue.Text = blue.ToString();
            InitPen();
        }

        private void sliderWidth_Scroll(object sender, EventArgs e)
        {
            size = sliderWidth.Value;
            labelWidth.Text = size + "pt";
            InitPen();
        }
    }
}
