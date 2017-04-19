using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    class Tournament
    {
        public string LeagueName { get; set; }
        public List<Player> PlayerList { get; set; }
        public string Reward{ get; set; }
        public int Rounds{ get; set; }
        public string GameName{ get; set; }
        

        public Tournament(string leagueName, List<Player> playerList, string reward, int rounds, string gameName)
        {
            LeagueName = leagueName;
            PlayerList = playerList;
            Reward = reward;
            Rounds = rounds;
            GameName = gameName;
        }
    }
}
