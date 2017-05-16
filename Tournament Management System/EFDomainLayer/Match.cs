using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Match : IID
    {
        public int MatchId { get; set; }
        public ObservableCollection<Team> TeamsInMatch;
        public int ID
        {
            get { return MatchId; }

            set { MatchId = value; }
        }

        public Match()
        {
            TeamsInMatch = new ObservableCollection<Team>();
        }
    }
}
