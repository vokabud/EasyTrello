namespace EaseTrello.Interfaces
{
    using System.Threading.Tasks;
    using Models;
    
    public interface ITokensService
    {
        Task<Member> GetMember();
    }
}
