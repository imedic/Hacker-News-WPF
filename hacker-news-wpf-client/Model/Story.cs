using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hacker_news_wpf_client.Model
{
    public class Story
    {
        public string by { get; set; }

        public string title { get; set; }

        public string url { get; set; }

        public string id { get; set; }

        public int score { get; set; }

        public string[] kids { get; set; }
    }
}
