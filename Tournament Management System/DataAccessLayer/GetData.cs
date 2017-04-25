using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DomainLayer;

namespace DataAccessLayer
{
    class GetData
    {
        public ObservableCollection<LEAGUE> GetLeagues()
        {
            ObservableCollection<LEAGUE> LeagueList = new ObservableCollection<LEAGUE>();
            using (var db = new DataContext())
            {
                var query = db.LEAGUEs;
                foreach (var League in query)
                {
                    LeagueList.Add(League);
                }
            }
            //{

            //}


        }
    }
}
