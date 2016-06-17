using Kudos.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

[assembly: InternalsVisibleToAttribute("Kudos.Tests")]

namespace Kudos
{
    public partial class KudosApi : IKudosApi
    {
        public string ApiToken { get; private set; }
        public string ApiVersion { get; private set; }

        /// <summary>
        /// SCIM base URL.
        /// </summary>
        private const string BaseUrl = "https://api.kudosnow.com/scim/v1/";

        private const string MediaType = "application/json";

        private readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings()
        {
            DateFormatString = "yyyy-MM-dd HH:mm:ss UTC"
        };

        private readonly JsonSerializerSettings UserSerializerSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };

        private HttpClient httpClient;

        private enum Methods
        {
            GET,
            POST,
            PATCH,
            DELETE
        }

        /// <summary>
        /// The content that was sent to the
        /// <see cref="System.Net.Http.HttpClient"/> object (either passed in
        /// from the <see cref="KudosApi(string,HttpClient)"/> constructor or
        /// otherwise internally created) for the most recent call. Made
        /// available to the unit test assembly only.
        /// </summary>
        internal string LastStringContent { get; private set; }

        public KudosApi(string apiToken, HttpClient client = null)
        {
            ApiToken = apiToken;
            ApiVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            httpClient = client ?? new HttpClient();
            httpClient.BaseAddress = new Uri(BaseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiToken);
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "kudos/" + ApiVersion + ";dotnet");
        }

        private async Task<T> Get<T>(string endpoint, CancellationToken cancel)
        {
            LastStringContent = null;
            return await RequestAsync<T>(endpoint, Methods.GET, null, cancel);
        }

        private async Task<T> Post<T>(string endpoint, StringContent content, CancellationToken cancel)
        {
            return await RequestAsync<T>(endpoint, Methods.POST, content, cancel);
        }

        private async Task<T> Update<T>(string endpoint, StringContent content, CancellationToken cancel)
        {
            return await RequestAsync<T>(endpoint, Methods.PATCH, content, cancel);
        }

        private async Task<T> Delete<T>(string endpoint, CancellationToken cancel)
        {
            LastStringContent = null;
            return await RequestAsync<T>(endpoint, Methods.DELETE, null, cancel);
        }

        private async Task<T> RequestAsync<T>(string path, Methods method, StringContent content,
            CancellationToken cancel)
        {
            try
            {
                string methodAsString = null;

                switch (method)
                {
                    case Methods.GET:
                        methodAsString = "GET";
                        break;

                    case Methods.POST:
                        methodAsString = "POST";
                        break;

                    case Methods.PATCH:
                        methodAsString = "PATCH";
                        break;

                    case Methods.DELETE:
                        methodAsString = "DELETE";
                        break;
                }

                using (HttpRequestMessage httpRequest = new HttpRequestMessage())
                {
                    httpRequest.Method = new HttpMethod(methodAsString);
                    httpRequest.RequestUri = new Uri(BaseUrl + path);
                    httpRequest.Content = content;

                    using (HttpResponseMessage response = await httpClient.SendAsync(httpRequest, cancel).ConfigureAwait(false))
                    {
                        string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        try
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                return JsonConvert.DeserializeObject<T>(json, SerializerSettings);
                            }

                            ErrorResponse error = JsonConvert.DeserializeObject<ErrorResponse>(json);

                            throw new KudosException(error,
                                string.Format("{0} failed to {1}", methodAsString, path));
                        }
                        catch (JsonException)
                        {
                            throw new KudosException(string.Format("Serialization error to {0} {1}",
                                methodAsString, path));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string message = string.Format(".NET {0}, raw message: \n\n{1}",
                    (e is HttpRequestException) ? "HttpRequestException" : "Exception",
                    e.GetBaseException().Message);

                throw new KudosException(message);
            }
        }
    }
}
