using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DomainLayer;

namespace DatabaseAccessLayer
{
    public class SaveData
    {
        private void SaveTeam(TEAM t)
        {
            int teamID = t.teamID;
            string teamName = t.teamName;
            int leagueID = t.leagueID;
            int leaguePoint = t.leaguePoint;

            SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");

            try
            {
                DBcon.Open();
                SqlCommand cmd = new SqlCommand("InsertTeam", DBcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TeamID", teamID);
                cmd.Parameters.AddWithValue("@TeamName", teamName);
                cmd.Parameters.AddWithValue("@LeagueID", leagueID);
                cmd.Parameters.AddWithValue("@LeaguePoint", leaguePoint);

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

        private void SaveLeague(LEAGUE l)
        {
            int leagueID = l.leagueID;
            string leagueName = l.leagueName;
            string reward = l.reward;
            int rounds = l.rounds;
            string gameName = l.gameName;
            string gameStatus = l.gameStatus;

            SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");

            try
            {
                DBcon.Open();
                SqlCommand cmd = new SqlCommand("InsertLeague", DBcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@LeagueID", leagueID);
                cmd.Parameters.AddWithValue("@LeagueName", leagueName);
                cmd.Parameters.AddWithValue("@Reward", reward);
                cmd.Parameters.AddWithValue("@Rounds", rounds);
                cmd.Parameters.AddWithValue("@GameName", gameName);
                cmd.Parameters.AddWithValue("GameStatus", gameStatus);

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

        private void SavePlayer(PLAYER p)
        {
            int playerID = p.playerID;
            string firstName = p.firstName;
            string lastName = p.lastName;
            string email = p.email;
            int phoneNr = p.phoneNr;

            SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");

            try
            {
                DBcon.Open();
                SqlCommand cmd = new SqlCommand("InsertPlayer", DBcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PlayerID", playerID);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@phoneNr", phoneNr);

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

        public void SaveRound(ROUND R)
        {
            int roundID = R.roundID;
            string roundName = R.roundName;
            string roundType = R.roundType;
            int leagueID = R.leagueID;

            SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");

            try
            {
                DBcon.Open();
                SqlCommand cmd = new SqlCommand("InsertPlayer", DBcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RoundID", roundID);
                cmd.Parameters.AddWithValue("@RoundName", roundName);
                cmd.Parameters.AddWithValue("@RoundType", roundType);
                cmd.Parameters.AddWithValue("@LeagueID", leagueID);

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

        private void SaveMatch(MATCH M)
        {
            int matchID = M.matchID;
            int roundID = M.roundID;
            string winner = M.winner;

            SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");

            try
            {
                DBcon.Open();
                SqlCommand cmd = new SqlCommand("InsertLeague", DBcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MatchID", matchID);
                cmd.Parameters.AddWithValue("@RoundID", roundID);
                cmd.Parameters.AddWithValue("@Winner", winner);

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

        private void SavePlayersInTeams(PLAYER p)
        {
            int playerID = p.playerID;
            string firstName = p.firstName;
            string lastName = p.lastName;
            string email = p.email;
            int phoneNr = p.phoneNr;

            SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");

            try
            {
                DBcon.Open();
                SqlCommand cmd = new SqlCommand("InsertPlayer", DBcon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PlayerID", playerID);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@phoneNr", phoneNr);

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
    }
}
}
