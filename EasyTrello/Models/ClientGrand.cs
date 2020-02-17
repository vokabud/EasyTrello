namespace EaseTrello.Models
{
    public class ClientGrand
    {
        public ClientGrand(
            string apiKey, 
            string token)
        {
            this.ApiKey = apiKey;
            this.Token = token;
        }

        public string ApiKey { get; }

        public string Token { get; }
    }
}
