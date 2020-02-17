namespace EaseTrello.Import
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Interfaces;
    using Models;
    using Models.Internal;

    public class ChecklistsImport : BaseImport
    {
        private readonly IChecklistsService _checklistsService;
        public ChecklistsImport(
            IChecklistsService checklistsService) 
            : base(null)
        {
            this._checklistsService = checklistsService;
        }

        protected override async Task DoImport(IEnumerable<CardRow> source, Board destination)
        {
            var cards = destination
                .Lists
                .Select(list => list.Cards)
                .Aggregate(new List<Card>(), (result, listCards) => result.Concat(listCards).ToList())
                .Select(card => new
                {
                    card.Name,
                    card.Id,
                    Checklist = source.First(row => row.Name == card.Name).Items
                });

            foreach (var card in cards)
            {
                var idListResponse = await this._checklistsService.AddChecklists(card.Id, new ChecklistsRequestBody(""));

                foreach (var item in card.Checklist)
                {
                    await this._checklistsService
                        .AddChecklistsItem(
                            idListResponse.Id,
                            new ChecklistsItemRequestBody(item));
                }
            }
        }
    }
}
