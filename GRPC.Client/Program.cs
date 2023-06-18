using Grpc.Net.Client;
using GrpcServer;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.Write("Ingresar un mensaje a enviar: ");
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                var message = new MessageRequest { Input = input } ;
                var channel = GrpcChannel.ForAddress("https://localhost:7038");
                var client = new Hub.HubClient(channel);
                var reply = await client.SendAsync(message);
                Console.WriteLine(reply.Output);
            }   
        }
    }
}