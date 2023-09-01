using System;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ConsoleApplication1.Parse
{
    public class ParseHtml
    {
        public string HtmlDom()
        {
            var result = "";
            var web = new HtmlWeb();
            HtmlDocument document = web.Load("https://stackoverflow.com/questions/1740587/align-a-div-to-center");

            HtmlNodeCollection collection = document.DocumentNode.SelectNodes("//*[@class='ed_inner_dashboard_info']");
            if (collection != null)
            {
                foreach (HtmlNode htmlNode in collection)
                {
                    if (!htmlNode.HasChildNodes)
                    {
                        result = htmlNode.InnerHtml;
                    }
                }
            }

            return result;
        }
    }
}