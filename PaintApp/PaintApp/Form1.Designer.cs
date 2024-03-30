namespace PaintApp
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
            this.changeBrush1 = new System.Windows.Forms.Button();
            this.changeBrush2 = new System.Windows.Forms.Button();
            this.sliderRed = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.sliderGreen = new System.Windows.Forms.TrackBar();
            this.sliderBlue = new System.Windows.Forms.TrackBar();
            this.sliderWidth = new System.Windows.Forms.TrackBar();
            this.labelWidth = new System.Windows.Forms.Label();
            this.labelRed = new System.Windows.Forms.Label();
            this.labelGreen = new System.Windows.Forms.Label();
            this.labelBlue = new System.Windows.Forms.Label();
            this.insertImage = new System.Windows.Forms.Button();
            this.changeEraser = new System.Windows.Forms.Button();
            this.changeRectangle = new System.Windows.Forms.Button();
            this.textboxShapeWidth = new System.Windows.Forms.TextBox();
            this.textboxShapeHeight = new System.Windows.Forms.TextBox();
            this.changeElipse = new System.Windows.Forms.Button();
            this.labelShapeWidth = new System.Windows.Forms.Label();
            this.labelShapeHeight = new System.Windows.Forms.Label();
            this.buttonFillShape = new System.Windows.Forms.Button();
            this.buttonEraseCanvas = new System.Windows.Forms.Button();
            this.changeHighlighter = new System.Windows.Forms.Button();
            this.buttonHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sliderRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // changeBrush1
            // 
            this.changeBrush1.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changeBrush1.Location = new System.Drawing.Point(735, 398);
            this.changeBrush1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.changeBrush1.Name = "changeBrush1";
            this.changeBrush1.Size = new System.Drawing.Size(112, 35);
            this.changeBrush1.TabIndex = 0;
            this.changeBrush1.Text = "Brush 1";
            this.changeBrush1.UseVisualStyleBackColor = true;
            this.changeBrush1.Click += new System.EventHandler(this.changeBrush1_Click);
            // 
            // changeBrush2
            // 
            this.changeBrush2.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changeBrush2.Location = new System.Drawing.Point(855, 398);
            this.changeBrush2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.changeBrush2.Name = "changeBrush2";
            this.changeBrush2.Size = new System.Drawing.Size(112, 35);
            this.changeBrush2.TabIndex = 1;
            this.changeBrush2.Text = "Brush 2";
            this.changeBrush2.UseVisualStyleBackColor = true;
            this.changeBrush2.Click += new System.EventHandler(this.changeBrush2_Click);
            // 
            // sliderRed
            // 
            this.sliderRed.BackColor = System.Drawing.Color.Red;
            this.sliderRed.Location = new System.Drawing.Point(907, 164);
            this.sliderRed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sliderRed.Maximum = 255;
            this.sliderRed.Name = "sliderRed";
            this.sliderRed.Size = new System.Drawing.Size(355, 69);
            this.sliderRed.TabIndex = 2;
            this.sliderRed.Scroll += new System.EventHandler(this.sliderRed_Scroll);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.BackgroundImage = global::PaintApp.Properties.Resources.Screenshot_Videoclip_Never_Gonna_Give_You_Up;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.No;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(720, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(580, 700);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // sliderGreen
            // 
            this.sliderGreen.BackColor = System.Drawing.Color.Green;
            this.sliderGreen.Location = new System.Drawing.Point(907, 241);
            this.sliderGreen.Maximum = 255;
            this.sliderGreen.Name = "sliderGreen";
            this.sliderGreen.Size = new System.Drawing.Size(355, 69);
            this.sliderGreen.TabIndex = 4;
            this.sliderGreen.Scroll += new System.EventHandler(this.sliderGreen_Scroll);
            // 
            // sliderBlue
            // 
            this.sliderBlue.BackColor = System.Drawing.Color.Blue;
            this.sliderBlue.Location = new System.Drawing.Point(907, 321);
            this.sliderBlue.Maximum = 255;
            this.sliderBlue.Name = "sliderBlue";
            this.sliderBlue.Size = new System.Drawing.Size(355, 69);
            this.sliderBlue.TabIndex = 5;
            this.sliderBlue.Scroll += new System.EventHandler(this.sliderBlue_Scroll);
            // 
            // sliderWidth
            // 
            this.sliderWidth.Location = new System.Drawing.Point(907, 70);
            this.sliderWidth.Minimum = 1;
            this.sliderWidth.Name = "sliderWidth";
            this.sliderWidth.Size = new System.Drawing.Size(355, 69);
            this.sliderWidth.TabIndex = 6;
            this.sliderWidth.Value = 1;
            this.sliderWidth.Scroll += new System.EventHandler(this.sliderWidth_Scroll);
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.labelWidth.Location = new System.Drawing.Point(833, 70);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(49, 33);
            this.labelWidth.TabIndex = 7;
            this.labelWidth.Text = "1pt";
            // 
            // labelRed
            // 
            this.labelRed.AutoSize = true;
            this.labelRed.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.labelRed.Location = new System.Drawing.Point(833, 164);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(30, 33);
            this.labelRed.TabIndex = 8;
            this.labelRed.Text = "0";
            // 
            // labelGreen
            // 
            this.labelGreen.AutoSize = true;
            this.labelGreen.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.labelGreen.Location = new System.Drawing.Point(833, 246);
            this.labelGreen.Name = "labelGreen";
            this.labelGreen.Size = new System.Drawing.Size(30, 33);
            this.labelGreen.TabIndex = 9;
            this.labelGreen.Text = "0";
            // 
            // labelBlue
            // 
            this.labelBlue.AutoSize = true;
            this.labelBlue.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.labelBlue.Location = new System.Drawing.Point(833, 321);
            this.labelBlue.Name = "labelBlue";
            this.labelBlue.Size = new System.Drawing.Size(30, 33);
            this.labelBlue.TabIndex = 10;
            this.labelBlue.Text = "0";
            // 
            // insertImage
            // 
            this.insertImage.Cursor = System.Windows.Forms.Cursors.Default;
            this.insertImage.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.insertImage.Location = new System.Drawing.Point(735, 562);
            this.insertImage.Name = "insertImage";
            this.insertImage.Size = new System.Drawing.Size(112, 35);
            this.insertImage.TabIndex = 11;
            this.insertImage.Text = "Image";
            this.insertImage.UseVisualStyleBackColor = true;
            this.insertImage.Click += new System.EventHandler(this.insertImage_Click);
            // 
            // changeEraser
            // 
            this.changeEraser.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changeEraser.Location = new System.Drawing.Point(1095, 398);
            this.changeEraser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.changeEraser.Name = "changeEraser";
            this.changeEraser.Size = new System.Drawing.Size(112, 35);
            this.changeEraser.TabIndex = 12;
            this.changeEraser.Text = "Eraser";
            this.changeEraser.UseVisualStyleBackColor = true;
            this.changeEraser.Click += new System.EventHandler(this.changeEraser_Click);
            // 
            // changeRectangle
            // 
            this.changeRectangle.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changeRectangle.Location = new System.Drawing.Point(735, 605);
            this.changeRectangle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.changeRectangle.Name = "changeRectangle";
            this.changeRectangle.Size = new System.Drawing.Size(112, 35);
            this.changeRectangle.TabIndex = 13;
            this.changeRectangle.Text = "Rectangle";
            this.changeRectangle.UseVisualStyleBackColor = true;
            this.changeRectangle.Click += new System.EventHandler(this.changeRectangle_Click);
            // 
            // textboxShapeWidth
            // 
            this.textboxShapeWidth.Location = new System.Drawing.Point(1162, 627);
            this.textboxShapeWidth.Name = "textboxShapeWidth";
            this.textboxShapeWidth.Size = new System.Drawing.Size(100, 26);
            this.textboxShapeWidth.TabIndex = 14;
            this.textboxShapeWidth.TextChanged += new System.EventHandler(this.textboxShapeWidth_TextChanged);
            this.textboxShapeWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxShapeWidth_KeyPress);
            // 
            // textboxShapeHeight
            // 
            this.textboxShapeHeight.Location = new System.Drawing.Point(1162, 659);
            this.textboxShapeHeight.Name = "textboxShapeHeight";
            this.textboxShapeHeight.Size = new System.Drawing.Size(100, 26);
            this.textboxShapeHeight.TabIndex = 15;
            this.textboxShapeHeight.TextChanged += new System.EventHandler(this.textboxShapeHeight_TextChanged);
            this.textboxShapeHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxShapeHeight_KeyPress);
            // 
            // changeElipse
            // 
            this.changeElipse.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changeElipse.Location = new System.Drawing.Point(735, 650);
            this.changeElipse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.changeElipse.Name = "changeElipse";
            this.changeElipse.Size = new System.Drawing.Size(112, 35);
            this.changeElipse.TabIndex = 16;
            this.changeElipse.Text = "Elipse";
            this.changeElipse.UseVisualStyleBackColor = true;
            this.changeElipse.Click += new System.EventHandler(this.changeElipse_Click);
            // 
            // labelShapeWidth
            // 
            this.labelShapeWidth.AutoSize = true;
            this.labelShapeWidth.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelShapeWidth.Location = new System.Drawing.Point(1100, 627);
            this.labelShapeWidth.Name = "labelShapeWidth";
            this.labelShapeWidth.Size = new System.Drawing.Size(56, 23);
            this.labelShapeWidth.TabIndex = 17;
            this.labelShapeWidth.Text = "Width";
            // 
            // labelShapeHeight
            // 
            this.labelShapeHeight.AutoSize = true;
            this.labelShapeHeight.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelShapeHeight.Location = new System.Drawing.Point(1100, 659);
            this.labelShapeHeight.Name = "labelShapeHeight";
            this.labelShapeHeight.Size = new System.Drawing.Size(58, 23);
            this.labelShapeHeight.TabIndex = 18;
            this.labelShapeHeight.Text = "Height";
            // 
            // buttonFillShape
            // 
            this.buttonFillShape.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonFillShape.Location = new System.Drawing.Point(1150, 584);
            this.buttonFillShape.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonFillShape.Name = "buttonFillShape";
            this.buttonFillShape.Size = new System.Drawing.Size(112, 35);
            this.buttonFillShape.TabIndex = 19;
            this.buttonFillShape.Text = "Fill: Yes";
            this.buttonFillShape.UseVisualStyleBackColor = true;
            this.buttonFillShape.Click += new System.EventHandler(this.buttonFillShape_Click);
            // 
            // buttonEraseCanvas
            // 
            this.buttonEraseCanvas.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonEraseCanvas.Location = new System.Drawing.Point(735, 14);
            this.buttonEraseCanvas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonEraseCanvas.Name = "buttonEraseCanvas";
            this.buttonEraseCanvas.Size = new System.Drawing.Size(112, 35);
            this.buttonEraseCanvas.TabIndex = 20;
            this.buttonEraseCanvas.Text = "Erase All";
            this.buttonEraseCanvas.UseVisualStyleBackColor = true;
            this.buttonEraseCanvas.Click += new System.EventHandler(this.buttonEraseCanvas_Click);
            // 
            // changeHighlighter
            // 
            this.changeHighlighter.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changeHighlighter.Location = new System.Drawing.Point(975, 398);
            this.changeHighlighter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.changeHighlighter.Name = "changeHighlighter";
            this.changeHighlighter.Size = new System.Drawing.Size(112, 35);
            this.changeHighlighter.TabIndex = 21;
            this.changeHighlighter.Text = "Highlighter";
            this.changeHighlighter.UseVisualStyleBackColor = true;
            this.changeHighlighter.Click += new System.EventHandler(this.changeHighlighter_Click);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Font = new System.Drawing.Font("Comic Sans MS", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonHelp.Location = new System.Drawing.Point(1150, 14);
            this.buttonHelp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(112, 35);
            this.buttonHelp.TabIndex = 22;
            this.buttonHelp.Text = "Help";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1898, 1024);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.changeHighlighter);
            this.Controls.Add(this.buttonEraseCanvas);
            this.Controls.Add(this.buttonFillShape);
            this.Controls.Add(this.labelShapeHeight);
            this.Controls.Add(this.labelShapeWidth);
            this.Controls.Add(this.changeElipse);
            this.Controls.Add(this.textboxShapeHeight);
            this.Controls.Add(this.textboxShapeWidth);
            this.Controls.Add(this.changeRectangle);
            this.Controls.Add(this.changeEraser);
            this.Controls.Add(this.insertImage);
            this.Controls.Add(this.labelBlue);
            this.Controls.Add(this.labelGreen);
            this.Controls.Add(this.labelRed);
            this.Controls.Add(this.labelWidth);
            this.Controls.Add(this.sliderWidth);
            this.Controls.Add(this.sliderBlue);
            this.Controls.Add(this.sliderGreen);
            this.Controls.Add(this.sliderRed);
            this.Controls.Add(this.changeBrush2);
            this.Controls.Add(this.changeBrush1);
            this.Controls.Add(this.button1);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.sliderRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button changeBrush1;
        private System.Windows.Forms.Button changeBrush2;
        private System.Windows.Forms.TrackBar sliderRed;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar sliderGreen;
        private System.Windows.Forms.TrackBar sliderBlue;
        private System.Windows.Forms.TrackBar sliderWidth;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelRed;
        private System.Windows.Forms.Label labelGreen;
        private System.Windows.Forms.Label labelBlue;
        private System.Windows.Forms.Button insertImage;
        private System.Windows.Forms.Button changeEraser;
        private System.Windows.Forms.Button changeRectangle;
        private System.Windows.Forms.TextBox textboxShapeWidth;
        private System.Windows.Forms.TextBox textboxShapeHeight;
        private System.Windows.Forms.Button changeElipse;
        private System.Windows.Forms.Label labelShapeWidth;
        private System.Windows.Forms.Label labelShapeHeight;
        private System.Windows.Forms.Button buttonFillShape;
        private System.Windows.Forms.Button buttonEraseCanvas;
        private System.Windows.Forms.Button changeHighlighter;
        private System.Windows.Forms.Button buttonHelp;
    }
}

