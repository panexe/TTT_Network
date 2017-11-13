using System;
using __ClientSocket__;
using WindowsFormsApplication1;
using System.Windows.Forms;

public class ClientController
{
    ClientSocket clientSocket;
    int PORT;
    string ip;
    Move move;
    public ClientController()
    {

        PORT = 50500;
        ip = "localhost";

        move = new Move();

        clientSocket = new ClientSocket(ip, PORT);

    }

    public bool sendMove(Move _move)
    {
        try
        {
            // vebindet
            clientSocket = new ClientSocket(ip, PORT);
            try
            {
                clientSocket.write(_move.Tile);
                if (clientSocket.readLine() == "OK")
                {
                    clientSocket.close();
                    return true;
                }
                else
                {
                    clientSocket.close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {

        }
        return false;
    }
}
