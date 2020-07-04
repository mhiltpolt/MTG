﻿using MTG.CardMoth.ApiCaller.APIs.Scryfall;
using MTG.CardMoth.DataStorage.DataAccess.Repos;
using MTG.CardMoth.DataStorage.Models;
using MTG.CardMoth.WpfUi.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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

namespace MTG.CardMoth.WpfUi.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void SaveToDbClick(object sender, RoutedEventArgs e)
        {

        }
    }
}