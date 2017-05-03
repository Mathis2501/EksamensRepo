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
    /// Interaction logic for PlayerView.xaml
    /// </summary>
    public partial class PlayerView : Window
    {
        private ObservableCollection<Player> PlayerList;
        public PlayerView()
        {
            InitializeComponent();
            PlayerList = new ObservableCollection<Player>();
            PlayerList = BusinessFacade.GetPlayerData();
            PlayerDataGrid.ItemsSource = PlayerList;
        }

        private void btn_AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            AddPlayerWindow APW = new AddPlayerWindow();
            APW.ShowDialog();
            PlayerDataGrid.Items.Refresh();
        }
        
        private void btn_ViewLeagues_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
            this.Close();
        }
        
    }
}
