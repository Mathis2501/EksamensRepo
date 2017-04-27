using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;
using DomainLayer;

namespace DataAccessLayer
{
    class GetData
    {
        public ObservableCollection<LEAGUE> GetLeagues()
        {
            ObservableCollection<LEAGUE> LeagueList = new ObservableCollection<LEAGUE>();
            try
            {
                using (var db = new DataContext())
                {
                    var query = db.LEAGUEs.OrderBy(x => x.LeagueID_PK);
                    foreach (var League in query)
                    {
                        LeagueList.Add(League);
                    }
                }
                return LeagueList;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ObservableCollection<IID> GetLeagueID()
        {
            ObservableCollection<IID> ItemList = new ObservableCollection<IID>();
            using (var db = new DataContext())
            {
                var query = db.LEAGUEs.OrderBy(x => x.LeagueID_PK);
                foreach (var item in query)
                {
                    ItemList.Add(item);
                }
            }
            return ItemList;
        }

        public ObservableCollection<PLAYER> GetPlayers()
        {
            ObservableCollection<PLAYER> PLayerList = new ObservableCollection<PLAYER>();
            try
            {
                using (var db = new DataContext())
                {
                    var query = db.PLAYERs.OrderBy(x => x.PlayerID_PK);
                    foreach (var League in query)
                    {
                        PLayerList.Add(Player);
                    }
                }
                return PLayerList;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public ObservableCollection<IID> GetPlayerID()
        {
            ObservableCollection<IID> ItemList = new ObservableCollection<IID>();
            using (var db = new DataContext())
            {
                var query = db.PLAYERs.OrderBy(x => x.PlayerID_PK);
                foreach (var item in query)
                {
                    ItemList.Add(item);
                }
            }
            return ItemList;
        }

        public ObservableCollection<TEAM> GetTeams()
        {
            ObservableCollection<TEAM> TeamList = new ObservableCollection<TEAM>();
            try
            {
                using (var db = new DataContext())
                {
                    var query = db.TEAMs.OrderBy(x => x.TeamID_PK);
                    foreach (var League in query)
                    {
                        TeamList.Add(team);
                    }
                }
                return TeamList;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public ObservableCollection<IID> GetTeamID()
        {
            ObservableCollection<IID> ItemList = new ObservableCollection<IID>();
            using (var db = new DataContext())
            {
                var query = db.TEAMs.OrderBy(x => x.TeamID_PK);
                foreach (var item in query)
                {
                    ItemList.Add(item);
                }
            }
            return ItemList;
        }
        public ObservableCollection<MATCH> GetMatch()
        {
            ObservableCollection<MATCH> TeamList = new ObservableCollection<MATCH>();
            try
            {
                using (var db = new DataContext())
                {
                    var query = db.MATCHs.OrderBy(x => matchID_PK);
                    foreach (var League in query)
                    {
                        TeamList.Add(match);
                    }
                }
                return TeamList;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public ObservableCollection<IID> GetMatchID()
        {
            ObservableCollection<IID> ItemList = new ObservableCollection<IID>();
            using (var db = new DataContext())
            {
                var query = db.Matchs.OrderBy(x => x.MatchID_PK);
                foreach (var item in query)
                {
                    ItemList.Add(item);
                }
            }
            return ItemList;
        }

    }
 }
