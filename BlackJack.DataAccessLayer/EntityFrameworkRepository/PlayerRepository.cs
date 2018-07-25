using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlackJack.EntitiesLayer.Enums;
using BlackJack.EntitiesLayer.Models;
using System.Data.Entity;
using BlackJack.DataAccessLayer.EntityFrameworkRepository;
using System.Threading.Tasks;

namespace BlackJack.DataAccessLayer.Iterfaces
{
    public class PlayerRepository : IPlayerRepository
    {
        private BlackJackContext _context;

        public PlayerRepository(BlackJackContext context) {
            _context = context;
        }

        public async Task DeletePlayer(int id)
        {
            Player player =await _context.Players.FindAsync(id);
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
        }
        
        public Task Save()
        {
            return _context.SaveChangesAsync();
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

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            var pl=await (from p in _context.Players select p).ToListAsync();
            return pl;
            
        }

        public async Task<Player> GetPlayerById(int id)
        {
            return await _context.Players.FindAsync(id);
        }

        public async Task InsertPlayer(Player player)
        {
            _context.Players.Add(player);
            await  _context.SaveChangesAsync();
        }

        public async Task UpdatePlayer(Player player)
        {
            _context.Entry(player).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}