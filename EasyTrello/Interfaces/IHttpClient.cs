namespace EaseTrello.Interfaces
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Threading.Tasks;

    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(Uri requestUri);

        Task<HttpResponseMessage> PostAsync<T>(Uri requestUri, T value, MediaTypeFormatter formatter);
    }
}
