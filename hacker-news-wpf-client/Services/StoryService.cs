using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hacker_news_wpf_client.Model;
using Newtonsoft.Json;

namespace hacker_news_wpf_client.Services
{
    public class StoryService
    {
        private static string _url = "https://hacker-news.firebaseio.com/v0/item/";

        public static async Task<Story> GetStory(int id)
        {
            var storyJson = await DownloadItem.GetJson(_url + id + ".json");
            var story = JsonConvert.DeserializeObject<Story>(storyJson);

            return story;
        }

        public static List<Story> GetTrendingStories()
        {
            return new List<Story>();
        }


    }
}
