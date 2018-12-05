using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPSGame.Models
{
    public class Game
    {
        public int gameID { get; set; }
        public DateTime TimeStamp { get; set; }
        //user who does the game
       // public User Gamer { get; set; }
        //whether user wins or loses
        // 0: draw, 1: user wins, 2: user loses
        public int Result { get; set; }
    }
}
