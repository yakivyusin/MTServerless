using MTServerless.Artifact;
using System;
using System.Linq;
using System.Threading;

namespace MTServerless.Relations
{
    public class SiteRelation
    {
        public bool Validate(string query)
        {
            var searchEngine = new DuckDuckGo();
            var sourceResponse = searchEngine.Query(query);
            var followUpQueries = sourceResponse
                .Select(x => (source: x, query: query + $" site:{x.Url.Host}"))
                .ToArray();

            foreach (var followUpQuery in followUpQueries)
            {
                Thread.Sleep(2000);

                var followUpResponse = searchEngine.Query(followUpQuery.query);

                if (!followUpResponse.Any(x => x.Url.Equals(followUpQuery.source.Url)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
