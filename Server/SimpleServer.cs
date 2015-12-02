using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    /// <summary>
    /// Basic server implementation.
    /// </summary>
    class SimpleServer
    {
        private Socket listener;
        private Socket client;
        private byte[] buffer = new byte[1024];

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

                client.BeginReceive(buffer, 0, 1024, 0, ReceiveCallback, null);
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
                byte[] data = Encoding.ASCII.GetBytes(msg);
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

                    byte[] data = new byte[bytesRead];
                    Array.Copy(buffer, 0, data, 0, bytesRead);

                    // Continue receiving data.
                    client.BeginReceive(buffer, 0, 1024, 0, ReceiveCallback, null);
                }
                else
                {
                    // If the client closes the socket normally, bytes read will be 0.
                    // We also want to close the connection and begin listening again.
                    Close();
                    Listen();
                }

            }
            catch (Exception e)
            {
                // This occurs mainly when a client forcibly shuts down
                // the connection. In this case, close the listener and
                // start listening for new connections.
                Console.WriteLine(e);

                Close();
                Listen();
            }
        }

        private void Close()
        {
            // TODO: listener.Shutdown causes an exception to be thrown. Not sure why.
            //listener.Shutdown(SocketShutdown.Both);
            listener.Close();
            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }
    }
}
