using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.Connect("127.0.0.1", "Hello");
            
            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }
    }
}
