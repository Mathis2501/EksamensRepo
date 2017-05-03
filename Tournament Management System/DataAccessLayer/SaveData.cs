using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DomainLayer;
using System.Collections.ObjectModel;

namespace DataAccessLayer
{
    
        public class SaveData
        {

        

        private void SaveTeam(Team newTeam)
        {
            GetData GD = new GetData();
            ObservableCollection<IID> TeamList = new ObservableCollection<IID>();
            TeamList = GD.GetTeamID();
            newTeam.TeamId = GetID(TeamList);
            }

            internal int SaveLeague(League newLeague)
            {
            GetData GD = new GetData();
            ObservableCollection<IID> LeagueList = new ObservableCollection<IID>();
            LeagueList = GD.GetLeagueID();
            newLeague.LeagueId = GetID(LeagueList);


                SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");
  
                try
                {
                    DBcon.Open();
                    SqlCommand cmd = new SqlCommand("InsertLeague", DBcon);
                    cmd.CommandType = CommandType.StoredProcedure;
  
                    cmd.Parameters.AddWithValue("@LeagueID", newLeague.LeagueId);
                    cmd.Parameters.AddWithValue("@LeagueName", newLeague.LeagueName);
                    cmd.Parameters.AddWithValue("@Reward", newLeague.LeagueName);
                    cmd.Parameters.AddWithValue("@Rounds", newLeague.Rounds);
                    cmd.Parameters.AddWithValue("@GameName", newLeague.GameName);
                    cmd.Parameters.AddWithValue("@LeagueStatus", newLeague.LeagueStatus);
                    cmd.Parameters.AddWithValue("@TeamStatus", newLeague.TeamStatus);
  
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("ups " + e.Message);
                }
                finally
                {
                    DBcon.Close();
                    DBcon.Dispose();
                }
            return newLeague.LeagueId;
        }

        private void SavePlayer(Player newPlayer)
        {
            GetData GD = new GetData();
            ObservableCollection<IID> PlayerList = new ObservableCollection<IID>();
            PlayerList = GD.GetPlayerID();
            newPlayer.PlayerId = GetID(PlayerList);

            SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");

            try
            {
                DBcon.Open();
                SqlCommand cmd = new SqlCommand("InsertPlayer", DBcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PlayerID", newPlayer.PlayerId);
                cmd.Parameters.AddWithValue("@FirstName", newPlayer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", newPlayer.LastName);
                cmd.Parameters.AddWithValue("@Email", newPlayer.Email);
                cmd.Parameters.AddWithValue("@phoneNr", newPlayer.PhoneNr);

                cmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                Console.WriteLine("ups " + e.Message);
                Console.ReadKey();
            }
            finally
            {
                DBcon.Close();
                DBcon.Dispose();
            }
        }

        public void SaveRound(Round newRound)
        {
            GetData GD = new GetData();
            ObservableCollection<IID> roundList = new ObservableCollection<IID>();
            roundList = GD.GetRoundID();
            newRound.RoundId = GetID(roundList);

            SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");

            try
            {
                DBcon.Open();
                SqlCommand cmd = new SqlCommand("InsertPlayer", DBcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RoundID", newRound.RoundId);
                cmd.Parameters.AddWithValue("@RoundName", newRound.RoundName);
                cmd.Parameters.AddWithValue("@RoundType", newRound.RoundName);
                cmd.Parameters.AddWithValue("@LeagueID", 1);

                cmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                Console.WriteLine("ups " + e.Message);
                Console.ReadKey();
            }
            finally
            {
                DBcon.Close();
                DBcon.Dispose();
            }

        }

        private void SaveMatch(Match newMatch)
        {
            GetData GD = new GetData();
            ObservableCollection<IID> MatchList = new ObservableCollection<IID>();
            MatchList = GD.GetMatchID();
            newMatch.MatchId = GetID(MatchList);

            SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");

            try
            {
                DBcon.Open();
                SqlCommand cmd = new SqlCommand("InsertLeague", DBcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MatchID", newMatch.MatchId);
                cmd.Parameters.AddWithValue("@RoundID", newMatch.RoundId);
                cmd.Parameters.AddWithValue("@Winner", 3);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("ups " + e.Message);
                Console.ReadKey();
            }
            finally
            {
                DBcon.Close();
                DBcon.Dispose();
            }
        }

        private void SavePlayersInTeams(Player player , Team team)
        {
             
 
            SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");
 
            try
            {
                DBcon.Open();
                SqlCommand cmd = new SqlCommand("InsertPlayer", DBcon);
                cmd.CommandType = CommandType.StoredProcedure;
 
                cmd.Parameters.AddWithValue("@PlayerID", player.PlayerId);
                cmd.Parameters.AddWithValue("@TeamID", team.ID);
 
                cmd.ExecuteNonQuery();
 
            }
            catch (SqlException e)
            {
                Console.WriteLine("ups " + e.Message);
                Console.ReadKey();
            }
            finally
            {
                DBcon.Close();
                DBcon.Dispose();
            }
        }

        private int GetID(ObservableCollection<IID> ItemList)
        {
            int ItemID = 1;
            if (ItemList.Count != 0)
            {
                ItemID = ItemList[ItemList.Count - 1].ID + 1;
            }
            return ItemID;
        }
    }
}

