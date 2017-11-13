using System;
using __ServerSocket__;
using __ClientSocket__;
using WindowsFormsApplication1;
using System.Windows.Forms;

public class ServerController
{
    string ip;
    int PORT;
    ServerSocket serverSocket;
    ClientSocket clientSocket;

    public ServerController()
	{
        PORT = 50500;
        
	}
    public void receiveMove()
    {
        Move move = new Move();
        try
        {
            // startet server & weist clientsocket zu
            serverSocket = new ServerSocket(PORT);
            clientSocket = serverSocket.accept();
            try
            {
                string s = clientSocket.readLine();
                int a;
                if (int.TryParse(s, out a))
                {
                    move.Tile = Convert.ToInt32(s);
                    clientSocket.write("OK");
                }
                else
                {
                    clientSocket.write("FAIL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
            
        }
        finally
        {
            clientSocket.close();
            serverSocket.close();
        }
    }
}
