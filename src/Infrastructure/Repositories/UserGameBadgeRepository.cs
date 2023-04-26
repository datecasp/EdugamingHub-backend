using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserGameBadgeRepository: Repository<UserGameBadge>, IUserGameBadgeRepository
    {
        public UserGameBadgeRepository(AppDbContext context) : base(context) { }

        public new async Task<ICollection<UserGameBadge>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public IEnumerable<UserGameBadge> GetByUserGameId(int id)
        {
            var entity = GetAll().Result;
            
            if (entity == null)
            {
                return null;
            }
            var result = entity.Where(x => x.UserGame == id);

            return result;
        }
    }
}
