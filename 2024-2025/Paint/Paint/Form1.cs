using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.VisualBasic.FileIO;
namespace Paint
{
    public partial class Form1 : Form //napsal jsem vetsinu sam a po tom, co jsem delal funkce na rectangle tak se mi nechtelo delat ellipse, tak jsem to vzal z chatgpt - proto velice AI formatovani
    {
        public bool isDrawing = false;
        public List<Point> points = new List<Point>();

        // Freehand drawing storage
        public List<List<Point>> storedLines = new List<List<Point>>();
        public List<Color> lineColors = new List<Color>();
        public List<int> lineThickness = new List<int>();

        // Filled shapes storage
        public List<List<Point>> storedRectangles = new List<List<Point>>();
        public List<Color> rectangleColors = new List<Color>();
        public List<List<Point>> storedEllipses = new List<List<Point>>();
        public List<Color> ellipseColors = new List<Color>();

        // Outline (no fill) shapes storage
        public List<List<Point>> storedRectanglesNoFill = new List<List<Point>>();
        public List<Color> rectangleNoFillColors = new List<Color>();
        public List<int> rectOutlineThickness = new List<int>();
        public List<List<Point>> storedEllipsesNoFill = new List<List<Point>>();
        public List<Color> ellipseNoFillColors = new List<Color>();
        public List<int> ellipseOutlineThickness = new List<int>();

        public Color color = Color.FromArgb(255, 0, 0, 0);
        public int thickness = 5;

        // Operation codes:
        // 0 - Freehand drawing
        // 1 - Filled Rectangle
        // 2 - Filled Ellipse
        // 3 - Rectangle Outline (No Fill)
        // 4 - Ellipse Outline (No Fill)
        public int thisOperation = 0;
        public Stack<int> lastOperation = new Stack<int>();

        public int red = 0;
        public int green = 0;
        public int blue = 0;

        public Form1()
        {
            lastOperation.Push(0);
            InitializeComponent();
        }

        private void panel_Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(color, thickness);
            Pen tempPen = new Pen(Color.Black, thickness);
            SolidBrush brush = new SolidBrush(color);
            SolidBrush tempBrush = new SolidBrush(Color.Black);

            // Draw the preview shape based on the current operation
            switch (thisOperation)
            {
                case 0: // Freehand drawing preview
                    for (int i = 0; i < points.Count - 1; i++)
                    {
                        graphics.DrawLine(pen, points[i], points[i + 1]);
                        graphics.FillEllipse(brush, points[i].X - thickness / 2, points[i].Y - thickness / 2, thickness, thickness);
                        graphics.FillEllipse(brush, points[i + 1].X - thickness / 2, points[i + 1].Y - thickness / 2, thickness, thickness);
                    }
                    break;
                case 1: // Filled Rectangle preview
                    if (points.Count >= 2)
                    {
                        int x = Math.Min(points[0].X, points[points.Count - 1].X);
                        int y = Math.Min(points[0].Y, points[points.Count - 1].Y);
                        int width = Math.Abs(points[0].X - points[points.Count - 1].X);
                        int height = Math.Abs(points[0].Y - points[points.Count - 1].Y);
                        graphics.FillRectangle(new SolidBrush(color), x, y, width, height);
                    }
                    break;
                case 2: // Filled Ellipse preview
                    if (points.Count >= 2)
                    {
                        int x = Math.Min(points[0].X, points[points.Count - 1].X);
                        int y = Math.Min(points[0].Y, points[points.Count - 1].Y);
                        int width = Math.Abs(points[0].X - points[points.Count - 1].X);
                        int height = Math.Abs(points[0].Y - points[points.Count - 1].Y);
                        graphics.FillEllipse(new SolidBrush(color), x, y, width, height);
                    }
                    break;
                case 3: // Rectangle Outline preview (no fill)
                    if (points.Count >= 2)
                    {
                        int x = Math.Min(points[0].X, points[points.Count - 1].X);
                        int y = Math.Min(points[0].Y, points[points.Count - 1].Y);
                        int width = Math.Abs(points[0].X - points[points.Count - 1].X);
                        int height = Math.Abs(points[0].Y - points[points.Count - 1].Y);
                        graphics.DrawRectangle(new Pen(color, thickness), x, y, width, height);
                    }
                    break;
                case 4: // Ellipse Outline preview (no fill)
                    if (points.Count >= 2)
                    {
                        int x = Math.Min(points[0].X, points[points.Count - 1].X);
                        int y = Math.Min(points[0].Y, points[points.Count - 1].Y);
                        int width = Math.Abs(points[0].X - points[points.Count - 1].X);
                        int height = Math.Abs(points[0].Y - points[points.Count - 1].Y);
                        graphics.DrawEllipse(new Pen(color, thickness), x, y, width, height);
                    }
                    break;
                default:
                    break;
            }

            // Draw stored freehand lines
            for (int i = 0; i < storedLines.Count; i++)
            {
                List<Point> line = storedLines[i];
                for (int j = 0; j < line.Count - 1; j++)
                {
                    tempPen = new Pen(lineColors[i], lineThickness[i]);
                    tempBrush = new SolidBrush(lineColors[i]);
                    graphics.DrawLine(tempPen, line[j], line[j + 1]);
                    graphics.FillEllipse(tempBrush, line[j].X - lineThickness[i] / 2, line[j].Y - lineThickness[i] / 2, lineThickness[i], lineThickness[i]);
                    graphics.FillEllipse(tempBrush, line[j + 1].X - lineThickness[i] / 2, line[j + 1].Y - lineThickness[i] / 2, lineThickness[i], lineThickness[i]);
                }
            }

            // Draw stored filled rectangles
            for (int i = 0; i < storedRectangles.Count; i++)
            {
                if (storedRectangles[i].Count >= 2)
                {
                    int x = Math.Min(storedRectangles[i][0].X, storedRectangles[i][storedRectangles[i].Count - 1].X);
                    int y = Math.Min(storedRectangles[i][0].Y, storedRectangles[i][storedRectangles[i].Count - 1].Y);
                    int width = Math.Abs(storedRectangles[i][0].X - storedRectangles[i][storedRectangles[i].Count - 1].X);
                    int height = Math.Abs(storedRectangles[i][0].Y - storedRectangles[i][storedRectangles[i].Count - 1].Y);
                    graphics.FillRectangle(new SolidBrush(rectangleColors[i]), x, y, width, height);
                }
            }

            // Draw stored filled ellipses
            for (int i = 0; i < storedEllipses.Count; i++)
            {
                if (storedEllipses[i].Count >= 2)
                {
                    int x = Math.Min(storedEllipses[i][0].X, storedEllipses[i][storedEllipses[i].Count - 1].X);
                    int y = Math.Min(storedEllipses[i][0].Y, storedEllipses[i][storedEllipses[i].Count - 1].Y);
                    int width = Math.Abs(storedEllipses[i][0].X - storedEllipses[i][storedEllipses[i].Count - 1].X);
                    int height = Math.Abs(storedEllipses[i][0].Y - storedEllipses[i][storedEllipses[i].Count - 1].Y);
                    graphics.FillEllipse(new SolidBrush(ellipseColors[i]), x, y, width, height);
                }
            }

            // Draw stored rectangle outlines (no fill)
            for (int i = 0; i < storedRectanglesNoFill.Count; i++)
            {
                if (storedRectanglesNoFill[i].Count >= 2)
                {
                    int x = Math.Min(storedRectanglesNoFill[i][0].X, storedRectanglesNoFill[i][storedRectanglesNoFill[i].Count - 1].X);
                    int y = Math.Min(storedRectanglesNoFill[i][0].Y, storedRectanglesNoFill[i][storedRectanglesNoFill[i].Count - 1].Y);
                    int width = Math.Abs(storedRectanglesNoFill[i][0].X - storedRectanglesNoFill[i][storedRectanglesNoFill[i].Count - 1].X);
                    int height = Math.Abs(storedRectanglesNoFill[i][0].Y - storedRectanglesNoFill[i][storedRectanglesNoFill[i].Count - 1].Y);
                    graphics.DrawRectangle(new Pen(rectangleNoFillColors[i], rectOutlineThickness[i]), x, y, width, height);
                }
            }

            // Draw stored ellipse outlines (no fill)
            for (int i = 0; i < storedEllipsesNoFill.Count; i++)
            {
                if (storedEllipsesNoFill[i].Count >= 2)
                {
                    int x = Math.Min(storedEllipsesNoFill[i][0].X, storedEllipsesNoFill[i][storedEllipsesNoFill[i].Count - 1].X);
                    int y = Math.Min(storedEllipsesNoFill[i][0].Y, storedEllipsesNoFill[i][storedEllipsesNoFill[i].Count - 1].Y);
                    int width = Math.Abs(storedEllipsesNoFill[i][0].X - storedEllipsesNoFill[i][storedEllipsesNoFill[i].Count - 1].X);
                    int height = Math.Abs(storedEllipsesNoFill[i][0].Y - storedEllipsesNoFill[i][storedEllipsesNoFill[i].Count - 1].Y);
                    graphics.DrawEllipse(new Pen(ellipseNoFillColors[i], ellipseOutlineThickness[i]), x, y, width, height);
                }
            }
        }

        private void panel_Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            points.Add(e.Location);
        }

        private void panel_Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                points.Add(e.Location);
                panel_Canvas.Invalidate();
            }
        }

        private void panel_Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            switch (thisOperation)
            {
                case 0: // Freehand drawing
                    storedLines.Add(new List<Point>(points));
                    lineThickness.Add(thickness);
                    lineColors.Add(color);
                    points.Clear();
                    isDrawing = false;
                    lastOperation.Push(0);
                    panel_Canvas.Invalidate();
                    break;
                case 1: // Filled Rectangle
                    if (points.Count > 1)
                    {
                        storedRectangles.Add(new List<Point>(points));
                        rectangleColors.Add(color);
                        points.Clear();
                        isDrawing = false;
                        lastOperation.Push(1);
                        panel_Canvas.Invalidate();
                    }
                    break;
                case 2: // Filled Ellipse
                    if (points.Count > 1)
                    {
                        storedEllipses.Add(new List<Point>(points));
                        ellipseColors.Add(color);
                        points.Clear();
                        isDrawing = false;
                        lastOperation.Push(2);
                        panel_Canvas.Invalidate();
                    }
                    break;
                case 3: // Rectangle Outline (No Fill)
                    if (points.Count > 1)
                    {
                        storedRectanglesNoFill.Add(new List<Point>(points));
                        rectangleNoFillColors.Add(color);
                        rectOutlineThickness.Add(thickness);
                        points.Clear();
                        isDrawing = false;
                        lastOperation.Push(3);
                        panel_Canvas.Invalidate();
                    }
                    break;
                case 4: // Ellipse Outline (No Fill)
                    if (points.Count > 1)
                    {
                        storedEllipsesNoFill.Add(new List<Point>(points));
                        ellipseNoFillColors.Add(color);
                        ellipseOutlineThickness.Add(thickness);
                        points.Clear();
                        isDrawing = false;
                        lastOperation.Push(4);
                        panel_Canvas.Invalidate();
                    }
                    break;
                default:
                    break;
            }
        }

        private void button_Undo_Click(object sender, EventArgs e)
        {
            if (lastOperation.Count > 0)
            {
                int op = lastOperation.Pop();
                switch (op)
                {
                    case 0:
                        if (storedLines.Count > 0)
                        {
                            storedLines.RemoveAt(storedLines.Count - 1);
                            lineThickness.RemoveAt(lineThickness.Count - 1);
                            lineColors.RemoveAt(lineColors.Count - 1);
                        }
                        break;
                    case 1:
                        if (storedRectangles.Count > 0)
                        {
                            storedRectangles.RemoveAt(storedRectangles.Count - 1);
                            rectangleColors.RemoveAt(rectangleColors.Count - 1);
                        }
                        break;
                    case 2:
                        if (storedEllipses.Count > 0)
                        {
                            storedEllipses.RemoveAt(storedEllipses.Count - 1);
                            ellipseColors.RemoveAt(ellipseColors.Count - 1);
                        }
                        break;
                    case 3:
                        if (storedRectanglesNoFill.Count > 0)
                        {
                            storedRectanglesNoFill.RemoveAt(storedRectanglesNoFill.Count - 1);
                            rectangleNoFillColors.RemoveAt(rectangleNoFillColors.Count - 1);
                        }
                        break;
                    case 4:
                        if (storedEllipsesNoFill.Count > 0)
                        {
                            storedEllipsesNoFill.RemoveAt(storedEllipsesNoFill.Count - 1);
                            ellipseNoFillColors.RemoveAt(ellipseNoFillColors.Count - 1);
                        }
                        break;
                    default:
                        break;
                }
                panel_Canvas.Invalidate();
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            storedLines.Clear();
            lineThickness.Clear();
            lineColors.Clear();
            storedRectangles.Clear();
            rectangleColors.Clear();
            storedEllipses.Clear();
            ellipseColors.Clear();
            storedRectanglesNoFill.Clear();
            rectangleNoFillColors.Clear();
            storedEllipsesNoFill.Clear();
            ellipseNoFillColors.Clear();
            panel_Canvas.Invalidate();
        }

        private void vScrollBar_Thickness_Scroll(object sender, ScrollEventArgs e)
        {
            thickness = vScrollBar_Thickness.Value;
            textBox_Thickness.Text = thickness.ToString();
        }

        private void vScrollBar_Red_Scroll(object sender, ScrollEventArgs e)
        {
            red = vScrollBar_Red.Value;
            color = Color.FromArgb(255, red, green, blue);
            textBox_Red.Text = vScrollBar_Red.Value.ToString();
        }
        private void vScrollBar_Green_Scroll(object sender, ScrollEventArgs e)
        {
            green = vScrollBar_Green.Value;
            color = Color.FromArgb(255, vScrollBar_Red.Value, vScrollBar_Green.Value, vScrollBar_Blue.Value);
            textBox_Green.Text = vScrollBar_Green.Value.ToString();
        }
        private void vScrollBar_Blue_Scroll(object sender, ScrollEventArgs e)
        {
            blue = vScrollBar_Blue.Value;
            color = Color.FromArgb(255, red, green, blue);
            textBox_Blue.Text = vScrollBar_Blue.Value.ToString();
        }

        private void textBox_Red_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_Red.Text, out int value))
            {
                if (value >= vScrollBar_Red.Minimum && value <= vScrollBar_Red.Maximum)
                {
                    red = value;
                    vScrollBar_Red.Value = value;
                    color = Color.FromArgb(255, red, green, blue);
                }
                else
                {
                    MessageBox.Show("Please enter a value between " + vScrollBar_Red.Minimum + " and " + vScrollBar_Red.Maximum + ".");
                }
            }
            else
            {
                MessageBox.Show("Please enter only a number.");
            }
        }
        private void textBox_Green_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_Green.Text, out int value))
            {
                if (value >= vScrollBar_Green.Minimum && value <= vScrollBar_Green.Maximum)
                {
                    green = value;
                    vScrollBar_Green.Value = value;
                    color = Color.FromArgb(255, red, green, blue);
                }
                else
                {
                    MessageBox.Show("Please enter a value between " + vScrollBar_Green.Minimum + " and " + vScrollBar_Green.Maximum + ".");
                }
            }
            else
            {
                MessageBox.Show("Please enter only a number.");
            }
        }
        private void textBox_Blue_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_Blue.Text, out int value))
            {
                if (value >= vScrollBar_Blue.Minimum && value <= vScrollBar_Blue.Maximum)
                {
                    blue = value;
                    vScrollBar_Blue.Value = value;
                    color = Color.FromArgb(255, red, green, blue);
                }
                else
                {
                    MessageBox.Show("Please enter a value between " + vScrollBar_Blue.Minimum + " and " + vScrollBar_Blue.Maximum + ".");
                }
            }
            else
            {
                MessageBox.Show("Please enter only a number.");
            }
        }
        private void textBox_Thickness_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_Thickness.Text, out int value))
            {
                if (value >= vScrollBar_Thickness.Minimum && value <= vScrollBar_Thickness.Maximum)
                {
                    thickness = value;
                    vScrollBar_Thickness.Value = value;
                }
                else if (value == 69)
                {
                    ProcessStartInfo psi = new ProcessStartInfo(); // credit https://tpforums.org/forum/archive/index.php/t-1524.html and others
                    psi.CreateNoWindow = true;
                    psi.UseShellExecute = true;
                    psi.FileName = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
                    psi.WindowStyle = ProcessWindowStyle.Hidden;
                    Process.Start(psi);
                }
                else
                {
                    MessageBox.Show("Please enter a value between " + vScrollBar_Thickness.Minimum + " and " + vScrollBar_Thickness.Maximum + ".");
                }
            }
            else
            {
                MessageBox.Show("Please enter only a number.");
            }
        }

        private void button_Draw_Click(object sender, EventArgs e)
        {
            thisOperation = 0;
            button_Draw.BackColor = Color.DarkGray;
            // Reset other buttons as needed
            button_Rectangle.BackColor = Color.White;
            button_Ellipse.BackColor = Color.White;
            button_RectangleOutline.BackColor = Color.White;
            button_EllipseOutline.BackColor = Color.White;
        }

        private void button_Rectangle_Click(object sender, EventArgs e)
        {
            thisOperation = 1;
            button_Rectangle.BackColor = Color.DarkGray;
            button_Draw.BackColor = Color.White;
            button_Ellipse.BackColor = Color.White;
            button_RectangleOutline.BackColor = Color.White;
            button_EllipseOutline.BackColor = Color.White;
        }

        private void button_Ellipse_Click(object sender, EventArgs e)
        {
            thisOperation = 2;
            button_Ellipse.BackColor = Color.DarkGray;
            button_Draw.BackColor = Color.White;
            button_Rectangle.BackColor = Color.White;
            button_RectangleOutline.BackColor = Color.White;
            button_EllipseOutline.BackColor = Color.White;
        }

        private void button_RectangleOutline_Click(object sender, EventArgs e)
        {
            thisOperation = 3;
            button_RectangleOutline.BackColor = Color.DarkGray;
            button_Draw.BackColor = Color.White;
            button_Rectangle.BackColor = Color.White;
            button_Ellipse.BackColor = Color.White;
            button_EllipseOutline.BackColor = Color.White;
        }

        private void button_EllipseOutline_Click_1(object sender, EventArgs e)
        {
            thisOperation = 4;
            button_EllipseOutline.BackColor = Color.DarkGray;
            button_Draw.BackColor = Color.White;
            button_Rectangle.BackColor = Color.White;
            button_Ellipse.BackColor = Color.White;
            button_RectangleOutline.BackColor = Color.White;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog()) //internet :)
            {
                dialog.Description = "Select a folder";
                dialog.ShowNewFolderButton = true;    // Allows user to create a new folder

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = Path.Combine(dialog.SelectedPath, "paint.txt");
                    try
                    {
                        FileSystem.DeleteFile(filePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);

                        foreach (var line in storedLines)
                        {
                            string lineData = string.Join(",", line.Select(p => $"{p.X},{p.Y}"));
                            File.AppendAllText(filePath, lineData + Environment.NewLine);
                        }
                        foreach (var lineColor in lineColors)
                        {
                            string lineColorData = $"{lineColor.R},{lineColor.G},{lineColor.B}";
                            File.AppendAllText(filePath, lineColorData + Environment.NewLine);
                        }
                        foreach (var lineThickness in lineThickness)
                        {
                            File.AppendAllText(filePath, lineThickness.ToString() + Environment.NewLine);
                        }

                        foreach (var rect in storedRectangles)
                        {
                            string rectData = string.Join(",", rect.Select(p => $"{p.X},{p.Y}"));
                            File.AppendAllText(filePath, rectData + Environment.NewLine);
                        }
                        foreach (var rectColor in rectangleColors)
                        {
                            string rectColorData = $"{rectColor.R},{rectColor.G},{rectColor.B}";
                            File.AppendAllText(filePath, rectColorData + Environment.NewLine);
                        }

                        foreach (var rect in storedRectanglesNoFill)
                        {
                            string rectData = string.Join(",", rect.Select(p => $"{p.X},{p.Y}"));
                            File.AppendAllText(filePath, rectData + Environment.NewLine);
                        }
                        foreach (var rectColor in rectangleNoFillColors)
                        {
                            string rectColorData = $"{rectColor.R},{rectColor.G},{rectColor.B}";
                            File.AppendAllText(filePath, rectColorData + Environment.NewLine);
                        }

                        foreach (var ellipse in storedEllipses)
                        {
                            string ellipseData = string.Join(",", ellipse.Select(p => $"{p.X},{p.Y}"));
                            File.AppendAllText(filePath, ellipseData + Environment.NewLine);
                        }
                        foreach (var ellipseColor in ellipseColors)
                        {
                            string ellipseColorData = $"{ellipseColor.R},{ellipseColor.G},{ellipseColor.B}";
                            File.AppendAllText(filePath, ellipseColorData + Environment.NewLine);
                        }

                        foreach (var ellipse in storedEllipsesNoFill)
                        {
                            string ellipseData = string.Join(",", ellipse.Select(p => $"{p.X},{p.Y}"));
                            File.AppendAllText(filePath, ellipseData + Environment.NewLine);
                        }
                        foreach (var ellipseColor in ellipseNoFillColors)
                        {
                            string ellipseColorData = $"{ellipseColor.R},{ellipseColor.G},{ellipseColor.B}";
                            File.AppendAllText(filePath, ellipseColorData + Environment.NewLine);
                        }

                        MessageBox.Show($"Lines saved to: {filePath}");
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("Error saving file: " + ex.Message);
                    }
                }
            }
            
        }
    }
}
