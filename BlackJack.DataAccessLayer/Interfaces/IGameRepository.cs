using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BlackJack.EntitiesLayer.Enums;
using BlackJack.EntitiesLayer.Models;


namespace BlackJack.DataAccessLayer.Iterfaces
{
    interface IGameRepository
    {
        Task<IEnumerable<Game>> GetGames();
        Task<Game> GetGameById(int id);
        Task InsertGame(Game game);
        Task DeleteGame(int id);
        Task UpdateGame(Game game);
        Task Save();
    }
}
