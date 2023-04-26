using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class BadgeService : IBadgeService
    {
        private readonly IBadgeRepository _badgeRepository;

        public BadgeService(IBadgeRepository badgeRepository)
        {
            _badgeRepository = badgeRepository;
        }

        public async Task<ICollection<Badge>> GetAll()
        {
            return await _badgeRepository.GetAll();
        }

        public async Task<Badge> GetById(int id)
        {
            return await _badgeRepository.GetById(id);
        }

        public Badge Add(Badge badge)
        {
            _badgeRepository.Add(badge);
            return badge;
        }

        public async Task<bool> Update(Badge badge)
        {
            bool result = await _badgeRepository.Update(badge);

            if (result)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Remove(Badge badge)
        {
            await _badgeRepository.Remove(badge);
            return true;
        }

        public void Dispose()
        {
            _badgeRepository?.Dispose();
        }
    }
}
