using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DomainLayer;

namespace BusinessLayer
{
    class MatchMaker
    {
        private static Random rng = new Random();
        public ObservableCollection<Team> ShuffleTeams(ObservableCollection<Team> TeamList)
        {
            int n = TeamList.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Team value = TeamList[k];
                TeamList[k] = TeamList[n];
                TeamList[n] = value;
            }
            return TeamList;
        }

        public ObservableCollection<Match> CreateMatches(ObservableCollection<Team> teamsInLeague, Round RoundsInLeague)
        {
            ObservableCollection<Match> MatchesInRound = new ObservableCollection<Match>();

            teamsInLeague = ShuffleTeams(teamsInLeague);

            for (int i = 0; i < teamsInLeague.Count-1; i++)
            {
                if (i % 2 == 0)
                {
                    Match newMatch = new Match();
                    newMatch.TeamsInMatch.Add(teamsInLeague[i]);
                    newMatch.TeamsInMatch.Add(teamsInLeague[i+1]);
                    newMatch.MatchId = DataAccessFacade.SaveMatch(newMatch, );
                }
            }

            return MatchesInRound;
        }
    }
}
