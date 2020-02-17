namespace EaseTrello.Models
{
    using Enum;

    public class Label
    {
        public Label(
            string id,
            string name, 
            TrelloColors color)
        {
            this.Id = id;
            this.Name = name;
            this.Color = color;
        }

        public string Id { get; }
        
        public string Name { get; }

        public TrelloColors Color { get; }
    }
}
