using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using hacker_news_wpf_client.Commands;

namespace hacker_news_wpf_client.Controls
{
    /// <summary>
    /// Interaction logic for StoryItem.xaml
    /// </summary>
    public partial class StoryItemControl : UserControl
    {
        public StoryItemControl()
        {
            InitializeComponent();
        }

        private void OpenLink(object sender, RoutedEventArgs e)
        {
            var url = ((Button) sender).Tag as string;

            if(url != null) Process.Start(url);
        }
    }
}
