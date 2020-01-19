using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Infrastructure.Gateway.Contracts
{
    public interface IContentGateway
    {
        Task<HttpContentHeaders> GetContentHeaders(string url);
    }
}
