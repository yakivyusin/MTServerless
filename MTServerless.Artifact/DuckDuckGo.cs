using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using MTServerless.Models;
using System;
using System.Linq;

namespace MTServerless.Artifact
{
    public class DuckDuckGo
    {
        private const string EngineUrl = "https://html.duckduckgo.com/html/?q=";

        public SearchResult[] Query(string query)
        {
            var url = EngineUrl + query;
            var web = new HtmlWeb();
            var doc = web.Load(url);

            return doc
                .QuerySelectorAll(".result:not(.result--ad):not(.result--no-result)")
                .Select(ParseResult)
                .Where(x => x != null)
                .ToArray();
        }

        private SearchResult ParseResult(HtmlNode node)
        {
            var title = node.QuerySelector(".result__title").InnerText.Trim();
            var url = node.QuerySelector(".result__url").InnerText.Trim();
            var description = node.QuerySelector(".result__snippet")?.InnerText.Trim();

            try
            {
                return new SearchResult
                {
                    Title = title,
                    Url = new Uri("https://" + url),
                    Description = description
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
