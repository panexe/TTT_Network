using System;
using WindowsFormsApplication1;
using System.Windows.Forms;
using Server;

public class ClientController
{
    Server.ClientSocket clientSocket;
    int PORT;
    string ip;
    Move move;
    public ClientController()
    {

        PORT = 50500;
        ip = "localhost";



        clientSocket = new ClientSocket(PORT);

    }

    public void sendBoard(CS.BoardState b)
    {
        clientSocket.connect();

        for (int i = 0; i < 2; i++)
        {
            for (int u = 0; u < 2; u++)
            {
                clientSocket.write(Convert.ToString(b.board[i, u]));
            }
        }
    }
}
