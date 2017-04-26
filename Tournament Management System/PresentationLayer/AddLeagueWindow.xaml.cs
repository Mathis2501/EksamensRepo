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
            cb_Rounds.SelectedValue = "1";
            cb_Status.SelectedValue = "Afventende";
        }

        private void btn_SaveLeague_Click(object sender, RoutedEventArgs e)
        {
            LEAGUE newLeague = new LEAGUE();
            BusinessFacade.SaveLeague();
        }
    }
}
