using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
        public StoryDetailsViewModel(int id)
        {
            LoadStory(id);
        }

        private Story _story;

        public Story Story
        {
            get
            {
                return _story;
            }
            set
            {
                _story = value;
                RaisePropertyChanged(() => Story);
            }
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                RaisePropertyChanged(() => IsLoading);
            }
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                RaisePropertyChanged(() => ErrorMessage);
            }
        }

        private async void LoadStory(int id)
        {
            try
            {
                IsLoading = true;
                Story = await HackerNewsService.GetStory(id);
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
