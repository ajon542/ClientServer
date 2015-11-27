using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Init();

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }
    }
}
