using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.StartListening();

            int x;
            char ch;

            Console.WriteLine("Press 's' to send, 'q' to quit.");
            do
            {
                x = Console.Read();
                ch = Convert.ToChar(x);

                if (ch == 's')
                {
                    server.Send();
                }

            } while (ch != 'q');

            return;

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }
    }
}
