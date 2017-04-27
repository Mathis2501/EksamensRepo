﻿using System;
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



          private void SaveTeam(TEAM newTeam)
          {
            GetData GD = new GetData();
            ObservableCollection<IID> TeamList = new ObservableCollection<IID>();
            TeamList = GD.GetLeagueID();
            int teamID;
            teamID = GetID(TeamList);


            SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");
  
              try
              {
                  DBcon.Open();
                  SqlCommand cmd = new SqlCommand("InsertTeam", DBcon);
                  cmd.CommandType = CommandType.StoredProcedure;
  
                  cmd.Parameters.AddWithValue("@TeamID", teamID);
                  cmd.Parameters.AddWithValue("@TeamName", newTeam.TeamName);
                  cmd.Parameters.AddWithValue("@LeagueID", newTeam.LeagueID_FK);
                  cmd.Parameters.AddWithValue("@LeaguePoint", newTeam.LeaguePoint);
  
                  cmd.ExecuteNonQuery();
              }
  
              catch (SqlException e)
              {
                  Console.WriteLine("ups " +  e.Message);
                  Console.ReadKey();
              }
              finally
              {
                  DBcon.Close();
                  DBcon.Dispose();
              }
          }
  
          private void SaveLeague(LEAGUE newLeague)
          {
            GetData GD = new GetData();
            ObservableCollection<IID> LeagueList = new ObservableCollection<IID>();
            LeagueList = GD.GetLeagueID();
            int LeagueID;
            LeagueID = GetID(LeagueList);

              SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");
  
              try
              {
                  DBcon.Open();
                  SqlCommand cmd = new SqlCommand("InsertLeague", DBcon);
                  cmd.CommandType = CommandType.StoredProcedure;
  
                  cmd.Parameters.AddWithValue("@LeagueID", LeagueID);
                  cmd.Parameters.AddWithValue("@LeagueName", newLeague.LeagueName);
                  cmd.Parameters.AddWithValue("@Reward", newLeague.LeagueName);
                  cmd.Parameters.AddWithValue("@Rounds", newLeague.Rounds);
                  cmd.Parameters.AddWithValue("@GameName", newLeague.GameName);
                  cmd.Parameters.AddWithValue("@LeagueStatus", newLeague.LeagueStatus);
  
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
  
          private void SavePlayer(PLAYER newPlayer)
          {
            GetData GD = new GetData();
            ObservableCollection<IID> PlayerList = new ObservableCollection<IID>();
            PlayerList = GD.GetPlayerID();
            newPlayer.PlayerID_PK = GetID(PlayerList);
  
              SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");
  
              try
              {
                  DBcon.Open();
                  SqlCommand cmd = new SqlCommand("InsertPlayer", DBcon);
                  cmd.CommandType = CommandType.StoredProcedure;
  
                  cmd.Parameters.AddWithValue("@PlayerID", newPlayer.);
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
  
          public void SaveRound(ROUND newRound)
          {
         
  
              SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");
  
              try
             {
                 DBcon.Open();
                 SqlCommand cmd = new SqlCommand("InsertPlayer", DBcon);
                 cmd.CommandType = CommandType.StoredProcedure;
 
                 cmd.Parameters.AddWithValue("@RoundID", newRound.RoundID_PK);
                 cmd.Parameters.AddWithValue("@RoundName", newRound.RoundName);
                 cmd.Parameters.AddWithValue("@RoundType", newRound.RoundType);
                 cmd.Parameters.AddWithValue("@LeagueID", newRound.LeagueID_FK);
 
                 cmd.ExecuteNonQuery();
 
             }
             catch (SqlException e)
             {
                 Console.WriteLine("ups " +  e.Message);
                 Console.ReadKey();
             }
             finally
             {
                 DBcon.Close();
                 DBcon.Dispose();
             }
 
         }
 
         private void SaveMatch(MATCH newMatch)
         {
 
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
 
         private void SavePlayersInTeams(PLAYER player , TEAM team)
         {
             
 
             SqlConnection DBcon = new SqlConnection("Server = ealdb1.eal.local; database=ejl44_db; User Id=ejl44_usr; Password=Baz1nga44");
 
             try
             {
                 DBcon.Open();
                 SqlCommand cmd = new SqlCommand("InsertPlayer", DBcon);
                 cmd.CommandType = CommandType.StoredProcedure;
 
                 cmd.Parameters.AddWithValue("@PlayerID", player.PlayerID_PK);
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

