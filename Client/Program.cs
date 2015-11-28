using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.StartClient();
            
            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }
    }
}
