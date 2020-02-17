namespace EaseTrello.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IMemberService
    {
        Task<IEnumerable<Board>> GetMemberBoards();
    }
}
