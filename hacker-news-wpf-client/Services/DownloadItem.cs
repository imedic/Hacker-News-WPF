using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace hacker_news_wpf_client.Services
{
    public class DownloadItem
    {
        public static async Task<string> GetJson(string url)
        {
            using (var client = new HttpClient())
            {
                using (var r = await client.GetAsync(new Uri(url)))
                {
                    string result = await r.Content.ReadAsStringAsync();
                    return result;
                }
            }
        }
    }
}
