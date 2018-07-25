﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackJack.EntitiesLayer.Models
{
    public class Game
    {
        public int Id { get; set; }
        
        public virtual ICollection<GamePlayer> GamePlayers { get; set; }
        
    }
}