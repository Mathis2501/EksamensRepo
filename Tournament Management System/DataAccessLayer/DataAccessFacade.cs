using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;

namespace DataAccessLayer
{
    public static class DataAccessFacade
    {

        public static void UpdateLeagueStatus(int LeagueId, string LeagueStatus)
        {
            //UpdateData UD = new UpdateData();
            //UD.UpdateLeagueStatus(LeagueId, LeagueStatus);
        }
        
        public static ObservableCollection<League> GetLeagueData()
        {
            GetData GD = new GetData();
            return GD.GetLeagues();

        }

        public static ObservableCollection<Player> GetPlayerData()
        {
            GetData GD = new GetData();
            return GD.GetPlayers();
        }

        public static int SaveLeague(League newLeague)
        {
            SaveData SD = new SaveData();
            return SD.SaveLeague(newLeague);
        }

        public static void SaveRound(Round newRound, int leagueId)
        {
            SaveData SD = new SaveData();
            SD.SaveRound(newRound, leagueId);
        }

        public static void SavePlayer(Player newPlayer)
        {
            SaveData SD = new SaveData();
            SD.SavePlayer(newPlayer);
        }

        public static void UpdatePlayer(Player ChosenPlayer)
        {
            UpdateData UD = new UpdateData();
            UD.UpdatePlayer(ChosenPlayer);
        }

        public static void DeleteLeague(League chosenLeague)
        {
            DeleteData DL = new DeleteData();
            DL.DeleteLeague(chosenLeague);
        }

        public static void DeletePlayer(Player ChosenPlayer)
        {
            DeleteData DL = new DeleteData();
            DL.DeletePlayer(ChosenPlayer);
        }

        public static void SaveTeam(Team newTeam, int leagueId)
        {
            SaveData SD = new SaveData();
            SD.SaveTeam(newTeam, leagueId);
        }

        public static int SaveMatch(Match newMatch, int roundId)
        {
            SaveData SD = new SaveData();
            return SD.SaveMatch(newMatch, roundId);
        }
    }
}
