using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using hacker_news_wpf_client.Intefaces.hacker_news_wpf_client.Intefaces;
using hacker_news_wpf_client.Model;
using hacker_news_wpf_client.Services;
using hacker_news_wpf_client.Utility;

namespace hacker_news_wpf_client.ViewModels
{
    class NewStoriesViewModel : ViewModelBase, IPageViewModel
    {
        public string Name => "New";

        public NotifyTaskCompletion<ObservableCollection<Story>> NewStories { get; private set; }

        public NewStoriesViewModel()
        {
            NewStories = new NotifyTaskCompletion<ObservableCollection<Story>>(
                HackerNewsService.GetNewStories());
        }
    }
}
