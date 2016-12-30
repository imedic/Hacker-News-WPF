using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Data;
using HtmlAgilityPack;

namespace hacker_news_wpf_client.Converters
{
    class HtmlToCleanTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = value as string;

            if (text == null) return null;
                    
            var cleanText = "";
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(text);

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//text()"))
            {
                cleanText += node.InnerText;
            }

            cleanText = HttpUtility.HtmlDecode(cleanText);


            return cleanText;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
