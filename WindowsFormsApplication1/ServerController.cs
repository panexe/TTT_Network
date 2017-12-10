using System;
using WindowsFormsApplication1;
using System.Windows.Forms;
using CS;
using System.Collections.Generic;

public class ServerController
{
    string ip;
    int PORT;
    Server.ServerSocket serverSocket;


    public ServerController()
	{
        PORT = 50500;
        serverSocket = new Server.ServerSocket(PORT);
         
	}
    public int[,] receiveBoard()
    {
        List<int> temp = new List<int>();
        int i = 0;
        while (i < 9)
        {
            try
            {
                //temp.Add(Convert.ToInt32(serverSocket.readLine()));
                MessageBox.Show(serverSocket.readLine());

            }catch(FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
            // ToDo Exception abfangen mit tryParse
        }

        int[,] board = new int[3, 3];
        int tempint = 0;
        for (int a = 0; a < 3; a++)
        {
            for (int u = 0; u < 3; u++)
            {
                board[a, u] = temp[tempint];
                tempint++;
            }
        }

        return board;

          
    }
}
