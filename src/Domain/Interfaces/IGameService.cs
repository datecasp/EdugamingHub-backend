using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGameService
    {
        Task<ICollection<Game>> GetAll();
        Task<Game> GetById(int id);
        Game Add(Game game);
        Task<bool> Update(Game user);
        Task<bool> Remove(Game user);
    }
}
