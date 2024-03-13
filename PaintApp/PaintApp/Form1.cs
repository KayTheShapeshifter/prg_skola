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
        Pen pen = Pens.Black;
        public Point prevPoint;
        public bool mouseDown = false;
        int size = 3;
        Graphics g;
        int brushType = 1;
        static int red = 0;
        static int green = 0;
        static int blue = 0;
        Brush brush;
        

        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            brush = Color.FromArgb(1, red, green, blue);
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
        }
    }
}
