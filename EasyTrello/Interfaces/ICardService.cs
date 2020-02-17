namespace EaseTrello.Interfaces
{
    using System.Threading.Tasks;
    using Models.Internal;

    public interface ICardService
    {
        Task<IdResponse> AddCard(string idList, CardRequest card);
    }
}
