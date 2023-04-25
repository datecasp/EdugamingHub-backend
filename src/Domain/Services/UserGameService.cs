using Domain.Interfaces;
using Domain.Models;
using System.Linq.Expressions;

namespace Domain.Services
{
    public class UserGameService : IUserGameService
    {
        private readonly IUserGameRepository _userGameRepository;

        public UserGameService(IUserGameRepository userGameRepository)
        {
            _userGameRepository = userGameRepository;
        }

        public UserGame Add(UserGame userGame)
        {
            var result = _userGameRepository.Search(ug => ug.User == userGame.User && ug.Game == userGame.Game).Result;
            if (result.Count() > 0)
            {
                result.FirstOrDefault().Plays++;
                _userGameRepository.Update(result.FirstOrDefault());
            }
            else
            {
                userGame.Plays = 1;
                _userGameRepository.Add(userGame);
                return userGame;
            }
            return result.FirstOrDefault();
        }

        public void Dispose()
        {
            _userGameRepository?.Dispose();
        }

        public async Task<ICollection<UserGame>> GetAll()
        {
            return await _userGameRepository.GetAll();

        }

        public async Task<IEnumerable<UserGame>> GetByUserId(int id)
        {
            return await _userGameRepository.Search(ug => ug.User == id);
        }

        public async Task<bool> Update(UserGame userGame)
        {
            bool result = await _userGameRepository.Update(userGame);

            if (result)
            {
                return true;
            }
            return false;
        }

        //public Task Remove(UserGame entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<UserGame>> Search(Expression<Func<UserGame, bool>> predicate)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
