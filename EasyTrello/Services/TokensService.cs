namespace EaseTrello.Services
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Interfaces;
    using Extension;
    using Models;

    public class TokensService : ITokensService
    {
        private readonly IHttpClient _httpClient;

        private readonly ClientGrand _grand;
        
        public TokensService(
            IHttpClient httpClient, 
            IAccessProvided accessProvided)
        {
            this._httpClient = httpClient;
            this._grand = accessProvided.Grand;
        }

        public async Task<Member> GetMember()
        {
            var memberUrl = $"https://api.trello.com/1/tokens/{this._grand.Token}?"
                .AddTrelloIdentity(this._grand);

            using (var response = await this._httpClient.GetAsync(new Uri(memberUrl)))
            {
                return response.IsSuccessStatusCode
                    ? await response.Content.ReadAsAsync<Member>()
                    : throw new Exception();
            }
        }
    }
}
