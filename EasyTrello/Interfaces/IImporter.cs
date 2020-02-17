namespace EaseTrello.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IImporter
    {
        Task Import(IEnumerable<CardRow> source, Board destination);
    }
}
