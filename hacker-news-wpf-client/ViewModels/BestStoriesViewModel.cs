using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hacker_news_wpf_client.Helper_Classes;
using hacker_news_wpf_client.Intefaces.SimpleMVVMExample;
using hacker_news_wpf_client.Model;
using hacker_news_wpf_client.Services;

namespace hacker_news_wpf_client.ViewModels
{
    class BestStoriesViewModel : ObservableObject, IPageViewModel
    {
        public string Name => "Best";

        public NotifyTaskCompletion<List<Story>> BestStories { get; private set; }

        public BestStoriesViewModel()
        {
            BestStories = new NotifyTaskCompletion<List<Story>>(
                StoryService.GetBestStories());
        }
    }
}
