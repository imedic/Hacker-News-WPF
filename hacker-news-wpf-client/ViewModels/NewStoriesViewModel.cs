using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using hacker_news_wpf_client.Intefaces.hacker_news_wpf_client.Intefaces;
using hacker_news_wpf_client.Model;
using hacker_news_wpf_client.Services;
using hacker_news_wpf_client.Utility;

namespace hacker_news_wpf_client.ViewModels
{
    class NewStoriesViewModel : ViewModelBase, IPageViewModel
    {
        public string Name => "New";
 
        public NewStoriesViewModel()
        {
            LoadNewStories();

            LoadMoreCommand = new RelayCommand(LoadMore);
        }

        private int _pageCounter = 0;

        private ObservableCollection<Story> _newStories;

        public ObservableCollection<Story> NewStories
        {
            get
            {
                return _newStories;
            }
            set
            {
                _newStories = value;
                RaisePropertyChanged(() => NewStories);
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

        public RelayCommand LoadMoreCommand { get; private set; }

        private async void LoadMore()
        {
            try
            {
                ErrorMessage = null;
                IsLoading = true;
                var temp = await HackerNewsService.GetNewStories(_pageCounter);

                foreach (var story in temp)
                {
                    NewStories.Add(story);
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
            finally
            {
                IsLoading = false;
                _pageCounter++;
            }
        }

        private async void LoadNewStories()
        {
            try
            {
                IsLoading = true;
                NewStories = await HackerNewsService.GetNewStories(_pageCounter);
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
            finally
            {
                IsLoading = false;
                _pageCounter++;
            }
        }
    }
}
