using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace hacker_news_wpf_client.Utility
{
    public class DownloadItem
    {
        public static async Task<string> GetJson(string url)
        {
            using (var client = new HttpClient())
            {
                using (var data = await client.GetAsync(new Uri(url)))
                {
                    var dataJson = await data.Content.ReadAsStringAsync();
                    return dataJson;
                }
            }
        }
    }
}
