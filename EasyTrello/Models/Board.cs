namespace EaseTrello.Models
{
    using System.Collections.Generic;

    public class Board
    {
        public Board(
            string name)
        {
            this.Name = name;
            this.Id = string.Empty;
            this.Lists = new List<TrelloList>();
            this.Labels = new List<Label>();
        }
        
        public string Name { get; }

        public string Id { get; protected set; }

        public List<TrelloList> Lists { get; }

        public List<Label> Labels { get; }

        public void SetId(string id)
        {
            this.Id = id;
        }

        public void AddList(TrelloList list)
        {
            this.Lists.Add(list);
        }

        public void AddLabel(Label label)
        {
            this.Labels.Add(label);
        }
    }
}
