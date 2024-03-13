using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tešt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Random random = new Random();
            int red = random.Next(0, 255);
            int green = random.Next(0, 255);
            int blue = random.Next(0, 255);
            Color myColor = Color.FromArgb(red, green, blue);
            button1.BackColor = myColor;
            int xCoor = random.Next(0, 1920);
            int yCoor = random.Next(0, 1080);
            button1.Location = new Point(xCoor, yCoor);
            List<string> hahaQuotes = new List<string>() { "Git Gud","You suck ass", "HaHa", "Lamee","my grandma could do better"  };
            int quoteListPos = random.Next(0, hahaQuotes.Count());
            button1.Text = hahaQuotes[quoteListPos];
        }
    }
}
