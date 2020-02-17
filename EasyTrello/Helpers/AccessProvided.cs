namespace EaseTrello.Helpers
{
    using Interfaces;
    using Models;

    public class AccessProvided : IAccessProvided
    {
        public AccessProvided(
            string apiKey, 
            string token)
        {
            this.Grand = new ClientGrand(apiKey, token);
        }
        
        public ClientGrand Grand { get; }
    }
}