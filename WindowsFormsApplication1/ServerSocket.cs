using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ServerSocket
    {
        string data { get; set; }

        byte[] bytes = new byte[1024];

        Socket ssocket;

        Socket handler;



        IPHostEntry ipHostInfo;
        IPAddress ipAddress;
        IPEndPoint localEndPoint;

        public ServerSocket(int port)
        {
            // Lokalen Endpunkt für den Socket erstellen

            ipHostInfo = Dns.Resolve(Dns.GetHostName());
            ipAddress = ipHostInfo.AddressList[0];
            localEndPoint = new IPEndPoint(ipAddress, port);


            // Socket erstellen
            ssocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            start();
        }

        public bool start()
        {
            try
            {
                ssocket.Bind(localEndPoint);
                ssocket.Listen(10);

                while (true)
                {
                    Console.WriteLine("Verbinde...");
                    handler = ssocket.Accept();


                    Console.WriteLine("Verbunden!");
                    return true;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public string readLine()
        {
            try
            {
                data = null;

                while (true)
                {
                    bytes = new byte[1024];
                    int bytesrec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesrec);
                    if (data.IndexOf("<EOT>") > -1)
                    {

                        return data;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "ERROR";
            }
        }

        public void write(string text)
        {
            try
            {
                byte[] msg = Encoding.ASCII.GetBytes(text);
                handler.Send(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void close()
        {
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
    }
}
