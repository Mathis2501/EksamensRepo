using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessLayer;
using DomainLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ObservableCollection<League> LeagueList;
        public MainWindow()
        {
            InitializeComponent();
            RefreshGrid();
        }

        private void Btn_AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            AddPlayerWindow APW = new AddPlayerWindow();
            APW.ShowDialog();
            RefreshGrid();
        }

        private void btn_ViewPlayers_Click(object sender, RoutedEventArgs e)
        {
            PlayerView PV = new PlayerView();
            PV.Show();
            this.Close();
        }

        private void btn_AddLeague_Click(object sender, RoutedEventArgs e)
        {
            AddLeagueWindow ALW = new AddLeagueWindow();
            ALW.ShowDialog();
            LeagueDataGrid.Items.Refresh();
        }

        private void grid_Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            LeagueOverviewView LOV = new LeagueOverviewView((League)LeagueDataGrid.CurrentItem);
            LOV.ShowDialog();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            LeagueList = BusinessFacade.GetLeagueData();
            LeagueDataGrid.ItemsSource = null;
            LeagueDataGrid.ItemsSource = LeagueList;
        }
    }
}