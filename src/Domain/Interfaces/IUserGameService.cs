using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserGameService
    {
        Task<ICollection<UserGame>> GetAll();
        Task<IEnumerable<UserGame>> GetByUserId(int id);
        UserGame Add(UserGame userGame);
        Task<bool> Update(UserGame userGame);
    }
}
