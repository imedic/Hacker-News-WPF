using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using hacker_news_wpf_client.ViewModels;

namespace hacker_news_wpf_client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var app = new ShellView();
            var context = new ShellViewModel();
            app.DataContext = context;
            app.Show();
        }
    }
}
