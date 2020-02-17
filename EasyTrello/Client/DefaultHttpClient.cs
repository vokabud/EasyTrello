namespace EaseTrello.Client
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Threading.Tasks;
    using Interfaces;

    public sealed class DefaultHttpClient : IHttpClient, IDisposable
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultHttpClient"/> class.
        /// </summary>
        public DefaultHttpClient()
        {
            this._httpClient = new HttpClient();
        }

        /// <inheritdoc />
        public Task<HttpResponseMessage> GetAsync(Uri requestUri)
        {
            return this
                ._httpClient
                .GetAsync(requestUri);
        }

        /// <inheritdoc />
        public Task<HttpResponseMessage> PostAsync<T>(Uri requestUri, T value, MediaTypeFormatter formatter)
        {
            return this
                ._httpClient
                .PostAsync(requestUri, value, formatter);
        }

        /// <inheritdoc />
        /// <summary>
        /// Releases the unmanaged resources and disposes of the managed resources
        /// </summary>
        public void Dispose()
        {
            this
                ._httpClient?
                .Dispose();
        }
    }
}
