using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Round : IID
    {
        public int RoundId { get; set; }
        public string RoundName { get; set; }
        public ICollection<Team> TeamsInRound { get; set; }
        public ICollection<Match> MatchesInRound { get; set; }
        public int ID
        {
            get { return RoundId; }

            set { RoundId = value; }
        }
    }
}
