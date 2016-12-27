using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hacker_news_wpf_client.Model;
using hacker_news_wpf_client.Services;

namespace hacker_news_wpf_client.ViewModel
{
    class BestStoriesViewModel
    {
        public NotifyTaskCompletion<List<Story>> BestStories { get; private set; }

        public BestStoriesViewModel()
        {
            BestStories = new NotifyTaskCompletion<List<Story>>(
                StoryService.GetBestStories());
        }
    }
}
