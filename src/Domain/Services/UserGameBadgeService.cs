using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserGameBadgeService : IUserGameBadgeService
    {
        private readonly IUserGameBadgeRepository _userGameBadgeRepository;

        public UserGameBadgeService(IUserGameBadgeRepository userGameBadgeRepository)
        {
            _userGameBadgeRepository = userGameBadgeRepository;
        }

        public async Task<ICollection<UserGameBadge>> GetAll()
        {
            return await _userGameBadgeRepository.GetAll();
        }

        public async Task<UserGameBadge> GetById(int id)
        {
            return await _userGameBadgeRepository.GetById(id);
        }

        public UserGameBadge Add(UserGameBadge UserGameBadge)
        {
            _userGameBadgeRepository.Add(UserGameBadge);
            return UserGameBadge;
        }

        public async Task<bool> Update(UserGameBadge UserGameBadge)
        {
            bool result = await _userGameBadgeRepository.Update(UserGameBadge);

            if (result)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Remove(UserGameBadge UserGameBadge)
        {
            await _userGameBadgeRepository.Remove(UserGameBadge);
            return true;
        }

        public void Dispose()
        {
            _userGameBadgeRepository?.Dispose();
        }
    }
}
