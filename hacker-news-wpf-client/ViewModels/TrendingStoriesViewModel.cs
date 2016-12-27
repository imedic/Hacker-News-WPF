using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using hacker_news_wpf_client.Helper_Classes;
using hacker_news_wpf_client.Intefaces.SimpleMVVMExample;
using hacker_news_wpf_client.Model;
using hacker_news_wpf_client.Services;
using Newtonsoft.Json;

namespace hacker_news_wpf_client.ViewModels
{
    class TrendingStoriesViewModel : ObservableObject, IPageViewModel
    {
        public string Name => "Trending";

        public NotifyTaskCompletion<List<Story>> TrendingStories { get; private set; }

        public TrendingStoriesViewModel()
        {
            TrendingStories = new NotifyTaskCompletion<List<Story>>(
                StoryService.GetTrendingStories());
        }
    }
}
