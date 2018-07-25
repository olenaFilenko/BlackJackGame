using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlackJack.EntitiesLayer.Enums;
using BlackJack.EntitiesLayer.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BlackJack.DataAccessLayer.EntityFrameworkRepository
{
    public class BlackJackContext: DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GamePlayer> GamePlayers { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}