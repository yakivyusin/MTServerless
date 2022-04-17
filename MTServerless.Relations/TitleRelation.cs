using MTServerless.Artifact;
using System.Linq;
using System.Threading;

namespace MTServerless.Relations
{
    public class TitleRelation
    {
        public bool Validate(string query)
        {
            var searchEngine = new DuckDuckGo();
            var sourceResponse = searchEngine.Query(query);
            var followUpQueries = sourceResponse
                .Select(x => (source: x, query: query + $" {x.Title}"))
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
