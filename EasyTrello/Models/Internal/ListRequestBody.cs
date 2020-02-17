namespace EaseTrello.Models.Internal
{
    using Newtonsoft.Json;

    public class ListRequestBody
    {
        public ListRequestBody(
            string name)
        {
            this.Name = name;
        }
        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; }
    }
}
