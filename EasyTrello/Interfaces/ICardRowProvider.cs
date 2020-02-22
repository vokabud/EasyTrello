namespace EaseTrello.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface ICardRowProvider
    {
        IEnumerable<CardRow> GetCardRows();
    }
}
