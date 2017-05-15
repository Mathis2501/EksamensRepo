using System.Collections.ObjectModel;
using DataAccessLayer;
using DomainLayer;

namespace BusinessLayer
{
    public static class BusinessFacade
    {
        public static ObservableCollection<League> GetLeagueData()
        {
            return DataAccessFacade.GetLeagueData();
        }

        public static ObservableCollection<Player> GetPlayerData()
        {
            return DataAccessFacade.GetPlayerData();
        }

        public static int SaveLeague(League newLeague)
        {
            return DataAccessFacade.SaveLeague(newLeague);
        }

        public static void SaveRound(Round newRound, int leagueId)
        {
            DataAccessFacade.SaveRound(newRound, leagueId);
        }


        public static void SavePlayer(Player newPlayer)
        {
            DataAccessFacade.SavePlayer(newPlayer);
        }

        public static void SaveTeam(Team newTeam, int leagueId)
        {
            DataAccessFacade.SaveTeam(newTeam, leagueId);
        }
    }
}
