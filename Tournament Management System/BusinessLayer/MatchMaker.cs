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
        internal ObservableCollection<Team> ShuffleTeams(ObservableCollection<Team> TeamList)
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

        internal void CreateMatches(ObservableCollection<Team> TeamsInLeague, ObservableCollection<Round> RoundsInLeague)
        {
            TeamsInLeague = ShuffleTeams(TeamsInLeague);

            int numberOfMatchesInARound = TeamsInLeague.Count / 2;

            List<Team> teams = new List<Team>();

            teams.AddRange(TeamsInLeague.Skip(numberOfMatchesInARound).Take(numberOfMatchesInARound));
            teams.AddRange(TeamsInLeague.Skip(1).Take(numberOfMatchesInARound - 1).ToArray().Reverse());
            
            var numberOfTeams = teams.Count;

            for (var roundNumber = 0; roundNumber < RoundsInLeague.Count; roundNumber++)
            {
                var teamIdx = roundNumber % numberOfTeams;
                Match newMatch = new Match();
                newMatch.TeamsInMatch[0] = teams[teamIdx];
                newMatch.TeamsInMatch[1] = TeamsInLeague[0];
                newMatch.Team1 = teams[teamIdx];
                newMatch.Team2 = TeamsInLeague[0];

                //Save Match
                DataAccessFacade.SaveMatch(newMatch, RoundsInLeague[roundNumber].RoundId);
                RoundsInLeague[roundNumber].MatchesInRound.Add(newMatch);

                for (var idx = 1; idx < numberOfMatchesInARound; idx++)
                {
                    var firstTeamIndex = (roundNumber + idx) % numberOfTeams;
                    var secondTeamIndex = (roundNumber + numberOfTeams - idx) % numberOfTeams;
                    Match newMatch2 = new Match();
                    newMatch2.TeamsInMatch[0] = teams[firstTeamIndex];
                    newMatch2.TeamsInMatch[1] = teams[secondTeamIndex];
                    newMatch2.Team1 = teams[firstTeamIndex];
                    newMatch2.Team2 = teams[secondTeamIndex];

                    //Save Match
                    DataAccessFacade.SaveMatch(newMatch2, RoundsInLeague[roundNumber].RoundId);
                    RoundsInLeague[roundNumber].MatchesInRound.Add(newMatch2);
                }
            }
        }
    }
}
