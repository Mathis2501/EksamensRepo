﻿using System;
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
    /// Interaction logic for AddPlayerToLeagueView.xaml
    /// </summary>
    public partial class AddPlayerToLeagueView : Window
    {
        private League chosenLeague;

        public AddPlayerToLeagueView(League chosenLeague)
        {
            InitializeComponent();
        }

        private void grid_Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
