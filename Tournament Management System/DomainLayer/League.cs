using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    class League
    {
        public int LeagueID{ get; set; }
        public string LeagueName { get; set; }
        public string Reward{ get; set; }
        public int Rounds{ get; set; }
        public string GameName{ get; set; }
        
        //test
        public League(string leagueName, string reward, int rounds, string gameName)
        {
            LeagueName = leagueName;
            Reward = reward;
            Rounds = rounds;
            GameName = gameName;
        }
    }
}
