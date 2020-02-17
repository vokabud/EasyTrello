namespace EaseTrello.Interfaces
{
    using System.Threading.Tasks;
    using Models.Internal;

    public interface IChecklistsService
    {
        Task<IdResponse> AddChecklists(string cardId, ChecklistsRequestBody checklists);

        Task AddChecklistsItem(string checklistsId, ChecklistsItemRequestBody checklists);
    }
}
