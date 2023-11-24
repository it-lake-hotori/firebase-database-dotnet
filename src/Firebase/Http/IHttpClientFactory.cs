using System;
using System.Net.Http;

namespace Firebase
{
    public interface IHttpClientFactory
    {
        IHttpClientProxy GetHttpClient(TimeSpan? timeout);
    }
}
