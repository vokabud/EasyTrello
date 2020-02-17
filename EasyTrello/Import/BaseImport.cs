using System.Linq;

namespace EaseTrello.Import
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Interfaces;
    using Models;

    public abstract class BaseImport : IImporter
    {
        private readonly IImporter _next;

        protected BaseImport(
            IImporter next)
        {
            this._next = next;
        }

        public async Task Import(IEnumerable<CardRow> source, Board destination)
        {
            var rows = source.ToList();

            await this.DoImport(rows, destination);

            if (this._next != null)
            {
                await this._next.Import(rows, destination);
            }
        }

        protected abstract Task DoImport(IEnumerable<CardRow> source, Board destination);
    }
}
