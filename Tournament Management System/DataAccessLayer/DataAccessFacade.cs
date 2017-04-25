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
        public static ObservableCollection<LEAGUE> FillLeagueDataGrid()
        {
            GetData GD = new GetData();
            return GD.GetLeagues();

        }
    }
}
