﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
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
            RunAsync().GetAwaiter().GetResult();
            Console.ReadLine();
        }

        private static async Task RunAsync()
        {
            var tokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(KeyName, Key);
            var uri = new Uri(string.Format("https://{0}/{1}", RelayNamespace, ConnectionName));
            var token = (await tokenProvider.GetTokenAsync(uri.AbsoluteUri, TimeSpan.FromHours(1))).TokenString;

            var client = new HttpClient();
            var request = new HttpRequestMessage()
            {
                RequestUri = uri,
                Method = HttpMethod.Get,
            };

            request.Headers.Add("ServiceBusAuthorization", token);
            var response = await client.SendAsync(request);

            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }
}
