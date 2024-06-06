using BlazorGamesApp.Shared.Data;
using BlazorGamesApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorGamesApp.Shared.Services
{
    public class GameService : IGameService
    {
        private readonly ApplicationDbContext _dbContext;

        public GameService(ApplicationDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public async Task<List<Game>> GetAll()
        {
            var games = await _dbContext.Games.ToListAsync();

            return games;
        }

        public async Task<Game> AddGame(Game game)
        {
            _dbContext.Games.Add(game);
            await _dbContext.SaveChangesAsync();

            return game;
        }

        public async Task<Game> GetGameById(int id)
        {
            return await _dbContext.Games.FindAsync(id);
        }

        public async Task<Game> EditGame(int id, Game game)
        {
            var dbGame = await _dbContext.Games.FindAsync(id);

            if (dbGame is not null)
            {
                dbGame.Name = game.Name;
                await _dbContext.SaveChangesAsync();
                return dbGame;
            }

            throw new Exception("Game not found.");
        }

        public async Task<bool> DeleteGame(int id)
        {
            var dbGame = await _dbContext.Games.FindAsync(id);

            if(dbGame is not null)
            {
                _dbContext.Remove(dbGame);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
