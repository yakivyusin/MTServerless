using MTServerless.Artifact;
using System;
using System.Linq;

namespace MTServerless.Relations
{
    public class SwapRelation
    {
        public bool Validate(string query)
        {
            var searchEngine = new DuckDuckGo();
            var sourceResponse = searchEngine.Query(query);

            var reverseQuery = string.Join(' ', query.Split(' ').Reverse());
            var reverseResponse = searchEngine.Query(reverseQuery);

            var sourceUrls = sourceResponse.Select(x => x.Url).ToHashSet();
            var reverseUrls = reverseResponse.Select(x => x.Url).ToHashSet();

            var jaccardIndex = ((double)sourceUrls.Intersect(reverseUrls).Count()) / sourceUrls.Union(reverseUrls).Count();

            return jaccardIndex >= 0.5;
        }
    }
}
