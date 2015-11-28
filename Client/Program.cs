using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
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
