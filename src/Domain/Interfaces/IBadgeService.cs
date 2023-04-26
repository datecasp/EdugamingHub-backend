using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBadgeService
    {
        Task<ICollection<Badge>> GetAll();
        Task<Badge> GetById(int id);
        Badge Add(Badge badge);
        Task<bool> Update(Badge badge);
        Task<bool> Remove(Badge badge);
    }
}
