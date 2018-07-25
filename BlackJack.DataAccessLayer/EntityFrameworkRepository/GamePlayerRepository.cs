using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlackJack.EntitiesLayer.Enums;
using BlackJack.EntitiesLayer.Models;
using System.Data.Entity;
using BlackJack.DataAccessLayer.Iterfaces;
using System.Threading.Tasks;


namespace BlackJack.DataAccessLayer.EntityFrameworkRepository
{
    public class GameBotRepository : IGamePlayerRepository
    {
        private BlackJackContext _context;

        public GameBotRepository(BlackJackContext context) {
            _context = context;
        }
        public async Task DeleteGamePlayer(int id)
        {
            GamePlayer gameBot =await _context.GamePlayers.FindAsync(id);
            _context.GamePlayers.Remove(gameBot);
            await _context.SaveChangesAsync();
        }

        public async Task<GamePlayer> GetGamePlayerById(int id)
        {
            return await _context.GamePlayers.FindAsync(id);
        }

        public async  Task<IEnumerable<GamePlayer>> GetGamePlayers()
        {
            var gamePlayers =await (from gp in _context.GamePlayers select gp).ToListAsync();
            return gamePlayers;
        }

        public async Task InsertGamePlayer(GamePlayer player)
        {
            _context.GamePlayers.Add(player);
            await _context.SaveChangesAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGamePlayer(GamePlayer player)
        {
            _context.Entry(player).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}