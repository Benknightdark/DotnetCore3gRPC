using System;
using System.Net.Http;
using Greet;
using Grpc.Net.Client;

namespace client
{
    public class Program
    {
        static  void Main(string[] args)
        {
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport",
                true);
            var httpClient = new HttpClient();
            // The port number(50051) must match the port of the gRPC server.
            httpClient.BaseAddress = new Uri("http://localhost:50051");
             var client = GrpcClient.Create<Greeter.GreeterClient>(httpClient);
            // var client = new Greeter.GreeterClient(channel);

            var reply =  client.SayHello(
                              new HelloRequest { Name = "YO" });
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
    
    
}
