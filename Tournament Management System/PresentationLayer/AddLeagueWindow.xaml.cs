using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for AddLeagueWindow.xaml
    /// </summary>
    public partial class AddLeagueWindow : Window
    {
        public AddLeagueWindow()
        {
            InitializeComponent();
            txt_Round2Name.IsEnabled = false;
            txt_Round3Name.IsEnabled = false;
            txt_Round4Name.IsEnabled = false;
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
            this.Hide();
        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<TextBox> collection = addLeagueWindow.Children.OfType<TextBox>();
            foreach (var item in collection)
            {
                item.Text = "";
            }
            rb_OneTeamMember.IsEnabled = true;
            cb_Rounds.SelectedIndex = 0;
            cb_Status.SelectedIndex = 0;
        }

        private void btn_SaveLeague_Click(object sender, RoutedEventArgs e)
        {
            LEAGUE newLeague = new LEAGUE();
            newLeague.GameName = txt_GameName.Text;
            newLeague.LeagueName = txt_LeagueName.Text;
            newLeague.LeagueStatus = cb_Status.SelectedItem.ToString();
            newLeague.Reward = txt_Reward.Text;
            IEnumerable<RadioButton> collection = addLeagueWindow.Children.OfType<RadioButton>();
            foreach (var item in collection)
            {
                if (item.IsEnabled)
                {
                    newLeague.LeagueName = $"{txt_LeagueName.Text} {item.Content.ToString()}";
                }
            }
            BusinessFacade.SaveLeague();
        }

        private void cb_Rounds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (txt_Round1Name != null)
            {
                if (cb_Rounds.SelectedIndex == 0)
                {
                    txt_Round2Name.IsEnabled = false;
                    txt_Round3Name.IsEnabled = false;
                    txt_Round4Name.IsEnabled = false;
                    txt_Round2Name.Text = "";
                    txt_Round3Name.Text = "";
                    txt_Round4Name.Text = "";
                }
                else if (cb_Rounds.SelectedIndex == 1)
                {
                    txt_Round2Name.IsEnabled = true;
                    txt_Round3Name.IsEnabled = false;
                    txt_Round4Name.IsEnabled = false;
                    txt_Round3Name.Text = "";
                    txt_Round4Name.Text = "";
                }
                else if (cb_Rounds.SelectedIndex == 2)
                {
                    txt_Round2Name.IsEnabled = true;
                    txt_Round3Name.IsEnabled = true;
                    txt_Round4Name.IsEnabled = false;
                    txt_Round4Name.Text = "";
                }
                else if (cb_Rounds.SelectedIndex == 3)
                {
                    txt_Round2Name.IsEnabled = true;
                    txt_Round3Name.IsEnabled = true;
                    txt_Round4Name.IsEnabled = true;
                }
            }
        }
    }
}
