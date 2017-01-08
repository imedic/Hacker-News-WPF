using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hacker_news_wpf_client.Intefaces.hacker_news_wpf_client.Intefaces;
using hacker_news_wpf_client.Model;
using hacker_news_wpf_client.Services;
using hacker_news_wpf_client.Utility;

namespace hacker_news_wpf_client.ViewModels
{
    class NewStoriesViewModel : ObservableObject, IPageViewModel
    {
        public string Name => "New";

        public NotifyTaskCompletion<List<Story>> NewStories { get; private set; }

        public NewStoriesViewModel()
        {
            NewStories = new NotifyTaskCompletion<List<Story>>(
                HackerNewsService.GetNewStories());
        }
    }
}
