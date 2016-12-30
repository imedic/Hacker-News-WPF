using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using hacker_news_wpf_client.Model;
using hacker_news_wpf_client.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace hacker_news_wpf_client.Services
{
    public class StoryService
    {
        //private static string _url = "https://hacker-news.firebaseio.com/v0/";

        public static async Task<Story> GetStory(int id)
        {
            var storyJson = await DownloadItem.GetJson("http://hn.algolia.com/api/v1/items/" + id);
            var story = JsonConvert.DeserializeObject<Story>(storyJson);

            return story;
        }

        public static async Task<List<Story>> GetTrendingStoriesFromCacheOrApi()
        {
            ObjectCache cache = MemoryCache.Default;
            List<Story> trendingStories = cache["trendingStories"] as List<Story>;

            if (trendingStories == null)
            {
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();

                trendingStories = await GetTrendingStoriesFromApi();

                cache.Add("trendingStories", trendingStories, cacheItemPolicy);
                
            }
            return trendingStories;           
        }

        private static async Task<List<Story>> GetTrendingStoriesFromApi()
        {
            //var trendingStoriesIdsJson = await DownloadItem.GetJson(_url + "topstories.json");

            var trendingStoriesIdsJson = await DownloadItem.GetJson("http://hn.algolia.com/api/v1/search?tags=front_page");

            JObject stories = JObject.Parse(trendingStoriesIdsJson);

            IList<JToken> results = stories["hits"].Children().ToList();

            

            //var trendingStoriesIds = JsonConvert.DeserializeObject<int[]>(trendingStoriesIdsJson);

            //var topTwentyTrendingStoriesIds = trendingStoriesIds.Take(10);

            var trendingStories = new List<Story>();

            //foreach (var id in topTwentyTrendingStoriesIds)
            //{
            //    trendingStories.Add(await GetStory(id));
            //}

            foreach (JToken result in results)
            {
                trendingStories.Add(JsonConvert.DeserializeObject<Story>(result.ToString()));
            }

            return trendingStories;
        }

        public static async Task<List<Story>> GetBestStoriesFromCacheOrApi()
        {
            ObjectCache cache = MemoryCache.Default;
            List<Story> bestStories = cache["bestStories"] as List<Story>;

            if (bestStories == null)
            {
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();

                bestStories = await GetBestStoriesFromApi();

                cache.Add("bestStories", bestStories, cacheItemPolicy);

            }
            return bestStories;
        }

        public static async Task<List<Story>> GetBestStoriesFromApi()
        {
            //var bestStoriesIdsJson = await DownloadItem.GetJson(_url + "beststories.json");
            //var bestStoriesIds = JsonConvert.DeserializeObject<int[]>(bestStoriesIdsJson);

            var bestStoriesIdsJson = await DownloadItem.GetJson("http://hn.algolia.com/api/v1/search?tags=story");

            JObject stories = JObject.Parse(bestStoriesIdsJson);

            IList<JToken> results = stories["hits"].Children().ToList();


            //var topTwentyBestStoriesIds = bestStoriesIds.Take(10);

            var bestStories = new List<Story>();

            foreach (JToken result in results)
            {
                bestStories.Add(JsonConvert.DeserializeObject<Story>(result.ToString()));
            }

            //foreach (var id in topTwentyBestStoriesIds)
            //{
            //    bestStories.Add(await GetStory(id));
            //}

            return bestStories;

        }

        public static async Task<List<Story>> GetNewStoriesFromCacheOrApi()
        {
            ObjectCache cache = MemoryCache.Default;
            List<Story> newStories = cache["newStories"] as List<Story>;

            if (newStories == null)
            {
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();

                newStories = await GetNewStoriesFromApi();

                cache.Add("newStories", newStories, cacheItemPolicy);

            }
            return newStories;

        }

        public static async Task<List<Story>> GetNewStoriesFromApi()
        {
            //var newStoriesIdsJson = await DownloadItem.GetJson(_url + "newstories.json");
            var newStoriesIdsJson = await DownloadItem.GetJson("http://hn.algolia.com/api/v1/search_by_date?tags=story");

            JObject stories = JObject.Parse(newStoriesIdsJson);

            IList<JToken> results = stories["hits"].Children().ToList();

            //var newStoriesIds = JsonConvert.DeserializeObject<int[]>(newStoriesIdsJson);

            //var topTwentyNewStoriesIds = newStoriesIds.Take(10);

            var newStories = new List<Story>();

            foreach (JToken result in results)
            {
                newStories.Add(JsonConvert.DeserializeObject<Story>(result.ToString()));
            }


            //foreach (var id in topTwentyNewStoriesIds)
            //{
            //    newStories.Add(await GetStory(id));
            //}

            return newStories;

        }
    }
}
