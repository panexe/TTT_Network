using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CS;

namespace WindowsFormsApplication1
{
    public partial class GameWindow : Form
    {
        List<PictureBox> pboxs_xo;
        List<int> pressed_tiles;
        bool turn;
        bool host;
        
        string mysign;
        BoardState bstate;

        ServerController sc;
        ClientController cc;
        public GameWindow()
        {
            host = true;
            if (host) { mysign = "x"; }
            else{ mysign = "o"; }

            InitializeComponent();
            pressed_tiles = new List<int>();
            bstate = new BoardState();
            mysign = "X";
            turn = true;

            cc = new ClientController();
            pboxs_xo = new List<PictureBox>();
            pboxs_xo.Add(pbox_A1);
            pboxs_xo.Add(pbox_A2);
            pboxs_xo.Add(pbox_A3);
            pboxs_xo.Add(pbox_B1);
            pboxs_xo.Add(pbox_B2);
            pboxs_xo.Add(pbox_B3);
            pboxs_xo.Add(pbox_C1);
            pboxs_xo.Add(pbox_C2);
            pboxs_xo.Add(pbox_C3);
            foreach(PictureBox p in pboxs_xo)
            {
                pictureBox1.Controls.Add(p);
                p.BackColor = Color.Transparent;
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                
            }

            pictureBox1.Controls.Add(pbox_A2);
            pbox_A2.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            
        }

        public void updateBoard()
        {
            sc = new ServerController();
            BoardState b = new BoardState(sc.receiveBoard());
               



            // Setzt alle Tiles zum Boardstate (x&os)
            int temp = 0;
            for(int i = 0; i < 3; i++)
            {
                for(int u = 0; u < 3; u++)
                {
                    if(b.board[i, u] == 1)
                    {
                        pboxs_xo[temp].Image = Properties.Resources.x_image_png;
                    }
                    else if(b.board[i, u] == 2)
                    {
                        pboxs_xo[temp].Image = Properties.Resources.o_image_png1;
                    }
                    else if (b.board[i, u] == 0)
                    {
                        pboxs_xo[temp].Image = null;
                    }
                    temp++;
                }
            }
            bstate = b;
            // Lässt diesen spieler wieder einen zug machen 
            turn = true;
            
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
            button_press(y_click,x_click);

            //MessageBox.Show("x:"+x_click.ToString() +" y:"+ y_click);
            //MessageBox.Show("x:" +posx + " y:" + MousePosition.Y);

        }

        private void button_press(int row, int line)
        {
            int a = 0;
            a = (row - 1) * 3 + (line - 1);

            if (pboxs_xo[a].Image == null && host)
            {
                if (turn)
                {
                    pboxs_xo[a].Image = Properties.Resources.x_image_png;
                    turn = !turn;


                    // Nicht ideal weil doppelter rechenaufwand 
                    
                    try
                    {
                        bstate.board[convertatoxy(a)[0], convertatoxy(a)[1]] = 1;

                        cc.sendBoard(bstate);
                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    updateBoard();

                }
                else
                {
                    // wait for player 


                    //pboxs_xo[a].Image = Properties.Resources.o_image_png1;
                    //turn = !turn;
                }
            }
            else if(pboxs_xo[a].Image == null && host && turn)
            {
                pboxs_xo[a].Image = Properties.Resources.o_image_png1;
                turn = !turn;
                bstate.board[convertatoxy(a)[0], convertatoxy(a)[1]] = 2;
                cc.sendBoard(bstate);
                updateBoard();
            }


        }

        private int[] convertatoxy(int a)
        {
            int[] sum = new int[3];
            int temp = 0;
            if(a < 4)
            {
                sum[0] = 0;
                temp = a - 1;
                sum[1] = temp;
            }
            else if(a>3 && a < 7)
            {
                sum[0] = 1;
                temp = a - 4;
                sum[1] = temp;
            }
            else if(a > 6)
            {
                sum[0] = 2;
                temp = a - 7;
                sum[1] = temp;
            }
            return sum;
        }
    }
    }

