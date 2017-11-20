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
    public partial class GameWindow : Form
    {
        List<int> pressed_tiles;
        bool turn;
        string mysign;

        ServerController sc;
        ClientController cc;
        public GameWindow()
        {
            InitializeComponent();
            pressed_tiles = new List<int>();
            mysign = "X";
            turn = true;
            sc = new ServerController();
            cc = new ClientController();

            


            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (turn)
            {
                Button b = sender as Button;
                string id = b.Name.Substring(b.Name.Length - 1);

                foreach (int i in pressed_tiles)
                {
                    if (Convert.ToInt32(id) == i)
                    {
                        return;
                    }


                }

                if (turn)
                    b.Text = mysign;
                
                pressed_tiles.Add(Convert.ToInt32(id));
                //cc.sendMove(new Move());
                turn = false;
                
            }
        }


        private void WaitScreen()
        {
            Move m = sc.receiveMove();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int x_click = 0;
            int y_click = 0;
            int posx = MousePosition.X -this.Location.X;
            int posy = MousePosition.Y - this.Location.Y;


            if (posx <= pictureBox1.Width / 3)
            {
                x_click = 1;
            }
            else if(posx >= (pictureBox1.Width /3) && posx <= ((pictureBox1.Width / 3) * 2))
            {
                x_click = 2;
            }
            else if(posx >= ((pictureBox1.Width / 3) *2))
            {
                x_click = 3;
            }

            if (posy <= pictureBox1.Width / 3)
            {
                y_click = 1;
            }
            else if (posy >= (pictureBox1.Width / 3) && posy <= ((pictureBox1.Width / 3) * 2))
            {
                y_click = 2;
            }
            else if (posy >= ((pictureBox1.Width / 3) * 2))
            {
                y_click = 3;
            }


            MessageBox.Show("x:"+x_click.ToString() +" y:"+ y_click);
            MessageBox.Show("x:" +posx + " y:" + MousePosition.Y);

        }
    }
    }

