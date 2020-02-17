namespace EaseTrello.Import
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Interfaces;
    using Models;

    public class BoardImport : BaseImport
    {
        private readonly IBoardService _boardService;

        public BoardImport(
            IBoardService boardService,
            ListImport next) 
            : base(next)
        {
            this._boardService = boardService;
        }

        protected override async Task DoImport(IEnumerable<CardRow> source, Board destination)
        {
            var idRequest = await this._boardService.AddBoard(destination.Name);
            destination.SetId(idRequest.Id);
        }
    }
}
