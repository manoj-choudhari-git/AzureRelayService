using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Relay;

namespace Sender
{
    class Program
    {
        private const string RelayNamespace = "{RelayNamespace}.servicebus.windows.net";
        private const string ConnectionName = "{HybridConnectionName}";
        private const string KeyName = "{SASKeyName}";
        private const string Key = "{SASKey}";

        static void Main(string[] args)
        {
            Console.WriteLine("========================================================");
            Console.WriteLine("SENDER Application: Sending Messages");
            Console.WriteLine("========================================================");
            RunAsync().GetAwaiter().GetResult();
        }

        private static async Task RunAsync()
        {

            // Create a new hybrid connection client.
            var tokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(KeyName, Key);
            var client = new HybridConnectionClient(new Uri(String.Format("sb://{0}/{1}", RelayNamespace, ConnectionName)), tokenProvider);
            
            // Initiate the connection.
            var relayConnection = await client.CreateConnectionAsync();

            Console.WriteLine("Enter lines of text to send to the server with ENTER");
            var reader = new StreamReader(relayConnection);
            var writer = new StreamWriter(relayConnection) { AutoFlush = true };
            while (true)
            {
                var messageToSend = Console.ReadLine();
                if(string.IsNullOrEmpty(messageToSend))
                {
                    break;
                }

                await writer.WriteLineAsync(messageToSend);
                var textFromListener = await reader.ReadLineAsync();
                Console.WriteLine(textFromListener);
            }
            
            await relayConnection.CloseAsync(CancellationToken.None);
        }
    }
}