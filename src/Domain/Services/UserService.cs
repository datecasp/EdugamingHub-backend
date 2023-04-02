using Domain.Helpers;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserService : ControllerBase, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtSettings _jwtSettings;

        public UserService(IUserRepository userRepository, JwtSettings jwtSettings)
        {
            _userRepository = userRepository;
            _jwtSettings = jwtSettings;
        }

        public async Task<IActionResult> GetTokenService(Login userLogin)
        {
            try
            {
                var Token = new UserTokens();
                var tempUsers = _userRepository.GetAll().Result;
                var searchUser = (from user in tempUsers
                                        where user.Email == userLogin.Email && user.Password == userLogin.Password
                                        select user).FirstOrDefault();

                if (searchUser != null)
                {

                    Token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        UserName = searchUser.Name,
                        EmailId = searchUser.Email,
                        Id = searchUser.Id,
                        GuidId = Guid.NewGuid(),
                        Role = searchUser.Role

                    }, _jwtSettings
                    );

                }
                else
                {
                    return BadRequest("Credenciales incorrectas. Vuelva a introducir sus datos.");
                }
                Object[] result = new Object[]
                    {
                        $"Bienvenido {Token.UserName}!",
                        $"Rol: {Token.Role}. Tiene accesibles las operaciones de dicho rol.",
                        $"Token: {Token.Token}"
                    };
                return Ok(Token);

            }
            catch (Exception ex)
            {
                throw new Exception("Error en GetToken", ex);

            }
        }

        public async Task<ICollection<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public User Add(User user)
        {
            if (_userRepository.Search(b => b.Email == user.Email).Result.Any())
                return null;

            _userRepository.Add(user);
            return user;
        }

        public async Task<bool> Update(User user)
        {
            bool result = await _userRepository.Update(user);

            if (result)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Remove(User user)
        {
            await _userRepository.Remove(user);
            return true;
        }

        public void Dispose()
        {
            _userRepository?.Dispose();
        }
    }
}
