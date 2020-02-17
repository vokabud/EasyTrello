namespace EaseTrello.Models
{
    using System.Collections.Generic;

    public class Card
    {
        public Card(
            string id, 
            string name, 
            string description,
            IEnumerable<Label> labels)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Labels = labels;
        }

        public string Id { get; }

        public string Name { get; }

        public string Description { get; }

        public IEnumerable<Label> Labels { get; }
    }
}
