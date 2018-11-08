using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CPMG3.API.Handlers
{
    public class GitHeadersHandler : HttpClientHandler
    {
        private const string HEADER_ACCEPT_NAME = "Accept";
        private const string HEADER_ACCEPT_VALUE = "application/vnd.github.v3+json";
        private const string HEADER_USER_AGENT_NAME = "User-Agent";
        private const string HEADER_USER_AGENT_VALUE = "tanure";

        public GitHeadersHandler()
        {
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add(HEADER_ACCEPT_NAME, HEADER_ACCEPT_VALUE);
            request.Headers.Add(HEADER_USER_AGENT_NAME, HEADER_USER_AGENT_VALUE);

            return base.SendAsync(request, cancellationToken);
        }
    }
}
