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
        Class1 cc;
        public GameWindow()
        {
            InitializeComponent();
            pressed_tiles = new List<int>();
            mysign = "X";
            turn = true;
            sc = new ServerController();
            cc = new Class1();
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
                
                turn = false;
                
            }
        }


        private void WaitScreen()
        {
            sc.receiveMove();
        }



        }
    }

