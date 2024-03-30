using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintApp
{
    public partial class Form1 : Form
    {
        public Image insertedImage;
        public Point prevPoint;
        public bool mouseDown = false;
        int size = 1;
        Graphics g;
        int brushType = 1;
        static int red = 0;
        static int green = 0;
        static int blue = 0;
        Pen pen;
        SolidBrush brush;
        public Point point;
        public int shapeWidth = 0;
        public int shapeHeight = 0;
        public bool fillShape = true;

        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            InitPen();
            this.DoubleBuffered = true;
            MessageBox.Show("Vítej u mého velice jednoduchého a pozdě odevzdaného programu Paint. Štětce změníš kliknutím na různé 'brush' tlačítka. Tloušťku změníš bílým sliderem . Barvu změníš barevnými RGB slidery.");
        }
        public void InitPen()
        {
            Color color = Color.FromArgb(255, red, green, blue);
            pen = new Pen(color);
            pen.Width = size;

            brush = new SolidBrush(color);
        }
        public void CalculateShapeMiddle()
        {
            prevPoint = point;
            point = new Point(point.X - (int)(0.5 * shapeWidth), point.Y - (int)(0.5 * shapeHeight));
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            switch (brushType)
            {
                case 2:
                    prevPoint = e.Location;
                    break;
                case 4:
                    CalculateShapeMiddle();
                    if (fillShape)
                    {
                        g.FillRectangle(brush, point.X, point.Y, shapeWidth, shapeHeight);
                    }
                    else
                    {
                        g.DrawRectangle(pen, point.X, point.Y, shapeWidth, shapeHeight);
                    }
                    point = prevPoint; //entered this because it did shenanigans while double clicking
                    break;
                case 5:
                    CalculateShapeMiddle();
                    if (fillShape)
                    {
                        g.FillEllipse(brush, point.X, point.Y, shapeWidth, shapeHeight);
                    }
                    else
                    {
                        g.DrawEllipse(pen, point.X, point.Y, shapeWidth, shapeHeight);
                    }
                    point = prevPoint;
                    break;
                default:
                    break;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            point = e.Location;
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
                case 3:
                    if (mouseDown)
                    {
                        g.FillRectangle(Brushes.White, point.X, point.Y, size, size); //eraser works by creating many squares when moving mouse
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
        private void changeEraser_Click(object sender, EventArgs e)
        {
            brushType = 3;
        }
        private void changeRectangle_Click(object sender, EventArgs e)
        {
            brushType = 4;
        }
        private void changeElipse_Click(object sender, EventArgs e)
        {
            brushType = 5;
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

        private void insertImage_Click(object sender, EventArgs e) //chatgpt
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Load the selected image
                    insertedImage = Image.FromFile(openFileDialog.FileName);
                    // Redraw the form to display the inserted image
                    this.Invalidate();
                }
            }
        }
        protected override void OnPaint(PaintEventArgs e) //chatgpt
        {
            base.OnPaint(e);
            // Draw the inserted image if available
            if (insertedImage != null)
            {
                e.Graphics.DrawImage(insertedImage, Point.Empty);
            }
        }

        private void textboxShapeWidth_KeyPress(object sender, KeyPressEventArgs e) //checks if user is putting down nums
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) //iscontroll because otherwise you couldnt backspace
            {
                e.Handled = true;
                MessageBox.Show("Enter only numbers");
            }
        }

        private void textboxShapeHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Enter only numbers");
            }
        }

        private void textboxShapeWidth_TextChanged(object sender, EventArgs e)
        {
            shapeWidth = Convert.ToInt32(textboxShapeWidth.Text);
        }

        private void textboxShapeHeight_TextChanged(object sender, EventArgs e)
        {
            shapeHeight = Convert.ToInt32(textboxShapeHeight.Text);
        }

        private void buttonFillShape_Click(object sender, EventArgs e)
        {
            if (fillShape)
            {
                fillShape = false;
                buttonFillShape.Text = "Fill: No";
            }
            else
            {
                fillShape = true;
                buttonFillShape.Text = "Fill: Yes";
            }
        }
    }
}
