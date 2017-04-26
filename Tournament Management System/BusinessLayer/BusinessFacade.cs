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
    public static class BusinessFacade
    {
        public static ObservableCollection<LEAGUE> GetLeagueData()
        {
            return DataAccessFacade.GetLeagueData();
        }

        public static void SaveLeague()
        {
            DataAccessFacade.SaveLeague();
        }
    }
}
