using System;
using System.Collections.Generic;
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
using DomainLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for LeagueOverviewView.xaml
    /// </summary>
    public partial class LeagueOverviewView : Window
    {
        string[] LeagueStatusIndex;
        private League ChosenLeague;
        public LeagueOverviewView(League chosenLeague)
        {
            InitializeComponent();
            ChosenLeague = chosenLeague;
            LeagueStatusIndex = new string[4] { "Afventende", "Igangværende", "Afsluttet", "Annulleret" };
            lbl_LeagueName.Content = chosenLeague.LeagueName;
            lbl_CurrentGameName.Content = chosenLeague.GameName;
            lbl_CurrentReward.Content = chosenLeague.Reward;
            lbl_CurrentNumberOfTeamMembers.Content = chosenLeague.NumberOfTeamMembers;
            lbl_CurrentNumberOfTeamMembers.Content += " Person(er)";
            cb_Status.SelectedIndex = Array.IndexOf(LeagueStatusIndex, chosenLeague.LeagueStatus);
            lbl_CurrentNumberOfPlayers.Content = chosenLeague.TeamsInLeague.Count;
            RoundDataGrid.ItemsSource = chosenLeague.RoundsInLeague;
            PlayerDataGrid.ItemsSource = chosenLeague.TeamsInLeague;

        }

        private void btn_ViewLeagues_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dg_Rounds_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void grid_Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            RoundOverviewView ROV = new RoundOverviewView((Round)RoundDataGrid.CurrentItem, ChosenLeague.LeagueName, ChosenLeague.GameName);
            ROV.Show();
        }

        private void btn_AddTeam_Click(object sender, RoutedEventArgs e)
        {
            AddPlayerToLeagueView APTLV = new AddPlayerToLeagueView(ChosenLeague);
            APTLV.Show();
        }
    }
}
