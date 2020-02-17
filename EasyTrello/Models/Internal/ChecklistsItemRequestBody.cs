namespace EaseTrello.Models.Internal
{
    using Newtonsoft.Json;

    public class ChecklistsItemRequestBody
    {
        public ChecklistsItemRequestBody(
            string name)
        {
            this.Name = name;
        }
        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; }
    }
}
