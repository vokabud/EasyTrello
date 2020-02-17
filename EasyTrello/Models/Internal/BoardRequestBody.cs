namespace EaseTrello.Models.Internal
{
    using Newtonsoft.Json;

    public class BoardRequestBody
    {
        public BoardRequestBody(
            string name)
        {
            this.Name = name;
        }
        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; }
    }
}
