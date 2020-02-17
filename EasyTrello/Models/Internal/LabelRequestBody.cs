namespace EaseTrello.Models.Internal
{
    using Newtonsoft.Json;
    using Enum;

    public class LabelRequestBody
    {
        private readonly TrelloColors _color;

        public LabelRequestBody(
            string name,
            TrelloColors color)
        {
            this.Name = name;
            this._color = color;
        }
        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; }

        [JsonProperty(PropertyName = "color")]
        public string Color => this._color.ToString().ToLower();
    }
}
