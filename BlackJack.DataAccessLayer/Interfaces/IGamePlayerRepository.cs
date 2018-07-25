using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.EntitiesLayer.Enums;
using BlackJack.EntitiesLayer.Models;
using System.Data.Entity;

namespace BlackJack.DataAccessLayer.Iterfaces
{
    interface IGamePlayerRepository
    {
        Task<IEnumerable<GamePlayer>> GetGamePlayers();
        Task<GamePlayer> GetGamePlayerById(int id);
        Task InsertGamePlayer(GamePlayer player);
        Task DeleteGamePlayer(int id);
        Task UpdateGamePlayer(GamePlayer player);
        Task Save();
    }
}
