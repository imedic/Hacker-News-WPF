using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hacker_news_wpf_client.Helper_Classes;
using hacker_news_wpf_client.Intefaces.hacker_news_wpf_client.Intefaces;
using hacker_news_wpf_client.Model;
using hacker_news_wpf_client.Services;

namespace hacker_news_wpf_client.ViewModels
{
    public class StoryItemViewModel : ObservableObject, IPageViewModel
    {
        public string Name => "Story details example";

        public NotifyTaskCompletion<Story> Story { get; private set; }

        public StoryItemViewModel(int id)
        {
            Story = new NotifyTaskCompletion<Story>(StoryService.GetStory(id));

        }
    }
}
