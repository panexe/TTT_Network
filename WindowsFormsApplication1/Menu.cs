using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int x_button = 0;
            int y_button = 0;
            int posx = MousePosition.X - this.Location.X;
            int posy = MousePosition.Y - this.Location.Y;

            if(posy <= (pictureBox1.Size.Width / 3))
            {
                y_button = 1;
                Form TTT = new GameWindow();
                TTT.Show();

            }
            else if(posy >= ((pictureBox1.Size.Width)/3) && posy <= pictureBox1.Size.Width)
            {
                y_button = 2;
                

            }
            if(posy >= (((pictureBox1.Size.Width) / 3)*2))
            {
                y_button = 3;
            }
            if (posx < ((pictureBox1.Size.Width / 3)*2))
            {
                x_button = 1;

            }
            else if (posx > ((pictureBox1.Size.Width / 3) * 2))
            {
                x_button = 2;
                this.Close();
            }
            MessageBox.Show("x:"+x_button.ToString() +  " y:"+y_button);
        }
    }
}
