using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    class SimpleServer
    {
        Socket listener;
        Socket client;
        byte[] buffer = new byte[1024];

        public void Listen()
        {
            try
            {
                // Establish the local endpoint for the socket.
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP socket.
                listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Bind to the local endpoint.
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Block until a connection is accepted.
                Console.WriteLine("Waiting for a connection...");
                client = listener.Accept();
                Console.WriteLine("Connection Established.");

                client.BeginReceive(buffer, 0, 1024, 0,
                    new AsyncCallback(ReceiveCallback), null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Send(string msg)
        {
            try
            {
                //byte[] data = Encoding.ASCII.GetBytes(msg);
                byte[] data = new byte[1024];
                client.Send(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Read data from the remote device.
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    Console.WriteLine("Server Received: {0}", bytesRead);

                    // Continue receiving data.
                    client.BeginReceive(buffer, 0, 1024, 0,
                        new AsyncCallback(ReceiveCallback), null);
                }
                else
                {
                    // If the client closes the socket normally, bytes read will be 0.
                    // We also want to close the connection and begin listening again.
                    Console.WriteLine("Received nothing");
                    //listener.Shutdown(SocketShutdown.Both);
                    listener.Close();
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                    Listen();
                }

            }
            catch (Exception e)
            {
                // This occurs mainly when a client forcibly shuts down
                // the connection. In this case, close the listener and
                // start listening for new connections.
                Console.WriteLine(e);
                listener.Close();
                listener.Shutdown(SocketShutdown.Both);
                client.Shutdown(SocketShutdown.Both);
                client.Close();
                Listen();
            }
        }
    }
}
