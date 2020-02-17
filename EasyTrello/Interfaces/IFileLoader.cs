namespace EaseTrello.Interfaces
{
    using System.Collections.Generic;
    using Models;

    internal interface IBoardLoader
    {
        IEnumerable<CardRow> Load(string filePath);
    }
}
