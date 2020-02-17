namespace EaseTrello.Import
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Interfaces;
    using Models;
    using Models.Internal;

    public class CardImport : BaseImport
    {
        private readonly ICardService _cardService;

        public CardImport(
            ICardService cardService, 
            ChecklistsImport next) 
            : base(next)
        {
            this._cardService = cardService;
        }

        protected override async Task DoImport(IEnumerable<CardRow> source, Board destination)
        {
            var boardLabels = destination.Labels;

            var cards = source.Select(row => new
            {
                ListId = destination.Lists.First(list => list.Name == row.List).Id,
                row.Name,
                row.Description,
                Labels = boardLabels.Where(label => row.Labels.Contains(label.Name))
            });

            foreach (var card in cards)
            {
                var responseId = await this
                    ._cardService
                    .AddCard(
                        card.ListId,
                        new CardRequest(
                            card.Name,
                            card.Description,
                            card.Labels.Select(label => label.Id)));

                destination
                    .Lists
                    .First(
                        list => list.Id == card.ListId)
                    .AddCard(
                        new Card(
                            responseId.Id,
                            card.Name,
                            card.Description,
                            card.Labels));
            }
        }
    }
}
