using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace hacker_news_wpf_client.Model
{
    public class Comment
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string Text { get; set; }

        [JsonProperty(PropertyName = "children")]
        public List<Comment> Comments { get; set; }
    }
}
