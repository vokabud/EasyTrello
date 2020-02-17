namespace EaseTrello.Services
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Threading.Tasks;
    using Interfaces;
    using Extension;
    using Models;
    using Models.Internal;

    public class ChecklistsService : IChecklistsService
    {
        private readonly IHttpClient _httpClient;
        private readonly ClientGrand _clientGrand;

        public ChecklistsService(
            IHttpClient httpClient, 
            IAccessProvided accessProvided)
        {
            this._httpClient = httpClient;
            this._clientGrand = accessProvided.Grand;
        }

        public async Task<IdResponse> AddChecklists(string cardId, ChecklistsRequestBody checklists)
        {
            var addChecklistsUrl = $"https://api.trello.com/1/checklists?idCard={cardId}&"
                .AddTrelloIdentity(this._clientGrand);

            using (var request = await this._httpClient.PostAsync(
                new Uri(addChecklistsUrl),
                checklists,
                new JsonMediaTypeFormatter()))
            {
                return request.IsSuccessStatusCode
                    ? await request.Content.ReadAsAsync<IdResponse>()
                    : throw new Exception(await request.Content.ReadAsStringAsync());
            }
        }

        public async Task AddChecklistsItem(string checklistsId, ChecklistsItemRequestBody checklists)
        {
            var addChecklistsUrl = $"https://api.trello.com/1/checklists/{checklistsId}/checkItems?"
                .AddTrelloIdentity(this._clientGrand);

            using (await this._httpClient.PostAsync(
                new Uri(addChecklistsUrl),
                checklists, 
                new JsonMediaTypeFormatter()))
            {
            }
        }
    }
}
