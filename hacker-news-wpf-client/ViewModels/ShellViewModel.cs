using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using hacker_news_wpf_client;
using hacker_news_wpf_client.Intefaces.hacker_news_wpf_client.Intefaces;
using hacker_news_wpf_client.Utility;
using hacker_news_wpf_client.ViewModels;

namespace hacker_news_wpf_client.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        public RelayCommand<IPageViewModel> ChangePageCommand { get; private set; }
        public RelayCommand<string> OpenLinkCommand { get; private set; }
        public RelayCommand<int> OpenFlyoutCommand { get; private set; }


        public ShellViewModel()
        {
            // Add available pages
            PageViewModels.Add(new TrendingStoriesViewModel());
            PageViewModels.Add(new BestStoriesViewModel());
            PageViewModels.Add(new NewStoriesViewModel());

            // Set starting page
            CurrentPageViewModel = PageViewModels[0];

            //Initialize relay commands
            ChangePageCommand = new RelayCommand<IPageViewModel>(ChangeViewModel);

            OpenLinkCommand = new RelayCommand<string>(OpenLink);

            OpenFlyoutCommand = new RelayCommand<int>(OpenFlyout);
        }


        private bool _isFloutOpen = false;

        public bool IsFlyoutOpen
        {
            get { return _isFloutOpen; }
            set
            {
                _isFloutOpen = value;
                RaisePropertyChanged(() => IsFlyoutOpen);
            }
        }


        private StoryDetailsViewModel _flyoutContent;

        public StoryDetailsViewModel FlyoutContent
        {
            get
            {
                return _flyoutContent;
            }

            set
            {
                _flyoutContent = value;
                RaisePropertyChanged(() => FlyoutContent);
                RaisePropertyChanged(() => IsFlyoutOpen);
            }
        }


        private List<IPageViewModel> _pageViewModels;

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }


        private IPageViewModel _currentPageViewModel;

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    RaisePropertyChanged(() => CurrentPageViewModel);
                }
            }
        }


        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }


        private void OpenFlyout(int storyId)
        {
            FlyoutContent = new StoryDetailsViewModel(storyId);
            IsFlyoutOpen = true;

        }


        private void OpenLink(string url)
        {
            if (url != null) Process.Start(url);
        }

    }
}