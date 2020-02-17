namespace EaseTrello.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Interfaces;
    using Extension;
    using Models;

    public class MemberService : IMemberService
    {
        private readonly IHttpClient _httpClient;

        private readonly ITokensService _tokensService;

        private readonly ClientGrand _clientGrand;

        public MemberService(
            IHttpClient httpClient, 
            ITokensService tokensService,
            IAccessProvided accessProvided)
        {
            this._httpClient = httpClient;
            this._tokensService = tokensService;
            this._clientGrand = accessProvided.Grand;
        }

        public async Task<IEnumerable<Board>> GetMemberBoards()
        {
            var member = await this._tokensService.GetMember();

            var myBoardsUrl = $"https://api.trello.com/1/members/{member.IdMember}/boards?"
                .AddTrelloIdentity(this._clientGrand);

            using (var response = await this._httpClient.GetAsync(new Uri(myBoardsUrl)))
            {
                return response.IsSuccessStatusCode
                    ? await response.Content.ReadAsAsync<IEnumerable<Board>>()
                    : throw new Exception();
            }
        }
    }
}
