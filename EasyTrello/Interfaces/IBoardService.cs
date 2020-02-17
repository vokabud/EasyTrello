namespace EaseTrello.Interfaces
{
    using System.Threading.Tasks;
    using Models.Internal;

    public interface IBoardService
    {
        Task<IdResponse> AddBoard(string boardName);

        Task<IdResponse> AddLabel(string boardId, LabelRequestBody label);

        Task<IdResponse> AddLists(string boardId, ListRequestBody label);
    }
}
