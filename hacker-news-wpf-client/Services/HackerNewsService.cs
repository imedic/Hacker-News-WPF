﻿using System;
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
    public class HackerNewsService
    {
        private static string _base_url = "https://hn.algolia.com/api/v1/";

        public static async Task<Story> GetStory(int id)
        {
            var story = GetFromCache("story" + id) as Story;

            if (story == null)
            {
                var storyJson = await DownloadItem.GetJson(_base_url + "items/" + id);
                story = JsonConvert.DeserializeObject<Story>(storyJson);

                AddToCache("story" + id, story);
            }

            return story;
        }

        public static async Task<List<Story>> GetTrendingStories()
        {
            List<Story> trendingStories = GetFromCache("trendingStories") as List<Story>;

            if (trendingStories == null)
            {
                var trendingStoriesJson = await DownloadItem.GetJson(_base_url + "/search?tags=front_page");

                trendingStories = GetStoryList(trendingStoriesJson);

                AddToCache("trendingStories", trendingStories);
                
            }
            return trendingStories;           
        }

        public static async Task<List<Story>> GetBestStories()
        {
            ObjectCache cache = MemoryCache.Default;
            List<Story> bestStories = GetFromCache("bestStories") as List<Story>;

            if (bestStories == null)
            {
                var bestStoriesJson = await DownloadItem.GetJson("http://hn.algolia.com/api/v1/search?tags=story");

                bestStories = GetStoryList(bestStoriesJson);

                AddToCache("bestStories", bestStories);

            }
            return bestStories;
        }

        public static async Task<List<Story>> GetNewStories()
        {
            List<Story> newStories = GetFromCache("newStories") as List<Story>;

            if (newStories == null)
            {
                var newStoriesJson = await DownloadItem.GetJson("http://hn.algolia.com/api/v1/search_by_date?tags=story");

                newStories = GetStoryList(newStoriesJson);

                AddToCache("newStories", newStories);
            }
            return newStories;
        }

        private static List<Story> GetStoryList(string storyListJson)
        {JObject stories = JObject.Parse(storyListJson);

            IList<JToken> results = stories["hits"].Children().ToList();

            var newStories = new List<Story>();

            foreach (JToken result in results)
            {
                newStories.Add(JsonConvert.DeserializeObject<Story>(result.ToString()));
            }

            return newStories;
        }

        private static object GetFromCache(string cacheId)
        {
            ObjectCache cache = MemoryCache.Default;
            var cacheContent = cache[cacheId];

            return cacheContent;
        }

        private static void AddToCache(string cacheId, object dataToCache)
        {
            CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
            ObjectCache cache = MemoryCache.Default;

            cache.Add(cacheId, dataToCache, cacheItemPolicy);
        }
    }
}