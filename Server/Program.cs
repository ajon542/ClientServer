using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleServer server = new SimpleServer();
            server.Listen();
            //server.StartListening();

            int x;
            char ch;

            Console.WriteLine("Press 's' to send, 'q' to quit.");
            do
            {
                x = Console.Read();
                ch = Convert.ToChar(x);

                if (ch == 's')
                {
                    server.Send("HellowWorld");
                }

            } while (ch != 'q');

            return;

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }
    }
}
