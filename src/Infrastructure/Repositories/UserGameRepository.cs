using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class UserGameRepository : Repository<UserGame>, IUserGameRepository
    {
        public UserGameRepository(AppDbContext context) : base(context)
        {
        }

    }
}