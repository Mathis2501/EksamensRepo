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
        
        public static ObservableCollection<LEAGUE> GetLeagueData()
        {
            GetData GD = new GetData();
            return GD.GetLeagues();

        }

        public static int SaveLeague(LEAGUE newLeague)
        {
            SaveData SD = new SaveData();
            return SD.SaveLeague(newLeague);
        }

        public static void SaveRound(ROUND newRound)
        {
            SaveData SD = new SaveData();
            SD.SaveRound(newRound);
        }
    }
}
