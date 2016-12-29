using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace hacker_news_wpf_client.Model
{
    public class Story
    {
        [JsonProperty(PropertyName = "author")]
        public string By { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "points")]
        public int Score { get; set; }

        [JsonProperty(PropertyName = "kids")]
        public string[] Comments { get; set; }

        [JsonProperty(PropertyName = "num_comments")]
        public string NumberOfComments { get; set; }
    }
}
