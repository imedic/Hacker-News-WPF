using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using hacker_news_wpf_client.Model;
using hacker_news_wpf_client.Services;

namespace hacker_news_wpf_client.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        //ObservableCollection<object> _children;

        //public NotifyTaskCompletion<List<Story>> TrendingStories { get; private set; }
        //public NotifyTaskCompletion<List<Story>> BestStories { get; private set; }



        public MainViewModel()
        {
            //_children = new ObservableCollection<object>();
            //_children.Add(new TrendingStoriesViewModel());
            //_children.Add(new BestStoriesViewModel());
            //TrendingStories = new NotifyTaskCompletion<List<Story>>(StoryService.GetTrendingStories());

        }

        //public string _selectedTabName;
        //public string SelectedTabName
        //{
        //    get { return _selectedTabName; }
        //    set
        //    {
        //        if (_selectedTabName != value)
        //        {
        //            _selectedTabName = value;
        //            PropertyChanged(this, new PropertyChangedEventArgs("IsSelected"));

        //            if (SelectedTabName == "BEST")
        //            {
        //                BestStories = new NotifyTaskCompletion<List<Story>>(StoryService.GetBestStories());

        //            }
        //        }
        //    }
        //}

        //public ObservableCollection<object> Children { get { return _children; } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
