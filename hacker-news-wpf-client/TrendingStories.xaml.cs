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

namespace hacker_news_wpf_client
{
    /// <summary>
    /// Interaction logic for TrendingStories.xaml
    /// </summary>
    public partial class TrendingStories : Page
    {
        public TrendingStories()
        {
            InitializeComponent();

            this.DataContext = new TrendingStoriesViewModel();
        }
    }
}
