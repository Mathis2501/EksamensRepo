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


// Vi har 2 metoder til samme af hver tubg fir at


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
            catch (Exception e)
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
                    foreach (var player in query)
                    {
                        PLayerList.Add(player);
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
                    foreach (var team in query)
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
        public ObservableCollection<MATCH> GetMatches()
        {
            ObservableCollection<MATCH> MatchList = new ObservableCollection<MATCH>();
            try
            {
                using (var db = new DataContext())
                {
                    var query = db.MATCHes.OrderBy(x => matchID_PK);
                    foreach (var match in query)
                    {
                        MatchList.Add(match);
                    }
                }
                return MatchList;
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
                var query = db.MATCHes.OrderBy(x => x.MatchID_PK);
                foreach (var item in query)
                {
                    ItemList.Add(item);
                }
            }
            return ItemList;
        }
        public ObservableCollection<ROUND> GetRound()
        {
            ObservableCollection<ROUND> roundList = new ObservableCollection<ROUND>();
            try
            {
                using (var db = new DataContext())
                {
                    var query = db.ROUNDs.OrderBy(x => RoundID_PK);
                    foreach (var round in query)
                    {
                        roundList.Add(round);
                    }
                }
                return roundList;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public ObservableCollection<IID> GetRoundID()
        {
            ObservableCollection<IID> ItemList = new ObservableCollection<IID>();
            using (var db = new DataContext())
            {
                var query = db.ROUNDs.OrderBy(x => x.MatchID_PK);
                foreach (var item in query)
                {
                    ItemList.Add(item);
                }
            }
            return ItemList;
        }
    }
 }
