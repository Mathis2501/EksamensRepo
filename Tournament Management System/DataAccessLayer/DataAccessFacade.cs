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

        public static ObservableCollection<League> UpdateLeagueStatus()
        {
            UpdateData UD = new UpdateData();
            return UD.
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
    }
}
