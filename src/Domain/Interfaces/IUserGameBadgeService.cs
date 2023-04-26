using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserGameBadgeService
    {
        Task<ICollection<UserGameBadge>> GetAll();
        Task<UserGameBadge> GetById(int id);
        UserGameBadge Add(UserGameBadge badge);
        Task<bool> Update(UserGameBadge badge);
        Task<bool> Remove(UserGameBadge badge);
    }
}
