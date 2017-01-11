using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using hacker_news_wpf_client.Intefaces.hacker_news_wpf_client.Intefaces;
using hacker_news_wpf_client.Model;
using hacker_news_wpf_client.Services;
using hacker_news_wpf_client.Utility;
using Newtonsoft.Json;

namespace hacker_news_wpf_client.ViewModels
{
    class TrendingStoriesViewModel : ViewModelBase, IPageViewModel
    {
        public string Name => "Trending";

        private int _pageCounter = 0;

        private ObservableCollection<Story> _trendingStories;

        public ObservableCollection<Story> TrendingStories
        {
            get
            {
                return _trendingStories;
            }
            set
            {
                _trendingStories = value;
                RaisePropertyChanged(() => TrendingStories);
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
                var temp = await HackerNewsService.GetTrendingStories(_pageCounter);

                if (temp != null)
                {
                    foreach (var story in temp)
                    {
                        TrendingStories.Add(story);
                    }
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

        private async void LoadTrendingStories()
        {
            try
            {
                IsLoading = true;
                TrendingStories = await HackerNewsService.GetTrendingStories(_pageCounter);
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

        public TrendingStoriesViewModel()
        {
            LoadTrendingStories();

            LoadMoreCommand = new RelayCommand(LoadMore);
        }
    }
}