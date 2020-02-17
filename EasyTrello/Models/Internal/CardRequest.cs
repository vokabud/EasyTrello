namespace EaseTrello.Models.Internal
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CardRequest
    {
        private readonly IEnumerable<string> _labelsIds;

        public CardRequest(
            string name, 
            string description,
            IEnumerable<string> labelsIds)
        {
            this.Name = name;
            this.Description = description;
            this._labelsIds = labelsIds;
        }
        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; }
        
        [JsonProperty(PropertyName = "desc")]
        public string Description { get; }

        [JsonProperty(PropertyName = "idLabels")]
        public string Labels => string.Join(',', this._labelsIds);
    }
}
