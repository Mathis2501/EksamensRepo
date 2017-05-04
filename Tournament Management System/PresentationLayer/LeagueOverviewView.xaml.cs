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
        public string[] LeagueStatusIndex;
        public LeagueOverviewView(League chosenLeague)
        {
            InitializeComponent();
            LeagueStatusIndex = new string[4] { "Afventende", "Igangværende", "Afsluttet", "Annulleret" };
            lbl_LeagueName.Content = chosenLeague.LeagueName;
            lbl_CurrentGameName.Content = chosenLeague.GameName;
            lbl_CurrentReward.Content = chosenLeague.Reward;
            lbl_CurrentNumberOfTeamMembers.Content = chosenLeague.NumberOfTeamMembers;
            lbl_CurrentNumberOfTeamMembers.Content += " Person(er)";
            cb_Status.SelectedIndex = Array.IndexOf(LeagueStatusIndex, chosenLeague.LeagueStatus);
        }

        private void btn_ViewLeagues_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
