using System;
using System.Net.Http;

namespace Firebase
{
    internal sealed class TransientHttpClientFactory : IHttpClientFactory
    {
        private HttpClient HttpClient { get; set; }

        internal TransientHttpClientFactory(HttpClient client)
        {
            this.HttpClient = client;
        }

        public IHttpClientProxy GetHttpClient(TimeSpan? timeout)
        {
            Func<HttpClient> createOneTimeClient = () =>
            {
                var client = new HttpClient();
                if(timeout != null)
                {
                    client.Timeout = timeout.Value;
                }
                return client;
            };
            var client = this.HttpClient ?? createOneTimeClient();
            return new SimpleHttpClientProxy(client);
        }
    }
}
