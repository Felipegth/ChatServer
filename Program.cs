using System;
using SignalR.Hubs;

namespace SignalR.Hosting.Self.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://127.0.0.1:8088/";
            var server = new Server(url);

            // Map the default hub url (/signalr)
            server.MapHubs();

            // Start the server
            server.Start();

            Console.WriteLine("Servidor Rodando em {0}", url);

            // Keep going until somebody hits 'x'
            while (true)
            {
                ConsoleKeyInfo ki = Console.ReadKey(true);
                if (ki.Key == ConsoleKey.X)
                {
                    break;
                }
            }
        }

        [HubName("CustomHub")]
        public class MyHub : Hub
        {
            public string Send(string message)
            {
                Clients.All.broadcastMessage(message);
                Console.WriteLine(message);
                return message;
            }

            public void DoSomething(string name, string param)
            {
                Clients.addMessage(name, param);
                Console.WriteLine(param);
            }
        }
    }
}
