namespace Paint
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel_Controls = new Panel();
            button_EllipseOutline = new Button();
            button_RectangleOutline = new Button();
            button_Ellipse = new Button();
            button_Draw = new Button();
            button_Rectangle = new Button();
            vScrollBar_Blue = new VScrollBar();
            vScrollBar_Green = new VScrollBar();
            vScrollBar_Red = new VScrollBar();
            textBox_Green = new TextBox();
            textBox_Red = new TextBox();
            textBox_Blue = new TextBox();
            textBox_Thickness = new TextBox();
            vScrollBar_Thickness = new VScrollBar();
            button_Clear = new Button();
            button_Undo = new Button();
            panel_Canvas = new Panel();
            button_Save = new Button();
            button2 = new Button();
            panel_Controls.SuspendLayout();
            SuspendLayout();
            // 
            // panel_Controls
            // 
            panel_Controls.BackColor = Color.FromArgb(224, 224, 224);
            panel_Controls.Controls.Add(button2);
            panel_Controls.Controls.Add(button_Save);
            panel_Controls.Controls.Add(button_EllipseOutline);
            panel_Controls.Controls.Add(button_RectangleOutline);
            panel_Controls.Controls.Add(button_Ellipse);
            panel_Controls.Controls.Add(button_Draw);
            panel_Controls.Controls.Add(button_Rectangle);
            panel_Controls.Controls.Add(vScrollBar_Blue);
            panel_Controls.Controls.Add(vScrollBar_Green);
            panel_Controls.Controls.Add(vScrollBar_Red);
            panel_Controls.Controls.Add(textBox_Green);
            panel_Controls.Controls.Add(textBox_Red);
            panel_Controls.Controls.Add(textBox_Blue);
            panel_Controls.Controls.Add(textBox_Thickness);
            panel_Controls.Controls.Add(vScrollBar_Thickness);
            panel_Controls.Controls.Add(button_Clear);
            panel_Controls.Controls.Add(button_Undo);
            panel_Controls.Location = new Point(12, 12);
            panel_Controls.Name = "panel_Controls";
            panel_Controls.Size = new Size(1872, 143);
            panel_Controls.TabIndex = 0;
            // 
            // button_EllipseOutline
            // 
            button_EllipseOutline.BackColor = Color.Transparent;
            button_EllipseOutline.Font = new Font("Segoe UI", 11.1428576F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button_EllipseOutline.ImageAlign = ContentAlignment.TopCenter;
            button_EllipseOutline.Location = new Point(177, 72);
            button_EllipseOutline.Name = "button_EllipseOutline";
            button_EllipseOutline.Size = new Size(81, 68);
            button_EllipseOutline.TabIndex = 17;
            button_EllipseOutline.Text = "⬭";
            button_EllipseOutline.UseVisualStyleBackColor = false;
            button_EllipseOutline.Click += button_EllipseOutline_Click_1;
            // 
            // button_RectangleOutline
            // 
            button_RectangleOutline.BackColor = Color.Transparent;
            button_RectangleOutline.Font = new Font("Segoe UI", 11.1428576F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button_RectangleOutline.ImageAlign = ContentAlignment.TopCenter;
            button_RectangleOutline.Location = new Point(177, 3);
            button_RectangleOutline.Name = "button_RectangleOutline";
            button_RectangleOutline.Size = new Size(81, 68);
            button_RectangleOutline.TabIndex = 16;
            button_RectangleOutline.Text = "▭";
            button_RectangleOutline.UseVisualStyleBackColor = false;
            button_RectangleOutline.Click += button_RectangleOutline_Click;
            // 
            // button_Ellipse
            // 
            button_Ellipse.BackColor = Color.Transparent;
            button_Ellipse.Font = new Font("Segoe UI", 11.1428576F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button_Ellipse.ImageAlign = ContentAlignment.TopCenter;
            button_Ellipse.Location = new Point(90, 72);
            button_Ellipse.Name = "button_Ellipse";
            button_Ellipse.Size = new Size(81, 68);
            button_Ellipse.TabIndex = 15;
            button_Ellipse.Text = "⬬";
            button_Ellipse.UseVisualStyleBackColor = false;
            button_Ellipse.Click += button_Ellipse_Click;
            // 
            // button_Draw
            // 
            button_Draw.BackColor = Color.DarkGray;
            button_Draw.Location = new Point(3, 3);
            button_Draw.Name = "button_Draw";
            button_Draw.Size = new Size(81, 68);
            button_Draw.TabIndex = 14;
            button_Draw.Text = "🖌";
            button_Draw.UseVisualStyleBackColor = false;
            button_Draw.Click += button_Draw_Click;
            // 
            // button_Rectangle
            // 
            button_Rectangle.BackColor = Color.Transparent;
            button_Rectangle.Location = new Point(90, 3);
            button_Rectangle.Name = "button_Rectangle";
            button_Rectangle.Size = new Size(81, 68);
            button_Rectangle.TabIndex = 13;
            button_Rectangle.Text = "▬";
            button_Rectangle.UseVisualStyleBackColor = false;
            button_Rectangle.Click += button_Rectangle_Click;
            // 
            // vScrollBar_Blue
            // 
            vScrollBar_Blue.Cursor = Cursors.SizeNS;
            vScrollBar_Blue.LargeChange = 5;
            vScrollBar_Blue.Location = new Point(1560, 3);
            vScrollBar_Blue.Maximum = 255;
            vScrollBar_Blue.Name = "vScrollBar_Blue";
            vScrollBar_Blue.Size = new Size(46, 99);
            vScrollBar_Blue.TabIndex = 12;
            vScrollBar_Blue.Scroll += vScrollBar_Blue_Scroll;
            // 
            // vScrollBar_Green
            // 
            vScrollBar_Green.Cursor = Cursors.SizeNS;
            vScrollBar_Green.LargeChange = 5;
            vScrollBar_Green.Location = new Point(1514, 3);
            vScrollBar_Green.Maximum = 255;
            vScrollBar_Green.Name = "vScrollBar_Green";
            vScrollBar_Green.Size = new Size(46, 99);
            vScrollBar_Green.TabIndex = 12;
            vScrollBar_Green.Scroll += vScrollBar_Green_Scroll;
            // 
            // vScrollBar_Red
            // 
            vScrollBar_Red.Cursor = Cursors.SizeNS;
            vScrollBar_Red.LargeChange = 5;
            vScrollBar_Red.Location = new Point(1468, 3);
            vScrollBar_Red.Maximum = 255;
            vScrollBar_Red.Name = "vScrollBar_Red";
            vScrollBar_Red.Size = new Size(46, 99);
            vScrollBar_Red.TabIndex = 11;
            vScrollBar_Red.Scroll += vScrollBar_Red_Scroll;
            // 
            // textBox_Green
            // 
            textBox_Green.BackColor = Color.Lime;
            textBox_Green.Location = new Point(1514, 105);
            textBox_Green.Name = "textBox_Green";
            textBox_Green.Size = new Size(46, 35);
            textBox_Green.TabIndex = 10;
            textBox_Green.Text = "0";
            textBox_Green.TextChanged += textBox_Green_TextChanged;
            // 
            // textBox_Red
            // 
            textBox_Red.BackColor = Color.Red;
            textBox_Red.ForeColor = Color.FromArgb(64, 64, 64);
            textBox_Red.Location = new Point(1468, 105);
            textBox_Red.Name = "textBox_Red";
            textBox_Red.Size = new Size(46, 35);
            textBox_Red.TabIndex = 9;
            textBox_Red.Text = "0";
            textBox_Red.TextChanged += textBox_Red_TextChanged;
            // 
            // textBox_Blue
            // 
            textBox_Blue.BackColor = Color.Blue;
            textBox_Blue.ForeColor = Color.White;
            textBox_Blue.Location = new Point(1560, 105);
            textBox_Blue.Name = "textBox_Blue";
            textBox_Blue.Size = new Size(46, 35);
            textBox_Blue.TabIndex = 6;
            textBox_Blue.Text = "0";
            textBox_Blue.TextChanged += textBox_Blue_TextChanged;
            // 
            // textBox_Thickness
            // 
            textBox_Thickness.BackColor = Color.Black;
            textBox_Thickness.ForeColor = Color.White;
            textBox_Thickness.Location = new Point(1391, 105);
            textBox_Thickness.Name = "textBox_Thickness";
            textBox_Thickness.Size = new Size(46, 35);
            textBox_Thickness.TabIndex = 3;
            textBox_Thickness.Text = "5";
            textBox_Thickness.TextChanged += textBox_Thickness_TextChanged;
            // 
            // vScrollBar_Thickness
            // 
            vScrollBar_Thickness.Cursor = Cursors.SizeNS;
            vScrollBar_Thickness.LargeChange = 5;
            vScrollBar_Thickness.Location = new Point(1391, 3);
            vScrollBar_Thickness.Maximum = 40;
            vScrollBar_Thickness.Name = "vScrollBar_Thickness";
            vScrollBar_Thickness.Size = new Size(46, 99);
            vScrollBar_Thickness.TabIndex = 0;
            vScrollBar_Thickness.Value = 5;
            vScrollBar_Thickness.Scroll += vScrollBar_Thickness_Scroll;
            // 
            // button_Clear
            // 
            button_Clear.Location = new Point(1788, 72);
            button_Clear.Name = "button_Clear";
            button_Clear.Size = new Size(81, 68);
            button_Clear.TabIndex = 1;
            button_Clear.Text = "🗑";
            button_Clear.UseVisualStyleBackColor = true;
            button_Clear.Click += button_Clear_Click;
            // 
            // button_Undo
            // 
            button_Undo.Font = new Font("Segoe UI", 15.8571434F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button_Undo.Location = new Point(1788, 3);
            button_Undo.Name = "button_Undo";
            button_Undo.Size = new Size(81, 68);
            button_Undo.TabIndex = 0;
            button_Undo.Text = "↶";
            button_Undo.UseVisualStyleBackColor = true;
            button_Undo.Click += button_Undo_Click;
            // 
            // panel_Canvas
            // 
            panel_Canvas.BackColor = Color.White;
            panel_Canvas.Location = new Point(12, 155);
            panel_Canvas.Name = "panel_Canvas";
            panel_Canvas.Size = new Size(1872, 849);
            panel_Canvas.TabIndex = 1;
            panel_Canvas.Paint += panel_Canvas_Paint;
            panel_Canvas.MouseDown += panel_Canvas_MouseDown;
            panel_Canvas.MouseMove += panel_Canvas_MouseMove;
            panel_Canvas.MouseUp += panel_Canvas_MouseUp;
            // 
            // button_Save
            // 
            button_Save.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button_Save.Location = new Point(1662, 3);
            button_Save.Name = "button_Save";
            button_Save.Size = new Size(81, 68);
            button_Save.TabIndex = 18;
            button_Save.Text = "💾";
            button_Save.UseVisualStyleBackColor = true;
            button_Save.Click += button_Save_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            button2.Location = new Point(1662, 72);
            button2.Name = "button2";
            button2.Size = new Size(81, 68);
            button2.TabIndex = 19;
            button2.Text = "📂";
            button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(1896, 1016);
            Controls.Add(panel_Canvas);
            Controls.Add(panel_Controls);
            Name = "Form1";
            Text = "Form1";
            panel_Controls.ResumeLayout(false);
            panel_Controls.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_Controls;
        private Panel panel_Canvas;
        private Button button_Undo;
        private Button button_Clear;
        private VScrollBar vScrollBar_Thickness;
        private TextBox textBox_Thickness;
        private TextBox textBox_Green;
        private TextBox textBox_Red;
        private TextBox textBox_Blue;
        private VScrollBar vScrollBar_Blue;
        private VScrollBar vScrollBar_Green;
        private VScrollBar vScrollBar_Red;
        private Button button_Rectangle;
        private Button button_Draw;
        private Button button_Ellipse;
        private Button button_EllipseOutline;
        private Button button_RectangleOutline;
        private Button button2;
        private Button button_Save;
    }
}
