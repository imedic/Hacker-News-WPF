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

namespace hacker_news_wpf_client.Controls
{
    /// <summary>
    /// Interaction logic for LoadingIndicatorControl.xaml
    /// </summary>
    public partial class LoadingIndicatorControl : UserControl
    {
        public LoadingIndicatorControl()
        {
            InitializeComponent();
        }

        public bool IsLoading
        {
            get { return (bool) GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value);}
        }

        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register("IsLoading", typeof(bool), typeof(LoadingIndicatorControl));

    }
}
