using ComedyHub.Core.Infrastructure.Gateway.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Infrastructure.Gateway
{
    public class ContentGateway : IContentGateway
    {
        public async Task<HttpContentHeaders> GetContentHeaders(string url)
        {
            using (var client = new HttpClient())
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Head, url);

                var responseMessage = await client.SendAsync(requestMessage);

                var responseMessageHeaders = responseMessage.Content.Headers;

                return responseMessageHeaders;
            }
        }
    }
}
