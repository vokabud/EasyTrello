namespace EaseTrello.Models.Internal
{
    using Newtonsoft.Json;

    public class ChecklistsRequestBody
    {
        public ChecklistsRequestBody(
            string name)
        {
            this.Name = name;
        }
        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; }
    }
}
