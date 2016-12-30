using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using hacker_news_wpf_client;
using hacker_news_wpf_client.Intefaces.hacker_news_wpf_client.Intefaces;
using hacker_news_wpf_client.Utility;
using hacker_news_wpf_client.ViewModels;

namespace hacker_news_wpf_client.ViewModels
{
    public class ShellViewModel : ObservableObject
    {
        #region Fields

        private ICommand _changePageCommand;
        private ICommand _openFlyoutCommand;
        private ICommand _openLinkCommand;

        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        private bool _isFloutOpen = false;

        private StoryItemViewModel _flyoutContent;


        #endregion

        public ShellViewModel()
        {
            // Add available pages
            PageViewModels.Add(new TrendingStoriesViewModel());
            PageViewModels.Add(new BestStoriesViewModel());
            PageViewModels.Add(new NewStoriesViewModel());

            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
        }

        #region Properties / Commands

        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand(
                        p => ChangeViewModel((IPageViewModel)p),
                        p => p is IPageViewModel);
                }

                return _changePageCommand;
            }
        }

        public ICommand OpenFlyoutCommand
        {
            get
            {
                if (_openFlyoutCommand == null)
                {
                    _openFlyoutCommand = new RelayCommand(
                        OpenFlyout,
                        p => true);
                }

                return _openFlyoutCommand;
            }
        }

        private void OpenFlyout(object p)
        {
            var id = (int) p;
            FlyoutContent = new StoryItemViewModel(id);
            IsFlyoutOpen = true;

        }

        public ICommand OpenLinkCommand
        {
            get
            {
                if (_openLinkCommand == null)
                {
                    _openLinkCommand = new RelayCommand(
                        OpenLink,
                        p => true);
                }
                return _openLinkCommand;
            }
        }

        private void OpenLink(object p)
        {
            var url = p as string;

            if (url != null) Process.Start(url);
        }

        public bool IsFlyoutOpen
        {
            get { return _isFloutOpen; }
            set
            {
                _isFloutOpen = value;
                RaisePropertyChanged("IsFlyoutOpen");
            }
        }

        public StoryItemViewModel FlyoutContent
        {
            get
            {
                return _flyoutContent;
            }

            set
            {
                _flyoutContent = value;
                RaisePropertyChanged("FlyoutContent");
                RaisePropertyChanged("IsFlyoutOpen");
            }
        }

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }

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
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        }

        #endregion

        #region Methods

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }

        #endregion
    }
}