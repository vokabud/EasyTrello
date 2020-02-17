namespace EaseTrello.Services
{
    using System.Net.Http.Formatting;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Interfaces;
    using Extension;
    using Models;
    using Models.Internal;

    public class CardService : ICardService
    {
        private readonly IHttpClient _httpClient;
        private readonly ClientGrand _clientGrand;

        public CardService(
            IHttpClient httpClient, 
            IAccessProvided accessProvided)
        {
            this._httpClient = httpClient;
            this._clientGrand = accessProvided.Grand;
        }
        
        public async Task<IdResponse> AddCard(string idList, CardRequest card)
        {
            var addCardUdl = $"https://api.trello.com/1/cards?idList={idList}&"
                .AddTrelloIdentity(this._clientGrand);

            using (var request = await this._httpClient.PostAsync(
                new Uri(addCardUdl),
                card,
                new JsonMediaTypeFormatter()))
            {
                return request.IsSuccessStatusCode
                    ? await request.Content.ReadAsAsync<IdResponse>()
                    : throw new Exception();
            }
        }
    }
}
