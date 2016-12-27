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
using System.Windows.Navigation;
using System.Windows.Shapes;
using hacker_news_wpf_client.ViewModels;

namespace hacker_news_wpf_client.Views
{
    /// <summary>
    /// Interaction logic for TrendingStoriesView.xaml
    /// </summary>
    public partial class TrendingStoriesView : UserControl
    {
        public TrendingStoriesView()
        {
            InitializeComponent();

            this.DataContext = new TrendingStoriesViewModel();
        }
    }
}
