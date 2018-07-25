using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.EntitiesLayer.Enums;
using BlackJack.EntitiesLayer.Models;

namespace BlackJack.DataAccessLayer.Iterfaces
{
    interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetPlayers();
        Task<Player> GetPlayerById(int id);
        Task InsertPlayer(Player player);
        Task DeletePlayer(int id);
        Task UpdatePlayer(Player player);
        Task Save();
    }
}
