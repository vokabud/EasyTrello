namespace EaseTrello.Models
{
    using System.Collections.Generic;

    public class TrelloList
    {
        public TrelloList(
            string id, string name)
        {
            this.Id = id;
            this.Name = name;
            this.Cards = new List<Card>();
        }

        public string Id { get; }

        public string Name { get; }

        public List<Card> Cards { get; }

        public void AddCard(Card card)
        {
            this.Cards.Add(card);
        }
    }
}
