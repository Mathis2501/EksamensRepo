﻿using System;
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
    /// Interaction logic for AddPlayerToLeagueView.xaml
    /// </summary>
    public partial class AddPlayerToLeagueView : Window
    {
        private League chosenLeague;
        private ObservableCollection<Player> PlayerList;
        public AddPlayerToLeagueView(League chosenLeague)
        {
            InitializeComponent();
            PlayerList = new ObservableCollection<Player>();
            PlayerList = BusinessFacade.GetPlayerData();
            PlayerDataGrid.ItemsSource = PlayerList;
        }

        private void grid_Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            PlayerOverviewView POV = new PlayerOverviewView((Player)PlayerDataGrid.CurrentItem);
        }

        private void btn_AddToLeague_Click(object sender, RoutedEventArgs e)
        {
            foreach (var VARIABLE in PlayerDataGrid.Is)
            {
                
            }
        }
    }
}
