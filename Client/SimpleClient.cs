﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    /// <summary>
    /// Basic client implementation.
    /// </summary>
    class SimpleClient
    {
        private Socket client;
        private byte[] buffer = new byte[1024];

        public void Connect()
        {
            try
            {
                // Establish the remote endpoint for the socket.
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP socket.
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.
                client.Connect(remoteEP);

                Console.WriteLine("Client connected to {0}", client.RemoteEndPoint);

                client.BeginReceive(buffer, 0, 1024, 0, ReceiveCallback, null);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }


        public void Send(string msg)
        {
            try
            {
                byte[] data = Encoding.ASCII.GetBytes(msg);
                int bytesSent = client.Send(data);
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

                Console.WriteLine("Client Received: {0}", bytesRead);

                byte[] data = new byte[bytesRead];
                Array.Copy(buffer, 0, data, 0, bytesRead);

                // Get the rest of the data.
                client.BeginReceive(buffer, 0, 1024, 0, ReceiveCallback, null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Close()
        {
            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }
    }
}
