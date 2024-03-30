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
            ((System.ComponentModel.ISupportInitialize)(this.sliderRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // changeBrush1
            // 
            this.changeBrush1.Location = new System.Drawing.Point(719, 430);
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
            this.changeBrush2.Location = new System.Drawing.Point(839, 430);
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
            this.sliderRed.Size = new System.Drawing.Size(339, 69);
            this.sliderRed.TabIndex = 2;
            this.sliderRed.Scroll += new System.EventHandler(this.sliderRed_Scroll);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.BackgroundImage = global::PaintApp.Properties.Resources.Screenshot_Videoclip_Never_Gonna_Give_You_Up;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(700, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(560, 700);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // sliderGreen
            // 
            this.sliderGreen.BackColor = System.Drawing.Color.Green;
            this.sliderGreen.Location = new System.Drawing.Point(907, 241);
            this.sliderGreen.Maximum = 255;
            this.sliderGreen.Name = "sliderGreen";
            this.sliderGreen.Size = new System.Drawing.Size(339, 69);
            this.sliderGreen.TabIndex = 4;
            this.sliderGreen.Scroll += new System.EventHandler(this.sliderGreen_Scroll);
            // 
            // sliderBlue
            // 
            this.sliderBlue.BackColor = System.Drawing.Color.Blue;
            this.sliderBlue.Location = new System.Drawing.Point(907, 321);
            this.sliderBlue.Maximum = 255;
            this.sliderBlue.Name = "sliderBlue";
            this.sliderBlue.Size = new System.Drawing.Size(339, 69);
            this.sliderBlue.TabIndex = 5;
            this.sliderBlue.Scroll += new System.EventHandler(this.sliderBlue_Scroll);
            // 
            // sliderWidth
            // 
            this.sliderWidth.Location = new System.Drawing.Point(907, 25);
            this.sliderWidth.Minimum = 1;
            this.sliderWidth.Name = "sliderWidth";
            this.sliderWidth.Size = new System.Drawing.Size(339, 69);
            this.sliderWidth.TabIndex = 6;
            this.sliderWidth.Value = 1;
            this.sliderWidth.Scroll += new System.EventHandler(this.sliderWidth_Scroll);
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.labelWidth.Location = new System.Drawing.Point(833, 25);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 664);
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
    }
}

