using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<ICollection<Game>> GetAll()
        {
            return await _gameRepository.GetAll();
        }

        public async Task<Game> GetById(int id)
        {
            return await _gameRepository.GetById(id);
        }

        public Game Add(Game game)
        {
            if (_gameRepository.Search(b => b.QuizzNameValue == game.QuizzNameValue).Result.Any())
                return null;

            _gameRepository.Add(game);
            return game;
        }

        public async Task<bool> Update(Game game)
        {
            bool result = await _gameRepository.Update(game);

            if (result)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Remove(Game game)
        {
            await _gameRepository.Remove(game);
            return true;
        }

        public void Dispose()
        {
            _gameRepository?.Dispose();
        }
    }
}
