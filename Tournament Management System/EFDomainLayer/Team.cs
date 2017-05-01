using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer
{
    public class Team : IID
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int LeaguePoints { get; set; }
        public ICollection<Player> PlayersInTeam { get; set; }
        public int ID
        {
            get { return TeamId; }

            set { TeamId = value; }
        }
    }
}