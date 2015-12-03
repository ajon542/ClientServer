using System;

namespace Server
{
    class Program
    {
        static void Hello(BaseMsg msg)
        {
            Console.WriteLine("Hello");
        }

        static void Main(string[] args)
        {
            // Example of registering and invoking a service.
            IServerContext context = new ServerContext();
            context.RegisterService("hello", Hello);
            context.InvokeService(new BaseMsg { Type = "hello" });



            SimpleServer server = new SimpleServer();
            server.Listen();

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
        }
    }
}
