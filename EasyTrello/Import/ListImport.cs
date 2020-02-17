namespace EaseTrello.Import
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Interfaces;
    using Models;
    using Models.Internal;

    public class ListImport : BaseImport
    {
        private readonly IBoardService _boardService;

        public ListImport(
            IBoardService boardService,
            LabelImport next) 
            : base(next)
        {
            this._boardService = boardService;
        }

        protected override async Task DoImport(IEnumerable<CardRow> source, Board destination)
        {
            var lists = source.Select(row => row.List).Distinct();

            foreach (var list in lists)
            {
                var idResponse = await this
                    ._boardService
                    .AddLists(destination.Id, new ListRequestBody(list));

                destination.AddList(new TrelloList(idResponse.Id, list));
            }
        }
    }
}
