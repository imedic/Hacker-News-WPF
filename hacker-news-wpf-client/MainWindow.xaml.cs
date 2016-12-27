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
using System.Windows.Navigation;
using System.Windows.Shapes;
using hacker_news_wpf_client.ViewModel;

namespace hacker_news_wpf_client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //this.DataContext = new MainViewModel();

            InitializeComponent();

            MainFrame.Navigate(new TrendingStories());

        }

        private void NavigateToBestStoriesPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BestStories());
        }
    }
}
