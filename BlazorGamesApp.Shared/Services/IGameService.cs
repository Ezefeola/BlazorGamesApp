using BlazorGamesApp.Shared.Entities;

namespace BlazorGamesApp.Shared.Services
{
    public interface IGameService
    {
        Task<Game> AddGame(Game game);
        Task<Game> GetGameById(int id);
        Task<List<Game>> GetAll();
        Task<Game> EditGame(int id, Game game);
        Task<bool> DeleteGame(int id);
    }
}