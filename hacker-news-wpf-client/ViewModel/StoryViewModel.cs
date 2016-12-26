using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using hacker_news_wpf_client.Model;
using hacker_news_wpf_client.Services;
using Newtonsoft.Json;

namespace hacker_news_wpf_client
{
    class StoryViewModel
    {
        public NotifyTaskCompletion<List<Story>> TrendingStories { get; private set; }

        public StoryViewModel()
        {
            TrendingStories = new NotifyTaskCompletion<List<Story>>(
                StoryService.GetTrendingStories());
        }
    }
}
