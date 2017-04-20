using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    class Teams
    {
        public int TeamID{ get; set; }
        public List<Player> PlayersInTeam { get; set; }
        public string TeamName { get; set; }
        public int LeagueID{ get; set; }
        public int LeaguePoints { get; set; }

        public Teams(List<Player> playersInTeam, string teamName, int leagueID)
        {
            PlayersInTeam = playersInTeam;
            TeamName = teamName;
            LeagueID = leagueID;
            LeaguePoints = 0;
        }
    }
}
