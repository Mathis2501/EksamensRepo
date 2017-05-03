using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BusinessLayer;
using DomainLayer;
// ReSharper disable PossibleInvalidOperationException

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
            rb_OneTeamMember.IsChecked = true;
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();

            this.Close();
        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<TextBox> collection = addLeagueWindow.Children.OfType<TextBox>();
            foreach (var item in collection)
            {
                item.Text = "";
            }
            rb_OneTeamMember.IsChecked = true;
            cb_Rounds.SelectedIndex = 0;
            cb_Status.SelectedIndex = 0;
        }

        private void btn_SaveLeague_Click(object sender, RoutedEventArgs e)
        {
            League newLeague = new League();
            newLeague.GameName = txt_GameName.Text;
            newLeague.LeagueName = txt_LeagueName.Text;
            newLeague.Reward = txt_Reward.Text;

            ComboBoxItem CBI = (ComboBoxItem) cb_Status.SelectedItem;
            newLeague.LeagueStatus = CBI.ToString();
            //removes unwanted words from ComboBoxItem. uses space to go to the start of the word needed
            newLeague.LeagueStatus = newLeague.LeagueStatus.Substring(newLeague.LeagueStatus.IndexOf(" ", StringComparison.Ordinal)+1);
            newLeague.Rounds = cb_Rounds.SelectedIndex + 1;
            IEnumerable<RadioButton> rb_collection = addLeagueWindow.Children.OfType<RadioButton>();
            foreach (var item in rb_collection)
            {
                if (item.IsChecked.Value)
                {

                    newLeague.NumberOfTeamMembers = int.Parse(item.Content.ToString().Substring(0,1));
                }
            }
            
            newLeague.LeagueId = BusinessFacade.SaveLeague(newLeague);

            IEnumerable<TextBox> tb_collection = addLeagueWindow.Children.OfType<TextBox>();
            foreach (var item in tb_collection)
            {
                if (item.Name.Contains("Round"))
                {
                    if (item.IsEnabled)
                    {
                        Round newRound = new Round();
                        newRound.RoundName = item.Text;
                        BusinessFacade.SaveRound(newRound, newLeague.LeagueId);
                    }
                }
            }
            MainWindow MW = new MainWindow();
            MW.Show();
            this.Close();
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
