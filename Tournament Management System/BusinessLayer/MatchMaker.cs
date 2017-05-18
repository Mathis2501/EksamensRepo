using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

        public ObservableCollection<Match> CreateMatches(ObservableCollection<Team> TeamsInLeague, ObservableCollection<Round> RoundsInLeague)
        {
            ObservableCollection<Match> MatchesInRound = new ObservableCollection<Match>();

            foreach (Round item in RoundsInLeague)
            {
                TeamsInLeague = ShuffleTeams(TeamsInLeague);

                for (int i = 0; i < TeamsInLeague.Count - 1; i += 2)
                {
                    Match newMatch = new Match();
                    newMatch.TeamsInMatch.Add(TeamsInLeague[i]);
                    newMatch.TeamsInMatch.Add(TeamsInLeague[i + 1]);
                    //Should ensure that only one of each match combination exists
                    for (int k = 0; k < RoundsInLeague.IndexOf(item); k++)
                    {
                        //Needs Logic To skip when that Match already exists in another round
                        if (!RoundsInLeague.Any(x => x.MatchesInRound.Any(y => y.TeamsInMatch.Any( z => z.TeamName == newMatch.TeamsInMatch[0].TeamName && z.Bye == newMatch.TeamsInMatch[0].Bye && z.TeamName == newMatch.TeamsInMatch[1].TeamName && z.Bye == newMatch.TeamsInMatch[1].Bye))))
                        {
                            newMatch.MatchId = DataAccessFacade.SaveMatch(newMatch, RoundsInLeague[RoundsInLeague.IndexOf(item)].RoundId);
                            RoundsInLeague[RoundsInLeague.IndexOf(item)].MatchesInRound.Add(newMatch);
                            Debug.Print("Goes False");
                        }
                        else
                        {
                            Debug.Print("Goes True");
                        }
                    }
                }
            }
            return MatchesInRound;
        }
    }
}
