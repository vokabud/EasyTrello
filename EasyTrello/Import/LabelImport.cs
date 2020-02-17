namespace EaseTrello.Import
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Enum;
    using Interfaces;
    using Models;
    using Models.Internal;

    public class LabelImport : BaseImport
    {
        private readonly IBoardService _boardService;
        public LabelImport(
            IBoardService boardService, 
            CardImport next) 
            : base(next)
        {
            this._boardService = boardService;
        }

        protected override async Task DoImport(IEnumerable<CardRow> source, Board destination)
        {
            var values = Enum.GetValues(typeof(TrelloColors));
            var random = new Random();
            var cardLabels = source.Select(row => row.Labels);

            var labels = cardLabels
                .Aggregate(
                    new List<string>(), 
                    (result, next) => result.Concat(next).ToList())
                .Distinct();

            foreach (var label in labels)
            {
                var color = (TrelloColors)values.GetValue(random.Next(values.Length));

                var idResponse = await this
                    ._boardService
                    .AddLabel(destination.Id, new LabelRequestBody(label, color));

                destination.AddLabel(new Label(idResponse.Id,label, color));
            }
        }
    }
}
