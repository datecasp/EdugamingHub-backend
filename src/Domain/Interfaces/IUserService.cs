using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<ICollection<User>> GetAll();
        Task<User> GetById(int id);
        User Add(User user);
        Task<bool> Update(User user);
        Task<bool> Remove(User user);
    }
}
