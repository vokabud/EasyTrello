namespace EaseTrello.Models
{
    using System.Collections.Generic;

    public class CardRow
    {
        public CardRow(
            string name,
            IEnumerable<string> labels, 
            string description,
            IEnumerable<string> items, 
            string list)
        {
            this.Name = name;
            this.Labels = labels;
            this.Description = description;
            this.Items = items;
            this.List = list;
        }

        public string Name { get; }

        public IEnumerable<string> Labels { get; }

        public string Description { get; }

        public IEnumerable<string> Items { get; }

        public string List { get; }
    }
}
