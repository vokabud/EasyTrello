namespace EaseTrello.Extension
{
    using Models;

    public static class StringExtension
    {
        public static string AddTrelloIdentity(this string source, ClientGrand grand)
        {
            return $"{source}key={grand.ApiKey}&token={grand.Token}";
        }
    }
}
