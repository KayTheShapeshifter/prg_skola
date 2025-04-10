namespace hratky_s_formama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            int origSize = button0.Width;
            int [] origPos = new int[2] { button0.Location.X, button0.Location.Y }; 

            button0.Location = new Point(origPos[0] - 10, origPos[1] - 10);
            button0.Width = origSize + 20;
            button0.Height = origSize + 20;
            Thread.Sleep(100);

            button0.Location = new Point(origPos[0], origPos[1]);
            button0.Width = origSize;
            button0.Height = origSize;

            textBoxInput.Text += "0";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += "1";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += "2";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += "3";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += "4";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += "5";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += "6";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += "7";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += "8";

        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBoxInput.Text += "9";

        }
        private void buttonEnter_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D0:
                    button0_Click(this, EventArgs.Empty);
                    break;
                case Keys.D1:
                    button1_Click(this, EventArgs.Empty);
                    break;
                case Keys.D2:
                    button2_Click(this, EventArgs.Empty);
                    break;
                case Keys.D3:
                    button3_Click(this, EventArgs.Empty);
                    break;
                case Keys.D4:
                    button4_Click(this, EventArgs.Empty);
                    break;
                case Keys.D5:
                    button5_Click(this, EventArgs.Empty);
                    break;
                case Keys.D6:
                    button6_Click(this, EventArgs.Empty);
                    break;
                case Keys.D7:
                    button7_Click(this, EventArgs.Empty);
                    break;
                case Keys.D8:
                    button8_Click(this, EventArgs.Empty);
                    break;
                case Keys.D9:
                    button9_Click(this, EventArgs.Empty);
                    break;
                case Keys.Enter:
                    buttonEnter_Click(this, EventArgs.Empty);
                    break;
                default:
                    break;
            }

        }

       
    }
}
