//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data;
//using System.Data.SqlClient;
//using DomainLayer;
//using System.Collections.ObjectModel;

//namespace DataAccessLayer
//{
    
//        public class SaveData
//      {

//          private void SaveTeam(TEAM newTeam)
//          {
             
  
//              SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");
  
//              try
//              {
//                  DBcon.Open();
//                  SqlCommand cmd = new SqlCommand("InsertTeam", DBcon);
//                  cmd.CommandType = CommandType.StoredProcedure;
  
//                  cmd.Parameters.AddWithValue("@TeamID", newTeam.TeamID_PK);
//                  cmd.Parameters.AddWithValue("@TeamName", newTeam.TeamName);
//                  cmd.Parameters.AddWithValue("@LeagueID", newTeam.LeagueID_FK);
//                  cmd.Parameters.AddWithValue("@LeaguePoint", newTeam.LeaguePoint);
  
//                  cmd.ExecuteNonQuery();
//              }
  
//              catch (SqlException e)
//              {
//                  Console.WriteLine("ups " +  e.Message);
//                  Console.ReadKey();
//              }
//              finally
//              {
//                  DBcon.Close();
//                  DBcon.Dispose();
//              }
//          }

//          internal void SaveLeague(LEAGUE newLeague)
//          {
//            GetData GD = new GetData();
//            ObservableCollection<IID> LeagueList = new ObservableCollection<IID>();
//            LeagueList = GD.GetLeagueID();
//            int LeagueID;
//            LeagueID = GetID(LeagueList);

//              SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");
  
//              try
//              {
//                  DBcon.Open();
//                  SqlCommand cmd = new SqlCommand("InsertLeague", DBcon);
//                  cmd.CommandType = CommandType.StoredProcedure;
  
//                  cmd.Parameters.AddWithValue("@LeagueID", newLeague.LeagueID_PK);
//                  cmd.Parameters.AddWithValue("@LeagueName", newLeague.LeagueName);
//                  cmd.Parameters.AddWithValue("@Reward", newLeague.LeagueName);
//                  cmd.Parameters.AddWithValue("@Rounds", newLeague.Rounds);
//                  cmd.Parameters.AddWithValue("@GameName", newLeague.GameName);
//                  cmd.Parameters.AddWithValue("@LeagueStatus", newLeague.LeagueStatus);
  
//                  cmd.ExecuteNonQuery();
//              }
//              catch (SqlException e)
//              {
//                  Console.WriteLine("ups " + e.Message);
//                  Console.ReadKey();
//              }
//              finally
//              {
//                  DBcon.Close();
//                  DBcon.Dispose();
//              }
//          }
  
//          private void SavePlayer(PLAYER newPlayer)
//          {
//              int playerID = newPlayer.PlayerID_PK;
//              string firstName = newPlayer.FirstName;
//              string lastName = newPlayer.LastName;
//              string email = newPlayer.Email;
//              int phoneNr = newPlayer.PhoneNr;
  
//              SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");
  
//              try
//              {
//                  DBcon.Open();
//                  SqlCommand cmd = new SqlCommand("InsertPlayer", DBcon);
//                  cmd.CommandType = CommandType.StoredProcedure;
  
//                  cmd.Parameters.AddWithValue("@PlayerID", playerID);
//                  cmd.Parameters.AddWithValue("@FirstName", firstName);
//                  cmd.Parameters.AddWithValue("@LastName", lastName);
//                  cmd.Parameters.AddWithValue("@Email", email);
//                  cmd.Parameters.AddWithValue("@phoneNr", phoneNr);
  
//                  cmd.ExecuteNonQuery();
  
//              }
//              catch (SqlException e)
//              {
//                  Console.WriteLine("ups "  + e.Message);
//                  Console.ReadKey();
//              }
//              finally
//              {
//                  DBcon.Close();
//                  DBcon.Dispose();
//              }
//          }
  
//          public void SaveRound(ROUND R)
//          {
//              int roundID = R.roundID;
//              string roundName = R.roundName;
//              string roundType = R.roundType;
//              int leagueID = R.leagueID;
  
//              SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");
  
//              try
//             {
//                 DBcon.Open();
//                 SqlCommand cmd = new SqlCommand("InsertPlayer", DBcon);
//                 cmd.CommandType = CommandType.StoredProcedure;
 
//                 cmd.Parameters.AddWithValue("@RoundID", roundID);
//                 cmd.Parameters.AddWithValue("@RoundName", roundName);
//                 cmd.Parameters.AddWithValue("@RoundType", roundType);
//                 cmd.Parameters.AddWithValue("@LeagueID", leagueID);
 
//                 cmd.ExecuteNonQuery();
 
//             }
//             catch (SqlException e)
//             {
//                 Console.WriteLine("ups "  + e.Message);
//                 Console.ReadKey();
//             }
//             finally
//             {
//                 DBcon.Close();
//                 DBcon.Dispose();
//             }
 
//         }
 
//         private void SaveMatch(MATCH M)
//         {
//             int matchID = M.matchID;
//             int roundID = M.roundID;
//             string winner = M.winner;
 
//             SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");
 
//             try
//             {
//                 DBcon.Open();
//                 SqlCommand cmd = new SqlCommand("InsertLeague", DBcon);
//                 cmd.CommandType = CommandType.StoredProcedure;
 
//                 cmd.Parameters.AddWithValue("@MatchID", matchID);
//                 cmd.Parameters.AddWithValue("@RoundID", roundID);
//                 cmd.Parameters.AddWithValue("@Winner", winner);
 
//                 cmd.ExecuteNonQuery();
//             }
//             catch (SqlException e)
//             {
//                 Console.WriteLine("ups "  + e.Message);
//                 Console.ReadKey();
//             }
//             finally
//             {
//                 DBcon.Close();
//                 DBcon.Dispose();
//             }
//         }
 
//         private void SavePlayersInTeams(PLAYER p)
//         {
//             int playerID = p.playerID;
//             string firstName = p.firstName;
//             string lastName = p.lastName;
//             string email = p.email;
//             int phoneNr = p.phoneNr;
 
//             SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");
 
//             try
//             {
//                 DBcon.Open();
//                 SqlCommand cmd = new SqlCommand("InsertPlayer", DBcon);
//                 cmd.CommandType = CommandType.StoredProcedure;
 
//                 cmd.Parameters.AddWithValue("@PlayerID", playerID);
//                 cmd.Parameters.AddWithValue("@FirstName", firstName);
//                 cmd.Parameters.AddWithValue("@LastName", lastName);
//                 cmd.Parameters.AddWithValue("@Email", email);
//                 cmd.Parameters.AddWithValue("@phoneNr", phoneNr);
 
//                 cmd.ExecuteNonQuery();
 
//             }
//             catch (SqlException e)
//             {
//                 Console.WriteLine("ups "  + e.Message);
//                 Console.ReadKey();
//              }
//             finally
//             {
//                 DBcon.Close();
//                 DBcon.Dispose();
//             }
//         }

//        private int GetID(ObservableCollection<IID> ItemList)
//        {
//            int ItemID = 1;
//            if (ItemList.Count != 0)
//            {
//                ItemID = ItemList[ItemList.Count - 1].ID + 1;
//            }
//            return ItemID;
//        }
//     }
// }
