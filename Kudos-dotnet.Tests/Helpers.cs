using System.IO;
using System.Net;
using System.Net.Http;

namespace Kudos.Tests
{
    internal static class Helpers
    {
        public static HttpClient PrepareHttpClient(string jsonResponse)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = new StringContent(jsonResponse);

            FakeResponseHandler responseHandler = new FakeResponseHandler();
            responseHandler.Response = httpResponseMessage;

            return new HttpClient(responseHandler);
        }

        public static string ReadExternalJsonFile(string directory, string filename)
        {
            string path = Path.Combine(@"..", "..", directory, filename);
            return File.ReadAllText(path);
        }
    }
}
