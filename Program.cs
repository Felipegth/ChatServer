using System;
using SignalR.Hubs;
using SignalR.Hosting.Self;

namespace SignalR.Chat.Serv
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://127.0.0.1:8088/";   
            var server = new Server(url);

            // Mapeia a url do hub padrão (/signalr)    
            server.MapHubs();
               
            // Inicia o Servidor
            server.Start();

            Console.WriteLine("Servidor Rodando em {0}", url);

            // Continue até alguem digitar 'x'   
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
