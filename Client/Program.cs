using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // Opening a connection for each message is just not going to work.
            // This is ok for the client to get information from the server, but there
            // is no way for the server to send a message to the client this way.
            // We must leave the socket open when the client connects. However, I have
            // encountered some issues when closing the connection under these circumstances.
            // For example, if we start a BeginReceive and then close the connection, it seems
            // to get an exception because something in the receive callback comes through
            // after the connection is closed.
            Client client = new Client();
            client.StartClient();

            int x;
            char ch;

            Console.WriteLine("Press 's' to send, 'q' to quit.");
            do
            {
                x = Console.Read();
                ch = Convert.ToChar(x);

                if (ch == 's')
                {
                    client.StartClient();
                }

            } while (ch != 'q');
            
            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }
    }
}
