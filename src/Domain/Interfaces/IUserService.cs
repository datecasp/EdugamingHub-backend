using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<IActionResult> GetTokenService(Login userLogin);
        Task<ICollection<User>> GetAll();
        Task<User> GetById(int id);
        User Add(User user);
        Task<bool> Update(User user);
        Task<bool> Remove(User user);
    }
}
