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
    public class StoryDetailsViewModel : ViewModelBase
    {
        public NotifyTaskCompletion<Story> Story { get; private set; }

        public StoryDetailsViewModel(int id)
        {
            Story = new NotifyTaskCompletion<Story>(HackerNewsService.GetStory(id));

        }
    }
}
