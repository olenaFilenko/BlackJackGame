using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlackJack.EntitiesLayer.Enums;

namespace BlackJack.EntitiesLayer.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public Role Role { get; set; }

        public virtual ICollection<GamePlayer> GamePlayers { get; set; }

    }
}