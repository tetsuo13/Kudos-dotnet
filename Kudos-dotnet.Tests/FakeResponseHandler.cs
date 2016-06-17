using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Kudos.Tests
{
    /// <summary>
    /// A shim for
    /// <see cref="System.Net.Http.HttpClient(HttpMessageHandler)"/> to enable
    /// mocking a complete <see cref="System.Net.Http.HttpResponseMessage"/>
    /// object.
    /// </summary>
    /// <seealso href="https://stackoverflow.com/a/22264503">
    /// Stack Overflow - How to pass in a mocked HttpClient in a .NET test?
    /// </seealso>
    internal class FakeResponseHandler : DelegatingHandler
    {
        /// <summary>
        /// The response to mock.
        /// </summary>
        public HttpResponseMessage Response { get; set; }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                return Response;
            });
        }
    }
}
