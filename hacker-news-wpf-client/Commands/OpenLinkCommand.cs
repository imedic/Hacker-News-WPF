using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using hacker_news_wpf_client.Controls;
using hacker_news_wpf_client.ViewModels;

namespace hacker_news_wpf_client.Commands
{
    public class OpenLinkCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var url = parameter as string;

            if (url != null) Process.Start(url);
        }

        public event EventHandler CanExecuteChanged;
    }
}
