using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientSocket
    {
        byte[] bytes = new byte[1024];

        Socket sender;

        IPHostEntry ipHostInfo;
        IPAddress ipAddress;
        IPEndPoint remoteEP;
        bool connected;
        public ClientSocket(int port)
        {

            connected = false;
            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            remoteEP = new IPEndPoint(ipAddress, port);

            sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void start()
        {

        }

        public bool connect()
        {
            try
            {
                sender.Connect(remoteEP);
                //Console.WriteLine("Verbunden!");
                connected = true;
                return true;

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                connected = false;
                return false;
            }

        }

        public void write(string text)
        {
            if (connected)
            {
                //byte[] msg = Encoding.ASCII.GetBytes(text+"<EOT>");
                byte[] msg = Encoding.ASCII.GetBytes(text);
                int bytesSent = sender.Send(msg);
            }
            
        }

        public string readLine()
        {
            try
            {
                string s;
                int bytesRec = sender.Receive(bytes);
                s = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                Console.WriteLine(s);
                return s;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();


            }

        }
    }
}
