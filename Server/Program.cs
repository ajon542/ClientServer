using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.StartListening();

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }
    }
}
