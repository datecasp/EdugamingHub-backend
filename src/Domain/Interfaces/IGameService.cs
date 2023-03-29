using Domain.Models;

namespace Domain.Interfaces
{
    public interface IGameService
    {
        Task<ICollection<Game>> GetAll();
        Task<Game> GetById(int id);
        Game Add(Game game);
        Task<bool> Update(Game game);
        Task<bool> Remove(Game game);
    }
}
