using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DomainLayer;


// Vi har 2 metoder til samme af hver tubg fir at


namespace DataAccessLayer
{
    class GetData
    {
        private string ConnectionsString =
            "Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44";

        public ObservableCollection<League> GetLeagues()
        {
            ObservableCollection<League> LeagueList = new ObservableCollection<League>();
            using (var DBcon = new SqlConnection(ConnectionsString))
            {
                try
                {
                    string cmdString = "Select LeagueID_PK, LeagueName, Reward, GameName, LeagueStatus, TeamStatus from League";
                    SqlCommand Cmd = new SqlCommand(cmdString, DBcon);

                    DBcon.Open();
                    using (SqlDataReader Reader = Cmd.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            League newLeague = new League();
                            newLeague.LeagueId = int.Parse(Reader["LeagueID_PK"].ToString());
                            newLeague.LeagueName = Reader["LeagueName"].ToString();
                            newLeague.Reward = Reader["Reward"].ToString();
                            newLeague.GameName = Reader["GameName"].ToString();
                            newLeague.LeagueStatus = Reader["LeagueStatus"].ToString();
                            newLeague.NumberOfTeamMembers = int.Parse(Reader["TeamStatus"].ToString());
                            //Get All Teams in League
                            newLeague.TeamsInLeague = GetTeamsFromLeagueID(newLeague.LeagueId);
                            //Get all Rounds in League
                            newLeague.RoundsInLeague = GetRoundsFromLeagueID(newLeague.LeagueId, newLeague.TeamsInLeague);
                            LeagueList.Add(newLeague);
                        }
                    }
                    return LeagueList;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    DBcon.Close();
                    DBcon.Dispose();
                }
            }
        }

        public ObservableCollection<IID> GetLeagueID()
        {
            ObservableCollection<IID> ItemList = new ObservableCollection<IID>();
            using (var DBcon = new SqlConnection(ConnectionsString))
            {
                //her refererer vi direkte til det row vi gerne vil have så vi kun får den data
                string cmdString = "Select LeagueID_PK from League";
                SqlCommand Cmd = new SqlCommand(cmdString, DBcon);

                DBcon.Open();
                using (SqlDataReader Reader = Cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        IID itemId = new League();
                        itemId.ID = int.Parse(Reader["LeagueID_PK"].ToString());
                        ItemList.Add(itemId);
                    }
                }
            }
            return ItemList;
        }

        public ObservableCollection<Player> GetPlayers()
        {
            ObservableCollection<Player> PlayerList = new ObservableCollection<Player>();
            try
            {
                using (var DBcon = new SqlConnection(ConnectionsString))
                {
                    //vi bruger * tegnet da der ikke er noget tilfælde hvor vi ikke vil have al data ned i programmet når vi kalder denne metode
                    string cmdString = "Select * from Player";
                    SqlCommand Cmd = new SqlCommand(cmdString, DBcon);

                    DBcon.Open();
                    using (SqlDataReader Reader = Cmd.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            Player newPlayer = new Player();
                            newPlayer.PlayerId = int.Parse(Reader["PlayerId_PK"].ToString());
                            newPlayer.FirstName = Reader["FirstName"].ToString();
                            newPlayer.LastName = Reader["LastName"].ToString();
                            newPlayer.Email = Reader["Email"].ToString();
                            newPlayer.PhoneNr = Reader["PhoneNr"].ToString();
                            PlayerList.Add(newPlayer);
                        }
                    }

                }
                return PlayerList;
            }
            catch (SqlException)
            {
                throw;
            }
        }
        private ObservableCollection<Player> GetPlayersFromTeamID(int TeamId)
        {
            ObservableCollection<Player> PlayersInTeam = new ObservableCollection<Player>();
            try
            {
                using (var DBcon = new SqlConnection(ConnectionsString))
                {
                    //vi bruger * tegnet da der ikke er noget tilfælde hvor vi ikke vil have al data ned i programmet når vi kalder denne metode
                    string cmdString = $"Select * from TEAM where {TeamId}";
                    SqlCommand Cmd = new SqlCommand(cmdString, DBcon);

                    DBcon.Open();
                    using (SqlDataReader Reader = Cmd.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            Player newPlayer = new Player();
                            newPlayer.PlayerId = int.Parse(Reader["PlayerID_PK"].ToString());
                            newPlayer.FirstName = Reader["FirstName"].ToString();
                            newPlayer.LastName = Reader["LastName"].ToString();
                            newPlayer.Email = Reader["Email"].ToString();
                            newPlayer.PhoneNr = Reader["PhoneNr"].ToString();
                            PlayersInTeam.Add(newPlayer);
                        }
                    }
                    return PlayersInTeam;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                
            }
        }

        public ObservableCollection<IID> GetPlayerID()
        {
            ObservableCollection<IID> ItemList = new ObservableCollection<IID>();
            using (var DBcon = new SqlConnection(ConnectionsString))
            {
                //her refererer vi direkte til det row vi gerne vil have så vi kun får den data
                string cmdString = "Select PlayerID_PK from Player";
                SqlCommand Cmd = new SqlCommand(cmdString, DBcon);

                DBcon.Open();
                using (SqlDataReader Reader = Cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        IID itemId = new League();
                        itemId.ID = int.Parse(Reader["PlayerID_PK"].ToString());
                        ItemList.Add(itemId);
                    }
                }
            }
            return ItemList;
        }

        public ObservableCollection<Team> GetTeams()
        {
            ObservableCollection<Team> TeamList = new ObservableCollection<Team>();
            try
            {
                using (var DBcon = new SqlConnection(ConnectionsString))
                {
                    //vi bruger * tegnet da der ikke er noget tilfælde hvor vi ikke vil have al data ned i programmet når vi kalder denne metode
                    string cmdString = "Select * from TEAM";
                    SqlCommand Cmd = new SqlCommand(cmdString, DBcon);

                    DBcon.Open();
                    using (SqlDataReader Reader = Cmd.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            Team newTeam = new Team();
                            newTeam.TeamId = int.Parse(Reader["TeamId_PK"].ToString());
                            newTeam.TeamName = Reader["TeamName"].ToString();
                            newTeam.LeaguePoints = int.Parse(Reader["LeaguePoint"].ToString());
                            TeamList.Add(newTeam);
                        }
                    }

                }
                return TeamList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ObservableCollection<Team> GetTeamsFromLeagueID(int LeagueID)
        {
            ObservableCollection<Team> TeamsInLeague = new ObservableCollection<Team>();
            try
            {
                using (var DBcon = new SqlConnection(ConnectionsString))
                {
                    //vi bruger * tegnet da der ikke er noget tilfælde hvor vi ikke vil have alle data column ned i programmet når vi kalder denne metode
                    string cmdString = $"Select * from TEAM where LeagueID_FK={LeagueID}";
                    SqlCommand Cmd = new SqlCommand(cmdString, DBcon);

                    DBcon.Open();
                    using (SqlDataReader Reader = Cmd.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            Team newTeam = new Team();
                            newTeam.TeamId = int.Parse(Reader["TeamId_PK"].ToString());
                            newTeam.TeamName = Reader["TeamName"].ToString();
                            newTeam.LeaguePoints = int.Parse(Reader["LeaguePoint"].ToString());
                            newTeam.PlayersInTeam = GetPlayersFromTeamID(newTeam.TeamId);
                            TeamsInLeague.Add(newTeam);
                        }
                    }
                    return TeamsInLeague;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public ObservableCollection<Team> GetTeamsFromRoundID(int RoundId)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<IID> GetTeamID()
        {
            ObservableCollection<IID> ItemList = new ObservableCollection<IID>();
            using (var DBcon = new SqlConnection(ConnectionsString))
            {
                //her refererer vi direkte til det row vi gerne vil have så vi kun får den data
                string cmdString = "Select TeamID_PK from TEAM";
                SqlCommand Cmd = new SqlCommand(cmdString, DBcon);

                DBcon.Open();
                using (SqlDataReader Reader = Cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        IID itemId = new League();
                        itemId.ID = int.Parse(Reader["TeamID_PK"].ToString());
                        ItemList.Add(itemId);
                    }
                }
            }
            return ItemList;
        }
        public ObservableCollection<Match> GetMatches()
        {
            ObservableCollection<Match> MatchList = new ObservableCollection<Match>();
            try
            {
                using (var DBcon = new SqlConnection(ConnectionsString))
                {
                    //vi bruger * tegnet da der ikke er noget tilfælde hvor vi ikke vil have al data ned i programmet når vi kalder denne metode
                    string cmdString = "Select * from MATCH";
                    SqlCommand Cmd = new SqlCommand(cmdString, DBcon);

                    DBcon.Open();
                    using (SqlDataReader Reader = Cmd.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            Match newMatch = new Match();
                            newMatch.MatchId = int.Parse(Reader["MatchID_PK"].ToString());
                            MatchList.Add(newMatch);
                        }
                    }
                }
                return MatchList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private ObservableCollection<Match> GetMatchesFromRoundID(int roundId)
        {
            ObservableCollection<Match> MatchList = new ObservableCollection<Match>();
            try
            {
                using (var DBcon = new SqlConnection(ConnectionsString))
                {
                    //vi bruger * tegnet da der ikke er noget tilfælde hvor vi ikke vil have al data ned i programmet når vi kalder denne metode
                    string cmdString = $"Select * from MATCH where RoundID_FK={roundId}";
                    SqlCommand Cmd = new SqlCommand(cmdString, DBcon);

                    DBcon.Open();
                    using (SqlDataReader Reader = Cmd.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            Match newMatch = new Match();
                            newMatch.MatchId = int.Parse(Reader["MatchID_PK"].ToString());
                            MatchList.Add(newMatch);
                        }
                    }
                }
                return MatchList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ObservableCollection<IID> GetMatchID()
        {
            ObservableCollection<IID> ItemList = new ObservableCollection<IID>();
            using (var DBcon = new SqlConnection(ConnectionsString))
            {
                //her refererer vi direkte til det row vi gerne vil have så vi kun får den data
                string cmdString = "Select MatchID_PK from MATCH";
                SqlCommand Cmd = new SqlCommand(cmdString, DBcon);

                DBcon.Open();
                using (SqlDataReader Reader = Cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        IID itemId = new League();
                        itemId.ID = int.Parse(Reader["MatchID_PK"].ToString());
                        ItemList.Add(itemId);
                    }
                }
            }
            return ItemList;
        }
        public ObservableCollection<Round> GetRound()
        {
            ObservableCollection<Round> RoundList = new ObservableCollection<Round>();
            try
            {
                using (var DBcon = new SqlConnection(ConnectionsString))
                {
                    //vi bruger * tegnet da der ikke er noget tilfælde hvor vi ikke vil have al data ned i programmet når vi kalder denne metode
                    string cmdString = "Select * from ROUND";
                    SqlCommand Cmd = new SqlCommand(cmdString, DBcon);

                    DBcon.Open();
                    using (SqlDataReader Reader = Cmd.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            Round newRound = new Round();
                            newRound.RoundId = int.Parse(Reader["RoundID_PK"].ToString());
                            newRound.RoundName = Reader["RoundName"].ToString();
                            newRound.MatchesInRound = GetMatchesFromRoundID(newRound.RoundId);
                            newRound.TeamsInRound = GetTeamsFromRoundID(newRound.RoundId);
                            RoundList.Add(newRound);
                        }
                    }

                }
                return RoundList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ObservableCollection<Round> GetRoundsFromLeagueID(int LeagueID, ObservableCollection<Team> TeamsInLeague)
        {
            ObservableCollection<Round> RoundsInLeague = new ObservableCollection<Round>();
            try
            {
                using (var DBcon = new SqlConnection(ConnectionsString))
                {
                    //vi bruger * tegnet da der ikke er noget tilfælde hvor vi ikke vil have alle data column ned i programmet når vi kalder denne metode
                    string cmdString = $"Select * from ROUND where LeagueID_FK={LeagueID}";
                    SqlCommand Cmd = new SqlCommand(cmdString, DBcon);

                    DBcon.Open();
                    using (SqlDataReader Reader = Cmd.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            Round newRound = new Round();
                            newRound.RoundId = int.Parse(Reader["RoundID_PK"].ToString());
                            newRound.RoundName = Reader["RoundName"].ToString();
                            newRound.TeamsInRound = TeamsInLeague;
                            newRound.MatchesInRound = GetMatchesFromRoundID(newRound.RoundId);
                            RoundsInLeague.Add(newRound);
                        }
                    }
                    return RoundsInLeague;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ObservableCollection<IID> GetRoundID()
        {
            ObservableCollection<IID> ItemList = new ObservableCollection<IID>();
            using (var DBcon = new SqlConnection(ConnectionsString))
            {
                //her refererer vi direkte til det row vi gerne vil have så vi kun får den data
                string cmdString = "Select RoundID_PK from Round";
                SqlCommand Cmd = new SqlCommand(cmdString, DBcon);

                DBcon.Open();
                using (SqlDataReader Reader = Cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        IID itemId = new League();
                        itemId.ID = int.Parse(Reader["RoundID_PK"].ToString());
                        ItemList.Add(itemId);
                    }
                }
            }
            return ItemList;
        }
    }
 }
