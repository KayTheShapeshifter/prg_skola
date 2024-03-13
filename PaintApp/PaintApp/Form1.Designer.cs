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
            ((System.ComponentModel.ISupportInitialize)(this.sliderRed)).BeginInit();
            this.SuspendLayout();
            // 
            // changeBrush1
            // 
            this.changeBrush1.Location = new System.Drawing.Point(791, 12);
            this.changeBrush1.Name = "changeBrush1";
            this.changeBrush1.Size = new System.Drawing.Size(75, 23);
            this.changeBrush1.TabIndex = 0;
            this.changeBrush1.Text = "Brush 1";
            this.changeBrush1.UseVisualStyleBackColor = true;
            this.changeBrush1.Click += new System.EventHandler(this.changeBrush1_Click);
            // 
            // changeBrush2
            // 
            this.changeBrush2.Location = new System.Drawing.Point(791, 41);
            this.changeBrush2.Name = "changeBrush2";
            this.changeBrush2.Size = new System.Drawing.Size(75, 23);
            this.changeBrush2.TabIndex = 1;
            this.changeBrush2.Text = "Brush 2";
            this.changeBrush2.UseVisualStyleBackColor = true;
            this.changeBrush2.Click += new System.EventHandler(this.changeBrush2_Click);
            // 
            // sliderRed
            // 
            this.sliderRed.BackColor = System.Drawing.Color.Red;
            this.sliderRed.Location = new System.Drawing.Point(640, 70);
            this.sliderRed.Maximum = 255;
            this.sliderRed.Name = "sliderRed";
            this.sliderRed.Size = new System.Drawing.Size(226, 45);
            this.sliderRed.TabIndex = 2;
            this.sliderRed.Scroll += new System.EventHandler(this.sliderRed_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 506);
            this.Controls.Add(this.sliderRed);
            this.Controls.Add(this.changeBrush2);
            this.Controls.Add(this.changeBrush1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.sliderRed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button changeBrush1;
        private System.Windows.Forms.Button changeBrush2;
        private System.Windows.Forms.TrackBar sliderRed;
    }
}

