using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using hacker_news_wpf_client.Intefaces.hacker_news_wpf_client.Intefaces;
using hacker_news_wpf_client.Model;
using hacker_news_wpf_client.Services;
using hacker_news_wpf_client.Utility;

namespace hacker_news_wpf_client.ViewModels
{
    class BestStoriesViewModel : ViewModelBase, IPageViewModel
    {
        public string Name => "Best";

        public NotifyTaskCompletion<ObservableCollection<Story>> BestStories { get; private set; }

        public BestStoriesViewModel()
        {
            BestStories = new NotifyTaskCompletion<ObservableCollection<Story>>(
                HackerNewsService.GetBestStories());
        }
    }
}
