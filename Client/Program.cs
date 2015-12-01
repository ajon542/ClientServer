using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleClient client = new SimpleClient();
            client.Connect();

            int x;
            char ch;

            Console.WriteLine("Press 's' to send, 'q' to quit.");
            do
            {
                x = Console.Read();
                ch = Convert.ToChar(x);

                if (ch == 's')
                {
                    client.Send("Hello");
                }
                if (ch == 'c')
                {
                    client.Close();
                }

            } while (ch != 'q');

            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }
    }
}
