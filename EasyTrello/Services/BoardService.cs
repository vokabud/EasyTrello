namespace EaseTrello.Services
{
    using System;
    using System.Net.Http.Formatting;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Interfaces;
    using Extension;
    using Models;
    using Models.Internal;

    public class BoardService : IBoardService
    {
        private readonly IHttpClient _httpClient;

        private readonly ClientGrand _clientGrand;

        public BoardService(
            IHttpClient httpClient, 
            IAccessProvided accessProvided)
        {
            this._httpClient = httpClient;
            this._clientGrand = accessProvided.Grand;
        }

        public async Task<IdResponse> AddBoard(string boardName)
        {
            var createBoardUrl = $"https://api.trello.com/1/boards/?name={boardName}&defaultLabels=false&defaultLists=false&"
                .AddTrelloIdentity(this._clientGrand);

            using (var request = await this._httpClient.PostAsync(
                new Uri(createBoardUrl),
                new object(),
                new JsonMediaTypeFormatter()))
            {
                return request.IsSuccessStatusCode
                    ? await request.Content.ReadAsAsync<IdResponse>()
                    : throw new Exception();
            }
        }

        public async Task<IdResponse> AddLabel(string boardId, LabelRequestBody label)
        {
            var createBoardUrl = $"https://api.trello.com/1/boards/{boardId}/labels?"
                .AddTrelloIdentity(this._clientGrand);

            using (var request = await this._httpClient.PostAsync(
                new Uri(createBoardUrl),
                label,
                new JsonMediaTypeFormatter()))
            {
                return request.IsSuccessStatusCode
                    ? await request.Content.ReadAsAsync<IdResponse>()
                    : throw new Exception(await request.Content.ReadAsStringAsync());
            }
        }

        public async Task<IdResponse> AddLists(string boardId, ListRequestBody label)
        {
            var createBoardUrl = $"https://api.trello.com/1/boards/{boardId}/lists?"
                .AddTrelloIdentity(this._clientGrand);

            using (var request = await this._httpClient.PostAsync(
                new Uri(createBoardUrl),
                label,
                new JsonMediaTypeFormatter()))
            {
                return request.IsSuccessStatusCode
                    ? await request.Content.ReadAsAsync<IdResponse>()
                    : throw new Exception(await request.Content.ReadAsStringAsync());
            }
        }
    }
}
