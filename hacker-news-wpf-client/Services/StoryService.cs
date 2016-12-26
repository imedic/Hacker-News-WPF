using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using hacker_news_wpf_client.Model;
using Newtonsoft.Json;

namespace hacker_news_wpf_client.Services
{
    public class StoryService
    {
        private static string _url = "https://hacker-news.firebaseio.com/v0/";

        public static async Task<Story> GetStory(int id)
        {
            var storyJson = await DownloadItem.GetJson(_url + "item/" + id + ".json");
            var story = JsonConvert.DeserializeObject<Story>(storyJson);

            return story;
        }

        public static async Task<List<Story>> GetTrendingStories()
        {
            var trendingStoriesIdsJson = await DownloadItem.GetJson(_url + "topstories.json");
            var trendingStoriesIds = JsonConvert.DeserializeObject<int[]>(trendingStoriesIdsJson);

            var topTwentyTrendingStoriesIds = trendingStoriesIds.Take(2);

            var trendingStories = new List<Story>();

            foreach (var id in topTwentyTrendingStoriesIds)
            {
                trendingStories.Add(await GetStory(id));
            }

            return trendingStories;
        }


    }
}
