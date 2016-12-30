using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace hacker_news_wpf_client.Converters
{
    class HtmlToCleanTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = value as string;

            if (text == null) return "";

            text = text.Replace("&euro;", "&amp;");
            text = text.Replace("&amp;&amp;", "&amp;");

            text = text.Replace("&amp;sbquo;", "€");
            text = text.Replace("&sbquo;", "€");

            text = text.Replace("&amp;#62;", ">");
            text = text.Replace("&amp;#60;", "<");
            text = text.Replace("&amp;#38;", "&");
            text = text.Replace("&amp;rdquo;", "—");

            text = text.Replace("&amp;&trade;", "'");

            text = text.Replace("&amp;&oelig;", "\"");

            text = text.Replace("&amp;", "\"");

            text = text.Replace("\\\"", "\"");

            text = text.Replace("__BR__", "\n\n");

            text = text.Replace("&amp; rdquo;", "—");
            text = text.Replace("&amp;rdquo;", "—");

            text = text.Replace("&euro;&trade;", "'");
            text = text.Replace("&amp;&trade;", "'");

            text = text.Replace("&euro;&oelig;", "\"");
            text = text.Replace("&amp;&oelig;", "\"");
            text = text.Replace("&euro;&amp;&oelig;", "\"");
            text = text.Replace("&amp;euro;", "\"");
            text = text.Replace("\\\"", "\"");

            text = text.Replace("&amp;sbquo;", "€");
            text = text.Replace("&sbquo;", "€");

            text = text.Replace("&amp;#62;", ">");
            text = text.Replace("&amp;#60;", "<");

            text = text.Replace("&amp;#38;", "&");

            text = text.Replace("__BR__", "\n\n");

            return text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
