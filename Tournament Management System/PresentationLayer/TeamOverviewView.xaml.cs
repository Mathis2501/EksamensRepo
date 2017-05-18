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
    /// Interaction logic for TeamOverviewView.xaml
    /// </summary>
    public partial class TeamOverviewView : Window
    {
        bool byeStatus;
        Team ChosenTeam;
        public TeamOverviewView(Team chosenTeam)
        {
            InitializeComponent();
            lbl_CurrentTeamTeamID.Content = chosenTeam.TeamId;
            lbl_CurrentTeamTeamName.Content = chosenTeam.TeamName;
            ChosenTeam = chosenTeam;

        }

        private void button_Save_Click(object sender, RoutedEventArgs e)
        {
           BusinessLayer.BusinessFacade.UpdateTeam(ChosenTeam , byeStatus);
        }

        private void checkBox_Bye_Click(object sender, RoutedEventArgs e)
        {
            if (byeStatus == true)
            {
                byeStatus = false;
            }
            else
            {
                byeStatus = true;
            }

        }
    }
}
