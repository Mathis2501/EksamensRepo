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
        public List<Teams> TeamsInLeague { get; set; }
        public string Reward{ get; set; }
        public int Rounds{ get; set; }
        public string GameName{ get; set; }
        

        public League(string leagueName, List<Teams> teamsInLeague, string reward, int rounds, string gameName)
        {
            LeagueName = leagueName;
            TeamsInLeague = teamsInLeague;
            Reward = reward;
            Rounds = rounds;
            GameName = gameName;
        }
    }
}
