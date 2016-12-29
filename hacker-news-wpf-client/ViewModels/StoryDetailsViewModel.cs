using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hacker_news_wpf_client.Helper_Classes;
using hacker_news_wpf_client.Intefaces.hacker_news_wpf_client.Intefaces;
using hacker_news_wpf_client.Model;
using hacker_news_wpf_client.Services;

namespace hacker_news_wpf_client.ViewModels
{
    class StoryDetailsViewModel : ObservableObject, IPageViewModel
    {
        public string Name => "Details";

        public NotifyTaskCompletion<Story> Story { get; private set; }

        public NotifyTaskCompletion<List<Comment>> Comments { get; private set; }


        public StoryDetailsViewModel()
        {
            Story = new NotifyTaskCompletion<Story>(StoryService.GetStory(8863));

            Comments = new NotifyTaskCompletion<List<Comment>>(StoryService.GetComments(Story));
        }
    }
}
