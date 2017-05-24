using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessLayer;
using DomainLayer;
using Match = System.Text.RegularExpressions.Match;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for LeagueOverviewView.xaml
    /// </summary>
    public partial class LeagueOverviewView : Window
    {
        private string[] LeagueStatusIndex;
        private League ChosenLeague;
        private Team ChosenTeam;
        public LeagueOverviewView(League chosenLeague)
        {
            InitializeComponent();
            ChosenLeague = chosenLeague;
            LeagueStatusIndex = new string[4] { "Afventende", "Igangværende", "Afsluttet", "Annulleret" };
            lbl_LeagueName.Content = chosenLeague.LeagueName;
            lbl_CurrentGameName.Content = chosenLeague.GameName;
            lbl_CurrentReward.Content = chosenLeague.Reward;
            lbl_CurrentNumberOfTeamMembers.Content = "1 Person(er)";
            cb_Status.SelectedIndex = Array.IndexOf(LeagueStatusIndex, chosenLeague.LeagueStatus);
            lbl_CurrentNumberOfPlayers.Content = chosenLeague.TeamsInLeague.Count;
            RoundDataGrid.ItemsSource = chosenLeague.RoundsInLeague;
            TeamDataGrid.ItemsSource = chosenLeague.TeamsInLeague;

        }

        private void btn_ViewLeagues_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void dg_Rounds_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void RoundDataGrid_Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            RoundOverviewView ROV = new RoundOverviewView((Round)RoundDataGrid.CurrentItem, ChosenLeague.LeagueName, ChosenLeague.GameName);
            ROV.Show();
        }

        private void btn_AddTeam_Click(object sender, RoutedEventArgs e)
        {
            AddPlayerToLeagueView APTLV = new AddPlayerToLeagueView(ChosenLeague);
            this.Hide();
            APTLV.Owner = this;
            APTLV.ShowDialog();
            TeamDataGrid.ItemsSource = null;
            TeamDataGrid.ItemsSource = ChosenLeague.TeamsInLeague;
        }

        private void TeamDataGrid_Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            TeamOverviewView TOV = new TeamOverviewView((Team)TeamDataGrid.CurrentItem);
            this.Hide();
            TOV.ShowDialog();
            this.Show();
        }

        private void cb_Status_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (cb_Status.SelectedIndex == 0)
            {
                BusinessFacade.UpdateLeagueStatus(ChosenLeague.LeagueId, "Afventende");
                btn_AddTeam.IsEnabled = true;
            }
            else if (cb_Status.SelectedIndex == 1)
            {
                BusinessFacade.UpdateLeagueStatus(ChosenLeague.LeagueId, "Igangværende");
                btn_AddTeam.IsEnabled = false;
                if (ChosenLeague.RoundsInLeague.All(x => x.MatchesInRound.Count == 0))
                {
                    BusinessFacade.CreateMatches(ChosenLeague.TeamsInLeague, ChosenLeague.RoundsInLeague);
                }
            }
            else if (cb_Status.SelectedIndex == 2)
            {
                BusinessFacade.UpdateLeagueStatus(ChosenLeague.LeagueId, "Afsluttet");
                btn_AddTeam.IsEnabled = false;
            }
            else if (cb_Status.SelectedIndex == 3)
            {
                BusinessFacade.UpdateLeagueStatus(ChosenLeague.LeagueId, "Annulleret");
                btn_AddTeam.IsEnabled = false;
            }
        }

        private void btn_DeleteLeague(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Vil du slette denne liga?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                BusinessLayer.BusinessFacade.DeleteLeague(ChosenLeague);
                this.Owner.Show();
                this.Close();
            }
        }
    }
}
