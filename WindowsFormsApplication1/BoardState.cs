using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS
{
    public class BoardState
    {
        public int[,] board { get; set; } // Array mit 0 für ungesetzt und 1&2 für die spieler 
        bool won;   // gibt an ob das spiel verloren wurde 
        int winning_sign; // 1 oder 2 Spieler , 0 für none
        
        public BoardState(int[,] _board)
        {
            if (_board.Length == 9)
                board = _board;

            int cfw = checkForWin(board);
            if (cfw != 0)
            {
                won = true;
                winning_sign = cfw;
            }
            else
            {
                won = false;
                winning_sign = 0;
            }


        }

        public BoardState()
        {
            won = false;
            winning_sign = 0;
            board = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        }

        private int checkForWin(int[,] arr)
        {
            int counter = 0;

            // Horizontale

            // Zählt Reihe von Links nach Rechts
            for (int i = 0; i < 3; i++)
            {
                // Zählt Zeile von Oben nach Unten
                for (int u = 0; u < 3; u++)
                {
                    if (arr[i, u] == 1)
                    {
                        counter++;
                    }
                }// end u loop

                if (counter == 3)
                {
                    return arr[i, 0];
                }
                counter = 0;

            }// end i loop

            // Vertikale

            // Zählt Zeile von Oben nach Unten
            for (int i = 0; i < 3; i++)
            {
                // Zählt Reihe von Links nach Rechts
                for (int u = 0; u < 3; u++)
                {
                    if (arr[u, i] == 1)
                    {
                        counter++;
                    }
                }// end u loop
                if (counter == 3)
                {
                    return arr[i, 0];
                }
                counter = 0;

            }// end i loop

            // Diagonale 1
            for (int i = 0; i < 3; i++)
            {
                if (arr[i, i] < 0)
                {
                    counter++;
                }
                if (counter == 3)
                    return arr[0, 0];
            }
            counter = 0;

            //Diagonale 2
            if (arr[0, 2] < 0 &&
                arr[1, 1] < 0 &&
                  arr[2, 0] < 0)
            {
                return arr[0, 2];
            }
            else { return 0; }

        }
    }
}
